using Hospital.Services;
using Hospital.Services.Entitties;
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
    public partial class Procedure : ContentPage
    {
        public Procedure()
        {
            InitializeComponent();
            Start();
        }

        private async void Start()
        {
            var diagList = new List<Diagnosis>();

            foreach (var item in await App.Database.GetItemsAsync<Diagnosis>())
            {
                if (item.CardId == 0)//CurrentUser.CurUser.MedCardId)
                {
                    diagList.Add(item);
                }
            }
            if (diagList.Count != 0)
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
                        new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
                    }
                };

                grid.BackgroundColor = Color.LightGray;
                grid.Margin = 10;
                grid.Children.Add(new Label { Text = "Title", TextColor = Color.DarkGray }, 0, 0);
                grid.Children.Add(new Label { Text = "Info", TextColor = Color.DarkGray }, 1, 0);

                for (int i = 0, k = 1; i < diagList.Count; i++)
                {
                    Label title = new Label();
                    Label info = new Label();

                    title.Text = diagList[i].Title;
                    title.TextColor = Color.Black;
                    title.FontSize = 18;
                    info.Text = diagList[i].Info;
                    info.TextColor = Color.Black;
                    info.FontSize = 18;


                    grid.Children.Add(title, 0, k);
                    grid.Children.Add(info, 1, k);
                    k++;

                    grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                    dgvDiagnosis.Children.Add(grid);
                }
            }
        }
    }
}