using Hospital.Models;
using Hospital.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Hospital.ViewModels
{
    class RegistrationPageViewModel : BaseViewModel
    {
        private ITransportClickModel clickModel;
        public ICommand GoToLogin { get; private set; }
        public ICommand GoToMenuValidation { get; private set; }

        public RegistrationPageViewModel()
        {
            GoToLogin = new Command(OnButtonClick_ToLogin);

            clickModel = new ClickModel();

        }

        private void OnButtonClick_ToLogin()
        {
            clickModel.Reset();
            //NotyfyPropertyChanged(nameof(ClicksCount));
        }
    }
}
