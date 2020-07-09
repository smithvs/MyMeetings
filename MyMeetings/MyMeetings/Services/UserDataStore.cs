using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

using MyMeetings.Models;
using MyMeetings.Services;
using Xamarin.Forms;


[assembly: Dependency(typeof(UserDataStore))]
namespace MyMeetings.Services
{ class UserDataStore:IUserDataStore
    {
        private User _user;

        public User UserInfo
        {
            get { return _user; }
        }

        public UserDataStore()
        {
            _user = new User() { Login="Vasya", Password = "123qwe"};
        }
        public Task<bool> AddUserAsync(User item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateUserAsync(User item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
