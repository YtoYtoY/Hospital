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
    public partial class Shedule : ContentPage
    {

        private Doctors doctor { get; set; }
        public Shedule()
        {
            InitializeComponent();
            this.BindingContext = new SheduleViewModel();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            lblDacName.IsVisible = true;
            dgvAppointment.Children.Clear();
            bool find = false;


            List<DateTime> closedDates = new List<DateTime>();

            if (Name.Text == null)
            {
                lblDacName.Text = "Not Found!";
                return;
            }
            var docList = await App.Database.GetItemsAsync<Doctors>();
            foreach (var item in docList)
            {
                if (item.Name.Contains(Name.Text))
                {
                    doctor = item;
                    find = true;
                    break;
                }
            }
            var appointments = await App.Database.GetItemsAsync<Appointment>();
            foreach (var item in appointments)
            {
                if (item.DoctorId == doctor.Id && DateTime.Parse(item.Time) > DateTime.Now)
                {
                    closedDates.Add(DateTime.Parse(item.Time));
                }
            }

            if (!find)
            {
                lblDacName.Text = "Not Found!";
            }
            else
            {
                lblDacName.Text = doctor.Name;

                DateTime date = DateTime.Now;
                for (int i = 0; i < 10;)
                {
                    var start = DateTime.Parse(doctor.StartTime);
                    var end = DateTime.Parse(doctor.EndTime);
                    StackLayout stackLayout = new StackLayout();

                    if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
                    {
                        Label day = new Label();
                        day.Text = date.ToString("d");
                        day.TextColor = Color.Black;
                        day.FontSize = 20;
                        day.HorizontalTextAlignment = TextAlignment.Center;
                        stackLayout.Children.Add(day);

                        while ((start.Minute % 30) != 0)
                        {
                            start = start.AddMinutes(1);
                        }
                        while ((end.Hour - start.Hour) > 0)
                        {
                           
                            Button button = new Button();
                            
                            button.Clicked += TimeButton_Clicked;
                            button.Text = start.ToString();
                            button.WidthRequest = 15;
                            button.HeightRequest = 45;
                            button.CornerRadius = 40;
                            button.Margin = 15;
                            button.FontSize = 18;
                            button.TextColor = Color.FromHex("#02bfa9");
                            foreach (var dat in closedDates)
                            {
                                if (dat.Day == date.Day && dat.Hour == start.Hour && dat.Minute == start.Minute)
                                {
                                    button.IsEnabled = false;
                                    button.BackgroundColor = Color.LightGray;
                                    button.BorderColor = Color.Red;
                                    button.TextColor = Color.Red;
                                    break;
                                }
                            }
                            stackLayout.Children.Add(button);

                            start = start.AddMinutes(15);
                        }
                        i++;
                    }
                    date = date.AddDays(1);
                    dgvAppointment.Children.Add(stackLayout);
                }
                VisibleBox.IsVisible = true;
            }
        }

        private async void TimeButton_Clicked(object sender, EventArgs e)
        {
            if (CurrentUser.CurUser.Level == -1)
            {
                bool result = await DisplayAlert("To get started, you need to register", "Do you want to go to the registration form?", "Yes", "No");
                if (result)
                {
                    await App.Current.MainPage.Navigation.PushModalAsync(new MainPage());
                }
            }
            else
            {
                var date = (sender as Button).Text.Split(' ')[0];
                var time = (sender as Button).Text.Split(' ')[1];

                DateTime datetime = DateTime.Parse(date + " " + time);


                var item = new Appointment { Id = 0, DoctorId = doctor.Id, Status = 1, Time = datetime.ToString(), UserId = CurrentUser.CurUser.Id };
                var tmp = await App.Database.SaveItemAsyn(item);
                await DisplayAlert("Request accepted", "+", "Ok");
            }
        }
    }
}