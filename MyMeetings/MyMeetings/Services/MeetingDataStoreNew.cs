using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MyMeetings.Models.BaseMeeting;
using MyMeetings.Models.Meetings;
using MyMeetings.Services;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly: Dependency(typeof(MeetingDataStore2))]
namespace MyMeetings.Services
{
    public class MeetingDataStore2: IMeetingDataStore
    {
        private List<Meeting> _meetings;
        private HttpClient client;

        public MeetingDataStore2()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.BackendUrl}/");
            _meetings = new List<Meeting>();
        }

        bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;

        public async Task<IEnumerable<Meeting>> GetMeetingsAsync(bool forceRefresh = false)
        {
            if (forceRefresh && IsConnected)
            {
                var json = await client.GetStringAsync($"v1/meetings");
                _meetings = await Task.Run(() => JsonConvert.DeserializeObject<List<Meeting>>(json));
            }
            return _meetings;
        }

        public async Task<Meeting> GetMeetingAsync(int id)
        {
            Meeting bMeeting = new Meeting();
            if (id != 0 && IsConnected)
            {
                var json = await client.GetStringAsync($"v1/meetings/{id}");
                bMeeting = await Task.Run(() => JsonConvert.DeserializeObject<Meeting>(json));
            }
            return bMeeting;
        }

        public async Task<bool> AddMeetingAsync(Meeting item)
        {
            if (item == null || !IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(item);

            var response = await client.PostAsync($"v1/meetings", new StringContent(serializedItem, Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode == true)
                _meetings.Add(item);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteMeetingAsync(int id)
        {
            if (id == 0 && !IsConnected)
                return false;

            var response = await client.DeleteAsync($"v1/meetings{id}");

            return response.IsSuccessStatusCode;
        }


        public async Task<bool> UpdateMeetingAsync(Meeting item)
        {
            if (item == null || item.Id == 0 || !IsConnected)
                return false;

            var serializedItem = JsonConvert.SerializeObject(item);
            var buffer = Encoding.UTF8.GetBytes(serializedItem);
            var byteContent = new ByteArrayContent(buffer);

            var response = await client.PutAsync(new Uri($"v1/meetings/{item.Id}"), byteContent);

            return response.IsSuccessStatusCode;
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
                        TimeStart = (periodStart.Date + baseMeeting.MeetingTimeStart.TimeOfDay),
                        TimeEnd = (periodEnd.Date + baseMeeting.MeetingTimeEnd.TimeOfDay),
                        Income = baseMeeting.Income,
                        Notation = baseMeeting.Notation,

                    };
                    await AddMeetingAsync(meeting);
                    _meetings.Add(meeting);
                }
                periodStart = periodStart.AddDays(1);
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
    }
}
