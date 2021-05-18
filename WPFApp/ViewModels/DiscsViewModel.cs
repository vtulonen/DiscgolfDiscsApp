using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFApp.Models;

namespace WPFApp.ViewModels
{
    class DiscsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<DiscModel> _discs = new ObservableCollection<DiscModel>();
        private DiscModel _selectedDisc;
        public event PropertyChangedEventHandler PropertyChanged;

        public DiscsViewModel()
        {
            Discs.Add(new DiscModel { Id = 0, Name = "Test", Brand = "Innova", Speed = 10, Glide = 5, Turn = 1, Fade = 2, });
            Discs.Add(new DiscModel { Id = 0, Name = "Bester", Brand = "Innova", Speed = 9, Glide = 5, Turn = -2, Fade = 1 });
            Discs.Add(new DiscModel { Id = 0, Name = "Jestemn", Brand = "Innova", Speed = 5, Glide = 5, Turn = 0, Fade = 0 });
            Discs.Add(new DiscModel { Id = 0, Name = "Geste", Brand = "Innova", Speed = 2, Glide = 2, Turn = 0, Fade = 1 });
        }

        public ObservableCollection<DiscModel> Discs
        {
            get { return _discs; }
            set { Discs = value; }
        }

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public DiscModel MyProperty
        {
            get { return _selectedDisc; }
            set
            {
                _selectedDisc = value;
                RaisePropertyChanged("Names");


            }
        }
    }
}

