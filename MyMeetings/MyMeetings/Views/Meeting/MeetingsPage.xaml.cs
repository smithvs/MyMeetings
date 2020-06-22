using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMeetings.Models.BaseMeeting;
using MyMeetings.Models.Meetings;
using MyMeetings.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyMeetings.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MeetingsPage : ContentPage
    {

        MeetingsViewModel ViewModel=> BindingContext as MeetingsViewModel;

        public MeetingsPage()
        {
            InitializeComponent();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new MeetingDetailPage(new MeetingDetailViewModel(new Meeting() { TimeStart = ViewModel.ActualDay, TimeEnd = ViewModel.ActualDay}))));
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            meetingList.SelectedItem = null;
            ViewModel.MeetingOnActualDayUpdate();
        }

        async void OnItemSelected(object sender, EventArgs args)
        {
            if (meetingList.SelectedItem != null)
                await Navigation.PushModalAsync(new NavigationPage(new MeetingDetailPage(new MeetingDetailViewModel(meetingList.SelectedItem as Meeting))));
        }
    }
}