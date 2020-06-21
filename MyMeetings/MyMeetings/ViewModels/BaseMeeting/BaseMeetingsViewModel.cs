using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMeetings.Models;
using MyMeetings.Models.BaseMeeting;
using MyMeetings.Views;
using Xamarin.Forms;

namespace MyMeetings.ViewModels
{
    public class BaseMeetingsViewModel: BaseViewModel
    {
        public ObservableCollection<BaseMeeting> BaseMeetingOnActualDay { get; set; }

        int _actualDay = (int)DateTime.Now.DayOfWeek;
        public int ActualDay
        {
            get { return _actualDay; }
            set { SetProperty(ref _actualDay, value); }
        }

        public Command NextDayCommand { get; set; }
        public Command PrevDayCommand { get; set; }
        public Command AddBaseMeetingCommand { get; set; }



        public Command LoadItemsCommand { get; set; }
        

        public BaseMeetingsViewModel()
        {
            Title = "Расписание";
            BaseMeetingOnActualDay = new ObservableCollection<BaseMeeting>();
            BaseMeetingOnActualDayUpdate();
            NextDayCommand = new Command(async () => await NextDay());
            PrevDayCommand = new Command(async () => await PreviousDay());
            AddBaseMeetingCommand = new Command(async () => await AddBaseMeeting());

            //MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            //{
            //    var newItem = item as Item;
            //    Items.Add(newItem);
            //    await DataStore.AddItemAsync(newItem);
            //});
        }

        private async Task AddBaseMeeting()
        {
            
        }

        private async Task PreviousDay()
        {
            ActualDay = ActualDay == 0 ? 6 : ActualDay - 1;
            await BaseMeetingOnActualDayUpdate();


        }

        private async Task NextDay()
        {
            ActualDay = ActualDay == 6 ? 0 : ActualDay + 1;
            await BaseMeetingOnActualDayUpdate();
        }

        public async Task BaseMeetingOnActualDayUpdate()
        {
            BaseMeetingOnActualDay.Clear();
            var baseMeetings = await BaseMeetingDataStore.GetBaseMeetingsAsync(true);
            baseMeetings = baseMeetings.Where(bm => bm.DayWeek == _actualDay);
            foreach (var item in baseMeetings)
            {
                BaseMeetingOnActualDay.Add(item);
            }
        }
    }
}
