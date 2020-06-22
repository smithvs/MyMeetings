using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MyMeetings.Models.BaseMeeting;
using MyMeetings.Models.Meetings;
using MyMeetings.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(MeetingDataStore))]
namespace MyMeetings.Services
{
    public class MeetingDataStore: IMeetingDataStore
    {
        private readonly List<Meeting> _meetings;

        public MeetingDataStore()
        {
            _meetings = new List<Meeting>();
            
        }

        public async Task<bool> AddMeetingAsync(Meeting item)
        {
            item.Id = _meetings.Select(m => m.Id).Max() + 1;
            _meetings.Add(item);
            return await Task.FromResult(true);
        }

        public async Task<bool> AddMeetingsFromBaseAsync(BaseMeeting baseMeeting)
        {
            DateTime periodStart = new DateTime(baseMeeting.PeriodDateStart.Ticks);
            DateTime periodEnd = new DateTime(baseMeeting.PeriodDateStart.Ticks);
            while (periodStart <= periodEnd)
            {
                if ((int)periodStart.DayOfWeek == baseMeeting.DayWeek)
                {
                    var meeting = new Meeting()
                    {
                        Id = _meetings.Select(m => m.Id).Max() + 1,
                        Title = baseMeeting.Title,
                        Client = baseMeeting.Client,
                        Place = baseMeeting.Place,
                        TimeStart = (periodStart.Date +baseMeeting.MeetingTimeStart.TimeOfDay),
                        TimeEnd = (periodEnd.Date + baseMeeting.MeetingTimeEnd.TimeOfDay),
                        Income = baseMeeting.Income,
                        Notation = baseMeeting.Notation,

                    };
                    _meetings.Add(meeting);
                }
                periodStart=periodStart.AddDays(1);
            }

            return await Task.FromResult(true);
        }

        public Task<bool> AddMeetingsFromBase(BaseMeeting baseMeeting)
        {
            DateTime periodStart = new DateTime(baseMeeting.PeriodDateStart.Ticks);
            DateTime periodEnd = new DateTime(baseMeeting.PeriodDateEnd.Ticks);
            while (periodStart <= periodEnd)
            {
                if ((int)periodStart.DayOfWeek == baseMeeting.DayWeek)
                {
                    var meeting = new Meeting()
                    {
                        Id = _meetings.Count + 1,
                        Title = baseMeeting.Title,
                        Client = baseMeeting.Client,
                        Place = baseMeeting.Place,
                        TimeStart = (periodStart.Date + baseMeeting.MeetingTimeStart.TimeOfDay),
                        TimeEnd = (periodEnd.Date + baseMeeting.MeetingTimeEnd.TimeOfDay),
                        Income = baseMeeting.Income,
                        Notation = baseMeeting.Notation,

                    };
                    _meetings.Add(meeting);
                }
                periodStart = periodStart.AddDays(1);
            }

            return Task.FromResult(true);
        }

        public async Task<bool> DeleteMeetingAsync(int id)
        {
            _meetings.RemoveAll(m=>m.Id == id);
            return  await Task.FromResult(true);
        }

        public async Task<Meeting> GetMeetingAsync(int id)
        {
            return await Task.FromResult(_meetings.FirstOrDefault(m=>m.Id==id));
        }

        public async Task<IEnumerable<Meeting>> GetMeetingsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult<IEnumerable<Meeting>>(_meetings);
        }

        public async Task<bool> UpdateMeetingAsync(Meeting item)
        {
            for (int i = 0; i < _meetings.Count; i++)
            {
                if (_meetings[i].Id == item.Id)
                    _meetings[i] = item;
            }
            return await Task.FromResult(true);
        }
    }
}
