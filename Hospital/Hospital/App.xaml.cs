using Hospital.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hospital
{
    public partial class App : Application
    {
        public static MasterDetailPage MasterDetail { get; set; }
        public App()
        {
            InitializeComponent();
            MainPage = new MenuPage();
            MainPage.Navigation.PushModalAsync(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
