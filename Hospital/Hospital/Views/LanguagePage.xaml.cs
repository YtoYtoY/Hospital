using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hospital.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LanguagePage : ContentPage
    {
        public LanguagePage()
        {
            InitializeComponent();
        }

        private void ChangeLangToRU_Clicked(object sender, EventArgs e)
        {
            Settings.Lang = CultureInfo.CreateSpecificCulture("ru");
        }

        private void ChangeLangToENG_Clicked(object sender, EventArgs e)
        {
            Settings.Lang = CultureInfo.CreateSpecificCulture("en");
        }
    }
}