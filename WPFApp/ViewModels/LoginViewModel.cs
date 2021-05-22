using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFApp.Core;

namespace WPFApp.ViewModels
{
    public class LoginViewModel : ObservableObject
    {
        private string _username;
        private string _password;

        public RelayCommand LogInCommand { get; set; }

        public LoginViewModel()
        {
            LogInCommand = new RelayCommand(x => MessageBox.Show($"Logged in as {_username}"), x => UsernameFieldIsValid(_username));
        }

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                RaisePropertyChanged();
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                RaisePropertyChanged();
            }
        }


        public bool UsernameFieldIsValid(string userName)
        {
            bool result = false;
            if (userName != null)
            {
                if (userName.Length > 0) result = true;
                else result = false;

            }
            return result;
        }
    }
}
