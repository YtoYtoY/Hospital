using Hospital.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hospital.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
            this.BindingContext = new RegistrationPageViewModel();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            LoginFailedImg.Opacity = 1;
            tbLogin.BorderColor = Color.Red;

            PasNumFailedImg.Opacity = 1;
            tbPasportNumber.BorderColor = Color.Red;

            EmailFailedImg.Opacity = 1;
            tbEmail.BorderColor = Color.Red;

            PassFailedImg.Opacity = 1;
            tbPassword.BorderColor = Color.Red;

            PassAgainFailedImg.Opacity = 1;
            tbPasswordAgain.BorderColor = Color.Red;
            Application.Current.MainPage.Navigation.PopModalAsync();
            Application.Current.MainPage.Navigation.PopModalAsync();
            // TODO: Проверки на корректность введённых данных. Доп проверки. 
        }

        private void YourLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            LoginFailedImg.Opacity = 0;
            tbLogin.BorderColor = Color.DarkGray;
        }

        private void PasportNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            PasNumFailedImg.Opacity = 0;
            tbPasportNumber.BorderColor = Color.DarkGray;
        }

        private void Email_TextChanged(object sender, TextChangedEventArgs e)
        {
            EmailFailedImg.Opacity = 0;
            tbEmail.BorderColor = Color.DarkGray;
        }

        private void YourPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            PassFailedImg.Opacity = 0;
            tbPassword.BorderColor = Color.DarkGray;
            PassAgainFailedImg.Opacity = 0;
            tbPasswordAgain.BorderColor = Color.DarkGray;
        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            YourPassword.IsPassword = !YourPassword.IsPassword;
        }
    }
}