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
        public Detail()
        {
            InitializeComponent();
            this.BindingContext = new MenuPageViewModel();   
                
        }


        public async void Start()
        {
            var card = await App.Database.GetItemAsync<MedCard>(CurrentUser.CurUser.MedCardId);

            if (card != null)
            {
                Name.Text = card.Name.Split(' ')[0];
                Surname.Text = card.Name.Split(' ')[1];
                Birth.Text = card.Birth.ToString();
                Address.Text = card.Address;
            }

            var listin = new List<Appointment>();
            foreach (var item in await App.Database.GetItemsAsync<Appointment>())
            {
                if (item.UserId == CurrentUser.CurUser.Id && DateTime.Parse(item.Time) > DateTime.Now)
                {
                    listin.Add(item);
                }
            }
            if (listin.Count != 0)
            {

                Grid grid = new Grid
                {
                    RowDefinitions =
                    {
                        new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
                    },
                    ColumnDefinitions =
                    {
                        new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                        new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                        new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
                    }
                };
                grid.BackgroundColor = Color.LightGray;
                grid.Margin = 10;
                grid.Children.Add(new Label { Text = "Time", TextColor = Color.DarkGray }, 0, 0);
                grid.Children.Add(new Label { Text = "Info", TextColor = Color.DarkGray }, 1, 0);
                grid.Children.Add(new Label { Text = "Status", TextColor = Color.DarkGray }, 2, 0);
                for (int i = 0, k = 1; i < listin.Count; i++)
                {
                    if (listin[i].UserId == CurrentUser.CurUser.Id)
                    {
                        Label time = new Label();
                        Label doc = new Label();
                        Label stat = new Label();

                        time.Text = listin[i].Time;
                        doc.Text = (await App.Database.GetItemAsync<Doctors>(listin[i].DoctorId) as Doctors).Name;
                        if (listin[i].Status == 1)
                            stat.Text = "Waiting";
                        else
                            stat.Text = "Close";

                        grid.Children.Add(time, 0, k);
                        grid.Children.Add(doc, 1, k);
                        grid.Children.Add(stat, 2, k);
                        k++;
                    }
                    grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                    dgvAppointment.Children.Add(grid);
                }
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}