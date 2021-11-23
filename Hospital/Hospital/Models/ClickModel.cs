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
            App.Current.MainPage.Navigation.PushModalAsync(page);
        }

        public void Reset()
        {
            
        }
    }
}
