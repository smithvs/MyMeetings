using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMeetings.Models;
using MyMeetings.Models.BaseMeeting;
using MyMeetings.Models.Meetings;
using MyMeetings.Services;
using MyMeetings.Views;
using Xamarin.Forms;

namespace MyMeetings.ViewModels
{
    public class MeetingsViewModel: BaseViewModel
    {
        public ObservableCollection<Meeting> MeetingOnActualDay { get; set; }

        DateTime _actualDay = DateTime.Now;
        public DateTime ActualDay
        {
            get { return _actualDay; }
            set { SetProperty(ref _actualDay, value); }
        }

        public Command NextDayCommand { get; set; }
        public Command PrevDayCommand { get; set; }
        public Command AddMeetingCommand { get; set; }



        public Command LoadItemsCommand { get; set; }
        

        public MeetingsViewModel()
        {
            Title = "Календарь";
            MeetingOnActualDay = new ObservableCollection<Meeting>();
            
            var basemeetings = BaseMeetingDataStore.GetBaseMeetingsAsync().Result;
            foreach (var basemeeting in basemeetings)
            {
                MeetingDataStore.AddMeetingsFromBase(basemeeting);
            }

            MeetingOnActualDayUpdate();
            NextDayCommand = new Command(async () => await NextDay());
            PrevDayCommand = new Command(async () => await PreviousDay());
            AddMeetingCommand = new Command(async () => await AddMeeting());

        }

        private async Task AddMeeting()
        {
            
        }

        private async Task PreviousDay()
        {
            ActualDay = ActualDay.AddDays(-1);
            MeetingOnActualDayUpdate();


        }

        private async Task NextDay()
        {
            ActualDay = ActualDay.AddDays(1);
            MeetingOnActualDayUpdate();
        }

        public async void MeetingOnActualDayUpdate()
        {
            
            MeetingOnActualDay.Clear();
            var meetings = await MeetingDataStore.GetMeetingsAsync(true);
            meetings = meetings.Where(m =>m.TimeStart.Date == ActualDay.Date);
            foreach (var item in meetings)
            {
                MeetingOnActualDay.Add(item);
            }
        }
    }
}
