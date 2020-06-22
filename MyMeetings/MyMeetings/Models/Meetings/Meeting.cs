using System;
using System.Collections.Generic;
using System.Text;

namespace MyMeetings.Models.Meetings
{
    public class Meeting : MeetingsInfo
    {
        /// <summary>
        /// Дополнительная информация о встрече
        /// </summary>
        public string Notation { get; set; }

        /// <summary>
        /// Id шаблона, если встреча создана из него
        /// </summary>
        public int? IdTemplate { get; set; }

        /// <summary>
        /// Предполагаемый доход
        /// </summary>
        public decimal? Income { get; set; }

        /// <summary>
        /// Дата начала встречи
        /// </summary>
        public DateTime TimeStart { get; set; }

        /// <summary>
        /// Дата конца встречи
        /// </summary>
        public DateTime TimeEnd { get; set; }

        /// <summary>
        /// Метка, которая говорит о том, отменена ли встреча
        /// </summary>
        public bool? IsCanceled { get; set; }

        /// <summary>
        /// Место, где проходит встреча
        /// </summary>
        public string Place { get; set; }

        /// <summary>
        /// Клиент, с которым проходит встреча
        /// </summary>
        public string Client { get; set; }
    }
}
