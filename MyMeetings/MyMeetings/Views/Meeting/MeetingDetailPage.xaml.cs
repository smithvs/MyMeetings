using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMeetings.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyMeetings.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MeetingDetailPage : ContentPage
    {
        public MeetingDetailPage(MeetingDetailViewModel meetingDetailViewModel)
        {
            InitializeComponent();
            BindingContext = meetingDetailViewModel;
        }

        private void SaveButton_OnClicked(object sender, EventArgs e)
        {
            var bc = BindingContext as MeetingDetailViewModel;
            if (bc.Meeting.TimeStart.TimeOfDay >= bc.Meeting.TimeEnd.TimeOfDay)
                DisplayAlert("Ошибка данных", "Время начала встречи не может быть позже времени окончания", "Ок");
            else if (bc.Meeting.Title is null || bc.Meeting.Title.Length == 0)
                DisplayAlert("Ошибка данных", "Заголовок должен быть заполнен", "Ок");
            else if (bc.Meeting.Client is null || bc.Meeting.Client.Length == 0)
                DisplayAlert("Ошибка данных", "Участник встречи должен быть заполнен", "Ок");
            else
                Navigation.PopModalAsync();
        }

        private void CancelButton_OnClicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void DeleteButton_OnClicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}