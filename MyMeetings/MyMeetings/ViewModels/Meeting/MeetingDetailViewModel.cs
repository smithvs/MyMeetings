using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using MyMeetings.Models.Meetings;
using Xamarin.Forms;

namespace MyMeetings.ViewModels
{
    public class MeetingDetailViewModel:BaseViewModel
    {
        private Meeting _meeting;

        public Meeting Meeting
        {
            get { return _meeting; }
            set { SetProperty(ref _meeting, value); }
        }

        private TimeSpan _meetingTimeStart;
        public TimeSpan MeetingTimeStart
        {
            get { return _meetingTimeStart; }
            set { SetProperty(ref _meetingTimeStart, value); }
        }

        private TimeSpan _meetingTimeEnd;
        public TimeSpan MeetingTimeEnd
        {
            get { return _meetingTimeEnd; }
            set { SetProperty(ref _meetingTimeEnd, value); }
        }

        public Command SaveMeetingCommand { get; set; }
        public Command DeleteMeetingCommand { get; set; }

        public MeetingDetailViewModel(Meeting meeting)
        {
            SaveMeetingCommand = new Command(async () => await SaveMeeting());
            DeleteMeetingCommand = new Command(async () => await DeleteMeeting());
            Meeting = meeting;
            MeetingTimeStart = DateTime.ParseExact(Meeting.TimeStart, "yyyy.MM.dd HH:mm", CultureInfo.InvariantCulture)
                .TimeOfDay;
            MeetingTimeEnd = DateTime.ParseExact(Meeting.TimeEnd, "yyyy.MM.dd HH:mm", CultureInfo.InvariantCulture)
                .TimeOfDay;
        }

        private async Task DeleteMeeting()
        {
            await MeetingDataStore.DeleteMeetingAsync(Meeting.Id);
        }

        private async Task SaveMeeting()
        {
            var date = DateTime.ParseExact(Meeting.TimeStart, "yyyy.MM.dd HH:mm", CultureInfo.InvariantCulture).Date;
            Meeting.TimeStart = (date + MeetingTimeStart).ToString("yyyy.MM.dd HH:mm", CultureInfo.InvariantCulture);
            Meeting.TimeEnd = (date + MeetingTimeEnd).ToString("yyyy.MM.dd HH:mm", CultureInfo.InvariantCulture);
            if (Meeting.Id == 0)
            {
                await MeetingDataStore.AddMeetingAsync(Meeting);
            }
            else
            {
                await MeetingDataStore.UpdateMeetingAsync(Meeting);
            }
        }
    }
}
