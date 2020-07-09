using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace MyMeetings.Models
{
    public class Income:INotifyPropertyChanged
    {
        public int UserId { get; set; }


        private DateTime _dateStart = DateTime.Now;

        /// <summary>
        /// Начало периода формирования дохода
        /// </summary>
        public DateTime DateStart
        {
            get { return _dateStart; }
            set { SetProperty(ref _dateStart, value); }
        }

        private DateTime _dateEnd = DateTime.Now;
        /// <summary>
        /// Конец периода формирования дохода
        /// </summary>
        public DateTime DateEnd
        {
            get { return _dateEnd; }
            set { SetProperty(ref _dateEnd, value);
            }
        }

        private decimal _totalIncome = 0;
        /// <summary>
        /// Сумма
        /// </summary>
        public decimal TotalIncome
        {
            get { return _totalIncome; }
            set { SetProperty(ref _totalIncome, value); }
        }

        private int _count = 0;
        /// <summary>
        /// Количество встреч с доходом
        /// </summary>
        public int CountMeetingWithIncome
        {
            get { return _count; }
            set { SetProperty(ref _count, value);
            }
        }
        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }


        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
