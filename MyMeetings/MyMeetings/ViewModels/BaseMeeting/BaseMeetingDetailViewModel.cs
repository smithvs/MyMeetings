using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MyMeetings.Models.BaseMeeting;
using MyMeetings.Views;
using Xamarin.Forms;

namespace MyMeetings.ViewModels
{
    public class BaseMeetingDetailViewModel:BaseViewModel
    {
        private BaseMeeting _baseMeeting;

        public Command SaveCommand { get; set; }
        public Command DeleteBaseMeetingCommand { get; set; }

        public BaseMeeting BMeeting
        {
            get { return _baseMeeting; }
            set { SetProperty(ref _baseMeeting, value); }
        }

        public BaseMeetingDetailViewModel(BaseMeeting baseMeeting)
        {
            SaveCommand = new Command(async () => await SaveBaseMeeting());
            DeleteBaseMeetingCommand = new Command(async () => await DeleteBaseMeeting());
            BMeeting = baseMeeting;
        }

        private async Task DeleteBaseMeeting()
        {
            await BaseMeetingDataStore.DeleteBaseMeetingAsync(BMeeting.Id);
        }

        private async Task SaveBaseMeeting()
        {
            if (BMeeting.MeetingTimeEnd.TimeOfDay >= BMeeting.MeetingTimeEnd.TimeOfDay)
                
            if (BMeeting.Id == 0)
            {
                await BaseMeetingDataStore.AddBaseMeetingAsync(BMeeting);
                await MeetingDataStore.AddMeetingsFromBaseAsync(BMeeting);
            }
            else
            {
                await BaseMeetingDataStore.UpdateBaseMeetingAsync(BMeeting);
            }
        }
    }
}
