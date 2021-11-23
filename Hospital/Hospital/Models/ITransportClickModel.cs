using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Hospital.Models
{
    public interface ITransportClickModel
    {
        void OnClick(ContentPage page);
        void Reset();
    }
}
