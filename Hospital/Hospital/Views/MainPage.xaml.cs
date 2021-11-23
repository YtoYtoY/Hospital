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

        private async void Button_Clicked(object sender, EventArgs e)
        {
            LoginFailedImg.Opacity = 1;
            tbLogin.BorderColor = Color.Red;
            PassFailedImg.Opacity = 1;
            tbPassword.BorderColor = Color.Red;
            await Application.Current.MainPage.Navigation.PopModalAsync();
            // TODO: Проверить пользователя на подлиность. Вывести модальное окно в случае отказа. Доп проверки
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

    }
}
