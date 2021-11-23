using Hospital.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Hospital.Models
{
    class ClickModel : ITransportClickModel
    {

        public void OnClick(ContentPage page)
        {
            Application.Current.MainPage.Navigation.PushModalAsync(page);
        }

        public void Reset()
        {
            Application.Current.MainPage.Navigation.PopModalAsync();
        }
    }
}
