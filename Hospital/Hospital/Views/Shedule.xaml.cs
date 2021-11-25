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

        private void Button_Clicked(object sender, EventArgs e)
        {
            lblDacName.IsVisible = true;
            dgvAppointment.Children.Clear();

            DateTime date = DateTime.Now;                           // TODO: Текущая дата
            for (int i = 0; i < 7; i++)
            {
                DateTime start = DateTime.Now;                      // TODO: Дата начала приема у доктора
                DateTime end = start.AddHours(8);                   // TODO: Дата окончания приема у доктора

                Label day = new Label();
                day.Text = date.ToString("d");
                day.TextColor = Color.Black;
                day.FontSize = 19;
                day.HorizontalTextAlignment = TextAlignment.Center;
                dgvAppointment.Children.Add(day);
                
                if (date.DayOfWeek != DayOfWeek.Saturday || date.DayOfWeek != DayOfWeek.Sunday)
                {
                    while ((start.Minute % 5) != 0)
                    {
                        start = start.AddMinutes(1);
                    }
                    while ((end.Hour - start.Hour) > 0)             // TODO: найти уже записаных пользователей
                    {
                        Button button = new Button();
                        button.Clicked += TimeButton_Clicked;
                        button.Text = start.ToString("t");
                        button.WidthRequest = 15;
                        button.HeightRequest = 45;
                        button.CornerRadius = 40;
                        button.TextColor = Color.FromHex("#02bfa9");// TODO: Сделать у кнопки id
                        button.Margin = 15;
                        button.FontSize = 18;
                        dgvAppointment.Children.Add(button);

                        start = start.AddMinutes(15);
                    }
                }
                date = date.AddDays(1);
                
            }
            VisibleBox.IsVisible = true;
        }

        private void TimeButton_Clicked(object sender, EventArgs e)// TODO: испольщовать id кнопки для создания записи в бд
        {
            
        }
    }
}