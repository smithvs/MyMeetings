using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using MyMeetings.Models;

namespace MyMeetings.Services
{
    public interface IUserDataStore
    {
        Task<bool> AddUserAsync(User item);
        Task<bool> UpdateUserAsync(User item);
        Task<bool> DeleteUserAsync(int id);
        Task<User> GetUserAsync(int id);

        User UserInfo { get; }
    }
}
