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
    public partial class Shedule : ContentPage
    {
        public Shedule()
        {
            InitializeComponent();
            this.BindingContext = new SheduleViewModel();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            lblDacName.IsVisible = true;
            dgvAppointment.Children.Clear();

            DateTime start;
            DateTime end;
            bool find = false;

            Doctors doctors = new Doctors();
            if (Name.Text == null)
            {
                lblDacName.Text = "Not Found!";
                return;
            }
            foreach (var item in await App.Database.GetItemsAsync<Doctors>())
            {
                if (item.Name.Contains(Name.Text))
                {
                    doctors = item;
                    find = true;
                    break;
                }
            }
            if (!find)
            {
                lblDacName.Text = "Not Found!";
            }
            else
            {
                lblDacName.Text = doctors.Name;
                start = (DateTime)doctors.StartTime;
                end = (DateTime)doctors.EndTime;
                List<DateTime> closedDates = new List<DateTime>();

                DateTime date = DateTime.Now;
                foreach (var item in await App.Database.GetItemsAsync<Appointment>())
                {
                    if (item.DoctorId == doctors.Id && item.Time > DateTime.Now)
                    {
                        closedDates.Add((DateTime)item.Time);
                    }
                }
                for (int i = 0; i < 7; i++)
                {

                    Label day = new Label();
                    day.Text = date.ToString("d");
                    day.TextColor = Color.Black;
                    day.FontSize = 19;
                    day.HorizontalTextAlignment = TextAlignment.Center;
                    dgvAppointment.Children.Add(day);

                    if (date.DayOfWeek != DayOfWeek.Saturday || date.DayOfWeek != DayOfWeek.Sunday)
                    {
                        while ((start.Minute % 30) != 0)
                        {
                            start = start.AddMinutes(1);
                        }
                        while ((end.Hour - start.Hour) > 0)
                        {
                            
                            Button button = new Button();
                            button.Clicked += TimeButton_Clicked;
                            button.Text = start.ToString("t");
                            button.WidthRequest = 15;
                            button.HeightRequest = 45;
                            button.CornerRadius = 40;
                            button.Margin = 15;
                            button.FontSize = 18;
                            foreach (var dat in closedDates)
                            {
                                if (dat.Day == start.Day && dat.Hour == start.Hour && dat.Minute == start.Minute)
                                {
                                    button.IsEnabled = false;
                                    button.IsVisible = false;
                                    break;
                                }
                            }
                            button.TextColor = Color.FromHex("#02bfa9");
                            dgvAppointment.Children.Add(button);

                            start = start.AddMinutes(15);
                        }
                    }
                    date = date.AddDays(1);

                }
                VisibleBox.IsVisible = true;
            }
        }

        private void TimeButton_Clicked(object sender, EventArgs e)
        {
            
        }
    }
}