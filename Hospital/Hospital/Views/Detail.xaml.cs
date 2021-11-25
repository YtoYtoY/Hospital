using Hospital.Services;
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
    public partial class Detail : ContentPage
    {
        List<Appointment> list { get; set; }
        public Detail()
        {
            InitializeComponent();
            this.BindingContext = new MenuPageViewModel();

            Start();
            if (list != null)
            {
                foreach(var item in list)
                {
                    dgvAppointment.Children.Add(new Label { Text = "sdfsfdsdcf" });
                }
            }
        }


        public async void Start()
        {
            var listin = new List<Appointment>();
            foreach (var item in await App.Database.GetItemsAsync<Appointment>())
            {
                if (item.UserId == CurrentUser.CurUser.Id && item.Time > DateTime.Now)
                {
                    listin.Add(item);
                }
            }
            list = listin;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}