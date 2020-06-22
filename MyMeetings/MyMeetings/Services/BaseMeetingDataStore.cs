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

[assembly: Dependency(typeof(BaseMeetingDataStore))]
namespace MyMeetings.Services
{
    public class BaseMeetingDataStore: IBaseMeetingDataStore
    {
        private readonly List<BaseMeeting> _baseMeetings;

        public BaseMeetingDataStore()
        {
            
            _baseMeetings = new List<BaseMeeting>();
            _baseMeetings.Add(new BaseMeeting()
            {
                
                Client = "Евгений",
                DayWeek = 3,
                Income = 200,
                MeetingTimeEnd = DateTime.ParseExact("12:00","HH:mm",CultureInfo.InvariantCulture),
                MeetingTimeStart = DateTime.ParseExact("10:30", "HH:mm", CultureInfo.InvariantCulture),
                PeriodDateEnd = DateTime.ParseExact("01.08.2020", "dd.MM.yyyy", CultureInfo.InvariantCulture),
                PeriodDateStart = DateTime.ParseExact("01.06.2020", "dd.MM.yyyy", CultureInfo.InvariantCulture),
                Place = "Революции, 10-123",
                Notation = "Есть кошка",
                Title = "Математика",
                Id = 1,
                UserId = 1,
                Type = 0
            });

            _baseMeetings.Add(new BaseMeeting()
            {
                Client = "Пётр",
                DayWeek = 4,
                Income = 200,
                MeetingTimeEnd = DateTime.ParseExact("14:00", "HH:mm", CultureInfo.InvariantCulture),
                MeetingTimeStart = DateTime.ParseExact("12:30", "HH:mm", CultureInfo.InvariantCulture),
                PeriodDateEnd = DateTime.ParseExact("12.09.2020", "dd.MM.yyyy", CultureInfo.InvariantCulture),
                PeriodDateStart = DateTime.ParseExact("01.05.2020", "dd.MM.yyyy", CultureInfo.InvariantCulture),
                Place = "кв.17",
                Notation = "",
                Title = "Математика ЕГЭ",
                Id = 2,
                UserId = 1,
                Type = 0
            });

            _baseMeetings.Add(new BaseMeeting()
            {
                Client = "Олег",
                DayWeek = 4,
                Income = 300,
                MeetingTimeEnd = DateTime.ParseExact("11:00", "HH:mm", CultureInfo.InvariantCulture),
                MeetingTimeStart = DateTime.ParseExact("09:30", "HH:mm", CultureInfo.InvariantCulture),
                PeriodDateEnd = DateTime.ParseExact("12.07.2020", "dd.MM.yyyy", CultureInfo.InvariantCulture),
                PeriodDateStart = DateTime.ParseExact("01.06.2020", "dd.MM.yyyy", CultureInfo.InvariantCulture),
                Place = "Станиславского, 12",
                Notation = "язык С#",
                Title = "Программирование",
                Id = 3,
                UserId = 1,
                Type = 0
            });
        }

        public async Task<bool> AddBaseMeetingAsync(BaseMeeting item)
        {
            item.Id = _baseMeetings.Select(m => m.Id).Max() + 1;
            _baseMeetings.Add(item);
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteBaseMeetingAsync(int id)
        {
            _baseMeetings.RemoveAll(m=>m.Id == id);
            return  await Task.FromResult(true);
        }

        public async Task<BaseMeeting> GetBaseMeetingAsync(int id)
        {
            return await Task.FromResult(_baseMeetings.FirstOrDefault(m=>m.Id==id));
        }

        public async Task<IEnumerable<BaseMeeting>> GetBaseMeetingsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult<IEnumerable<BaseMeeting>>(_baseMeetings);
        }

        public async Task<bool> UpdateBaseMeetingAsync(BaseMeeting item)
        {
            for (int i = 0; i < _baseMeetings.Count; i++)
            {
                if (_baseMeetings[i].Id == item.Id)
                    _baseMeetings[i] = item;
            }
            return await Task.FromResult(true);
        }
    }
}
