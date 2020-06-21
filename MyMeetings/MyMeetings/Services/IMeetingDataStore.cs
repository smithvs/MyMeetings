using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyMeetings.Models.BaseMeeting;
using MyMeetings.Models.Meetings;

namespace MyMeetings.Services
{
    public interface IMeetingDataStore
    {
        Task<bool> AddMeetingAsync(Meeting item);
        Task<bool> AddMeetingsFromBaseAsync(BaseMeeting baseMeeting);
        Task<bool> AddMeetingsFromBase(BaseMeeting baseMeeting);
        Task<bool> UpdateMeetingAsync(Meeting item);
        Task<bool> DeleteMeetingAsync(int id);
        Task<Meeting> GetMeetingAsync(int id);
        Task<IEnumerable<Meeting>> GetMeetingsAsync(bool forceRefresh = false);

    }
}
