using Hospital.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Hospital.Views
{

    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new MainPageViewModel();
        }

        private void PasswordCheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            YourPassword.IsPassword = !YourPassword.IsPassword;
        }

        private async void btnSingIn_Clicked(object sender, EventArgs e)
        {
            if (YourLogin.Text != "1") // TODO: Проверить пользователя на подлиность. Доп проверки
            {
                LoginFailedImg.Opacity = 1;
                tbLogin.BorderColor = Color.Red;

                PassFailedImg.Opacity = 1;
                tbPassword.BorderColor = Color.Red;
            }
            else
            {
                await Application.Current.MainPage.Navigation.PopModalAsync();
            }
        }

        private void YourLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            LoginFailedImg.Opacity = 0;
            tbLogin.BorderColor = Color.DarkGray;
        }

        private void YourPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            PassFailedImg.Opacity = 0;
            tbPassword.BorderColor = Color.DarkGray;
        }

        private void btnAsGuest_Clicked(object sender, EventArgs e)
        {
            // Guest
        }

    }
}
