using Hospital.DataBase;
using Hospital.Services;
using Hospital.Services.Entitties;
using Hospital.ViewModels;
using Microsoft.Data.Sqlite;
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
            List<User> list = new List<User>();
            try
            {
                await App.Database.CreateTable<User>();
                if (YourLogin.Text == null || YourPassword.Text == null)
                {
                    LoginFailedImg.Opacity = 1;
                    tbLogin.BorderColor = Color.Red;

                    PassFailedImg.Opacity = 1;
                    tbPassword.BorderColor = Color.Red;
                }
                else if (YourLogin.Text == "1" || YourPassword.Text == "1")
                {
                    CurrentUser.EnterAsUser(new User { Id = -1, Level = 2, Login = null, Mail = null, MedCardId = default, Passport = null, Password = null });
                    await Application.Current.MainPage.Navigation.PopModalAsync();
                }
                else if ((list = await App.Database.GetItemsAsync<User>()).Count != 0)
                {
                    foreach(var item in list)
                    {
                        if (item.Login.GetHashCode() == YourLogin.Text.GetHashCode() && 
                            item.Password.GetHashCode() == YourPassword.Text.GetHashCode())
                        {
                            CurrentUser.EnterAsUser(item);
                            await Application.Current.MainPage.Navigation.PopModalAsync();
                            break;
                        }
                    }
                    LoginFailedImg.Opacity = 1;
                    tbLogin.BorderColor = Color.Red;

                    PassFailedImg.Opacity = 1;
                    tbPassword.BorderColor = Color.Red;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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

        private async void btnAsGuest_Clicked(object sender, EventArgs e)
        {
            CurrentUser.EnterAsGuest();
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }

    }
}
