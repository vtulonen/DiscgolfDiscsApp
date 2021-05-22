using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFApp.Core;

namespace WPFApp.ViewModels
{
    class MainViewModel : ObservableObject
    {

        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand DiscsViewCommand { get; set; }
        public RelayCommand LoginViewCommand { get; set; }


        public HomeViewModel HomeVM { get; set; }
        public DiscsViewModel DiscsVM { get; set; }
        public LoginViewModel LoginVM { get; set; }


        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value;
                RaisePropertyChanged();
            }
        }

        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            DiscsVM = new DiscsViewModel();
            LoginVM = new LoginViewModel();
            CurrentView = LoginVM;

            HomeViewCommand = new RelayCommand(x => CurrentView = HomeVM);
            DiscsViewCommand = new RelayCommand(x => CurrentView = DiscsVM);
            LoginViewCommand = new RelayCommand(x => CurrentView = LoginVM);

        }

    }
}
