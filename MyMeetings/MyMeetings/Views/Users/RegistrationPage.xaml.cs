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
    public partial class RegistrationPage : ContentPage
    {
        RegistrationViewModel ViewModel => BindingContext as RegistrationViewModel;
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void Entry_OnCompleted(object sender, EventArgs e)
        {
            ViewModel.PasswordCheckCommand.Execute(new object());
        }
    }
}