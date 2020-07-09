using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMeetings.Models;
using MyMeetings.Services;
using Xamarin.Forms;

namespace MyMeetings.ViewModels
{
    public class IncomeViewModel:BaseViewModel
    {
        private Income _income;
        public Income IncomeInfo
        {
            get { return _income; }
            set { SetProperty(ref _income, value); }
        }

        public Command GetIncomeCommand { get; set; }

        public IncomeViewModel()
        {
            _income = new Income() { DateStart = DateTime.Now, DateEnd = DateTime.Now };
            GetIncomeCommand = new Command(async () => await GetIncome());
        }

        private async Task GetIncome()
        {
            var meetings = MeetingDataStore.GetMeetingsAsync().Result.Where(m=>m.TimeStart.Date>=IncomeInfo.DateStart.Date && m.TimeStart.Date<=IncomeInfo.DateEnd.Date);
            IncomeInfo.TotalIncome = meetings.Select(m => m.Income).Sum(m => m.Value);
            IncomeInfo.CountMeetingWithIncome = meetings.Where(m => m.Income != null).Count();
        }
    }
}
