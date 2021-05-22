using DiscgolfLib;
using DiscgolfLib.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFApp.Core;


namespace WPFApp.ViewModels
{
    public class DiscsViewModel : INotifyPropertyChanged
    {
        // Collections to hold disc data bound to listViews
        private ObservableCollection<DiscModel> _discs = new ObservableCollection<DiscModel>();
        private ObservableCollection<DiscModel> _bagDiscs = new ObservableCollection<DiscModel>();

        public event PropertyChangedEventHandler PropertyChanged;

        // Command properties
        public RelayCommand AddToBagCommand { get; set; }       // Bound to Add button
        public RelayCommand RemoveFromBagCommand { get; set; }  // Bound to Remove button
        public RelayCommand LoadDiscsCommand { get; set; }      // Executed in constructor

        public DiscsViewModel()
        {
            ApiHelper.InitializeClient();  // ApiClient for reading data from DiscsAPI

            // Setting execute actions for the commands
            AddToBagCommand = new RelayCommand(selectedItem => ExecAdd(selectedItem));          // Actions separated to its own method       
            RemoveFromBagCommand = new RelayCommand(selectedItem => ExecRemove(selectedItem)); // selectedItem of type object gets passed from view through binding
            LoadDiscsCommand = new RelayCommand(x => ExecLoadDiscs());
            LoadDiscsCommand.Execute(null);
        }


        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ObservableCollection<DiscModel> Discs
        {
            get { return _discs; }
            set 
            { 
                _discs = value;
                RaisePropertyChanged("Discs"); // Updates the bound source when Discs collection changes
            }
        }

        public ObservableCollection<DiscModel> BagDiscs
        {
            get { return _bagDiscs; }
            set { _discs = value; }
        }

        //Execute delegate for AddToBagCommand
        private void ExecAdd(object selectedItem)
        {
            if (selectedItem != null)
            {
                BagDiscs.Add((DiscModel)selectedItem); // Cast object to DiscModel
            }
            else
            {
                MessageBox.Show("Pelase select a disc from 'All Discs' to add to your bag.");
            }
        }

        //Execute delegate for RemoveFromBagCommand
        private void ExecRemove(object selectedItem)
        {
            if (selectedItem != null)
            {
                BagDiscs.Remove((DiscModel)selectedItem);
            }
            else
            {
                MessageBox.Show("Please select a disc from 'Your Bag' to remove.");
            }
        }

        // Load discs from API and populate Discs collection
        private async void ExecLoadDiscs()
        {
            try
            {
                var discs = await DiscProcessor.LoadAllDiscs();
                var sortedDiscsSpeed = discs.OrderByDescending(x => x.Speed);
                Discs = ToObservableCollection(sortedDiscsSpeed);
            }
            catch(HttpRequestException) // if api does not respond, populate with dummy data
            {
                Discs.Add(new DiscModel { Id = 0, Name = "Test", Brand = "Innova", Speed = 10, Glide = 5, Turn = 1, Fade = 2, });
                Discs.Add(new DiscModel { Id = 0, Name = "Bester", Brand = "Innova", Speed = 9, Glide = 5, Turn = -2, Fade = 1 });
                Discs.Add(new DiscModel { Id = 0, Name = "Jestemn", Brand = "Innova", Speed = 5, Glide = 5, Turn = 0, Fade = 0 });
                Discs.Add(new DiscModel { Id = 0, Name = "Geste", Brand = "Innova", Speed = 2, Glide = 2, Turn = 0, Fade = 1 });
            }
        }


        public ObservableCollection<T> ToObservableCollection<T>(IEnumerable<T> enumeration)
        {
            return new ObservableCollection<T>(enumeration);
        }
    }
}

