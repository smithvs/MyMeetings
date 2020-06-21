using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyMeetings.Models.BaseMeeting;

namespace MyMeetings.Services
{
    public interface IBaseMeetingDataStore
    {
        Task<bool> AddBaseMeetingAsync(BaseMeeting item);
        Task<bool> UpdateBaseMeetingAsync(BaseMeeting item);
        Task<bool> DeleteBaseMeetingAsync(int id);
        Task<BaseMeeting> GetBaseMeetingAsync(int id);
        Task<IEnumerable<BaseMeeting>> GetBaseMeetingsAsync(bool forceRefresh = false);
    }
}
