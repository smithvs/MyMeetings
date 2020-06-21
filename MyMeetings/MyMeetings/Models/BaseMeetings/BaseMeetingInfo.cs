using System;
using System.Collections.Generic;
using System.Text;

namespace MyMeetings.Models.BaseMeetings
{
    public class BaseMeetingInfo
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int UserId { get; set; }

        public string CreatedAt { get; set; }

        public string LastUpdatedAt { get; set; }
    }
}
