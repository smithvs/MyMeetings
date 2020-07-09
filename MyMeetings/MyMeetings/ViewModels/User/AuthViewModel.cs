using System;
using System.Collections.Generic;
using System.Text;
using MyMeetings.Models;

namespace MyMeetings.ViewModels
{
    public class AuthViewModel : BaseViewModel
    {
        private User _user;
        public User UserInfo
        {
            get { return _user; }
            set { SetProperty(ref _user, value); }
        }
        public AuthViewModel()
        {
            _user = UserDataStore.UserInfo;
        }
    }
}
