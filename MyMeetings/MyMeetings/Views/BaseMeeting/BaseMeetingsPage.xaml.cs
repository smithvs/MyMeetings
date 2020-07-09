using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMeetings.Models.BaseMeeting;
using MyMeetings.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyMeetings.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BaseMeetingsPage : ContentPage
    {

        BaseMeetingsViewModel ViewModel=> BindingContext as BaseMeetingsViewModel;
        public BaseMeetingsPage()
        {
            InitializeComponent();
        }
        private void Button_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new BaseMeetingDetailPage(new BaseMeetingDetailViewModel(new BaseMeeting() { DayWeek = ViewModel.ActualDay}))));
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            baseMeetingList.SelectedItem = null;
            await ViewModel.BaseMeetingOnActualDayUpdate();
        }

        async void OnItemSelected(object sender, EventArgs args)
        {
            if (baseMeetingList.SelectedItem != null)
                await Navigation.PushModalAsync(new NavigationPage(new BaseMeetingDetailPage(new BaseMeetingDetailViewModel(baseMeetingList.SelectedItem as BaseMeeting))));
        }

        private async void Setting_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new SettingsPage()));
        }
    }
}