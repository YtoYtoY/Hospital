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
    public partial class Master : ContentPage
    {
        public Master()
        {
            InitializeComponent();
        }

        private void btnMedCard_Clicked(object sender, EventArgs e)
        {
            App.MasterDetail.IsPresented = false;
        }



        private async void btnSchedule_Clicked(object sender, EventArgs e)
        {
            App.MasterDetail.IsPresented = false;
            await App.MasterDetail.Detail.Navigation.PushAsync(new Shedule());
        }

        private async void btnProcedure_Clicked(object sender, EventArgs e)
        {
            App.MasterDetail.IsPresented = false;
            await App.MasterDetail.Detail.Navigation.PushAsync(new Procedure());
        }

        private async void btnSettings_Clicked(object sender, EventArgs e)
        {
            App.MasterDetail.IsPresented = false;
            await App.MasterDetail.Detail.Navigation.PushAsync(new Settings());
        }

        private void btnExit_Clicked(object sender, EventArgs e)
        {
            App.MasterDetail.IsPresented = false;
            System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
        }
    }
}