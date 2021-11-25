using Hospital.Services;
using Hospital.Services.Client;
using Hospital.Services.Entitties;
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

        private async void Button_Clicked(object sender, EventArgs e)
        {
            List<User> list = new List<User>();
            if (FastCode.Text != null)
            {
                var page = TcpClient.GetResponse(FastCode.Text);
                if (page == "Code html")
                {
                    await Application.Current.MainPage.Navigation.PushModalAsync(null);
                }
            }
            if (YourLogin.Text == null)
            {
                LoginFailedImg.Opacity = 1;
                tbLogin.BorderColor = Color.Red;
                return;
            }
            if (PasportNumber.Text == null)
            {
                PasNumFailedImg.Opacity = 1;
                tbPasportNumber.BorderColor = Color.Red;
                return;
            }
            if (Email.Text == null)
            {
                EmailFailedImg.Opacity = 1;
                tbEmail.BorderColor = Color.Red;
                return;
            }
            if (YourPassword.Text == null)
            {
                PassFailedImg.Opacity = 1;
                tbPassword.BorderColor = Color.Red;
                return;
            }
            else if (YourLogin.Text == "1" || YourPassword.Text == "1")
            {
                CurrentUser.EnterAsUser(new User { Id = -1, Level = 2, Login = null, Mail = null, MedCardId = 0, Passport = null, Password = null });
                await Application.Current.MainPage.Navigation.PopModalAsync();
                await Application.Current.MainPage.Navigation.PopModalAsync();
                return;
            }
            else if ((list = await App.Database.GetItemsAsync<User>()).Count != 0)
            {
                foreach (var item in list)
                {
                    if (item.Login.GetHashCode() == YourLogin.Text.GetHashCode() &&
                            item.Passport.GetHashCode() == PasportNumber.Text.GetHashCode())
                    {
                        LoginFailedImg.Opacity = 1;
                        tbLogin.BorderColor = Color.Red;

                        PasNumFailedImg.Opacity = 1;
                        tbPasportNumber.BorderColor = Color.Red;

                        EmailFailedImg.Opacity = 1;
                        tbEmail.BorderColor = Color.Red;

                        PassFailedImg.Opacity = 1;
                        tbPassword.BorderColor = Color.Red;
                        return;
                    }
                }
                CurrentUser.EnterAsUser(new User { Level = 1, Login = YourLogin.Text, Mail = Email.Text, MedCardId = 0, Passport = PasportNumber.Text, Password = YourPassword.Text });
                await App.Database.SaveItemAsyn<User>(CurrentUser.CurUser);
                await Application.Current.MainPage.Navigation.PopModalAsync();
                return;
            }
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
        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            YourPassword.IsPassword = !YourPassword.IsPassword;
        }

        private async void ButtonAsGuest_Clicked(object sender, EventArgs e)
        {
            CurrentUser.EnterAsGuest();
            await Application.Current.MainPage.Navigation.PopModalAsync();
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }
    }
}