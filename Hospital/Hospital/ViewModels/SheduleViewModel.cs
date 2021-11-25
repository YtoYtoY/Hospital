using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Hospital.ViewModels
{
    class SheduleViewModel : BaseViewModel
    {
        private ITransportClickModel clickModel;

        public ICommand GetInfoByDoctor { get; private set; }

        public SheduleViewModel()
        {
            GetInfoByDoctor = new Command(OnButtonClick_GetInfoByDoctor);
            clickModel = new ClickModel();

        }

        private void OnButtonClick_GetInfoByDoctor()
        {

        }
    }
}
