using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFApp.Core;
using WPFApp.Models;

namespace WPFApp.ViewModels
{
    class DiscsViewModel
    {
        // Collections to hold disc data bound to listViews
        private ObservableCollection<DiscModel> _discs = new ObservableCollection<DiscModel>();
        private ObservableCollection<DiscModel> _bagDiscs = new ObservableCollection<DiscModel>();

        // Command properties
        public RelayCommand AddToBagCommand { get; set; }       // Bound to Add button
        public RelayCommand RemoveFromBagCommand { get; set; }  // Bound to Remove button

        public DiscsViewModel()
        {

            Discs.Add(new DiscModel { Id = 0, Name = "Test", Brand = "Innova", Speed = 10, Glide = 5, Turn = 1, Fade = 2, });
            Discs.Add(new DiscModel { Id = 0, Name = "Bester", Brand = "Innova", Speed = 9, Glide = 5, Turn = -2, Fade = 1 });
            Discs.Add(new DiscModel { Id = 0, Name = "Jestemn", Brand = "Innova", Speed = 5, Glide = 5, Turn = 0, Fade = 0 });
            Discs.Add(new DiscModel { Id = 0, Name = "Geste", Brand = "Innova", Speed = 2, Glide = 2, Turn = 0, Fade = 1 });

            // Setting execute actions for the commands
            // selectedItem of type object gets passed from view through binding
            AddToBagCommand = new RelayCommand(selectedItem => ExecAdd(selectedItem)); // Action separated to its own method       
            RemoveFromBagCommand = new RelayCommand(selectedItem => ExecRemove(selectedItem));
            }

        public ObservableCollection<DiscModel> Discs
        {
            get { return _discs; }
            set { Discs = value; }
        }

        public ObservableCollection<DiscModel> BagDiscs
        {
            get { return _bagDiscs; }
            set { Discs = value; }
        }

        private void ExecAdd(object selectedItem)
        {
            if (selectedItem != null)
            {
                BagDiscs.Add((DiscModel)selectedItem); // Cast object to DiscModel
            }
            else
            {
                MessageBox.Show("Pelase select a disc from the all discs to add to your bag.");
            }
        }

        private void ExecRemove(object selectedItem)
        {
            if (selectedItem != null)
            {
                BagDiscs.Remove((DiscModel)selectedItem);
            }
            else
            {
                MessageBox.Show("Please select a disc from your bag to remove.");
            }
        }
    }
}

