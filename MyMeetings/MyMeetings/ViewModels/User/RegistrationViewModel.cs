using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MyMeetings.Models;
using MyMeetings.Services;
using Xamarin.Forms;

namespace MyMeetings.ViewModels
{
    public class RegistrationViewModel:BaseViewModel
    {
        private User _user;
        public User UserInfo
        {
            get { return _user; }
            set { SetProperty(ref _user, value); }
        }

        private string _passwordReplay;
        public string PasswordReplay
        {
            get { return _passwordReplay; }
            set { SetProperty(ref _passwordReplay, value); }
        }

        private bool _noCorrectPassword;
        public bool NoCorrectPassword
        {
            get { return _noCorrectPassword; }
            set { SetProperty(ref _noCorrectPassword, value); }
        }

        public Command PasswordCheckCommand { get; set; }

        public RegistrationViewModel()
        {
            _user = UserDataStore.UserInfo;
            PasswordCheckCommand = new Command(async () => await PasswordCheck());
        }

        private async Task PasswordCheck()
        {
            if (UserInfo.Password != null && UserInfo.Password.Length != 0 && PasswordReplay != null &&
                PasswordReplay.Length != 0 && UserInfo.Password != PasswordReplay)
            {
                NoCorrectPassword = true;
            }
            else
            {
                NoCorrectPassword = false;
            }
                
        }
    }
}