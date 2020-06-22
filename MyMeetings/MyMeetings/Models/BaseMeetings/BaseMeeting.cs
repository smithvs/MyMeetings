using System;
using System.Collections.Generic;
using System.Text;
using MyMeetings.Models.BaseMeetings;

namespace MyMeetings.Models.BaseMeeting
{
    public class BaseMeeting: BaseMeetingInfo
    {
        public string Client { get; set; }

        public string Place { get; set; }

        public DateTime PeriodDateStart { get; set; }

        public DateTime PeriodDateEnd { get; set; }

        public DateTime MeetingTimeStart { get; set; }

        public DateTime MeetingTimeEnd { get; set; }

        public int DayWeek { get; set; }

        public int? Type { get; set; }

        public string Notation { get; set; }

        public decimal? Income { get; set; }
    }
}
