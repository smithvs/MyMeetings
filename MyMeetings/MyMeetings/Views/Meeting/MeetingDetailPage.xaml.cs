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