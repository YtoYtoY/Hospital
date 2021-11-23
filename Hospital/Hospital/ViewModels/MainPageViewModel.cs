using Hospital.Models;
using Hospital.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Hospital.ViewModels
{
    class MainPageViewModel : BaseViewModel
    {
        private ITransportClickModel clickModel;
        public ICommand GoToRegistration { get; private set; }
        public ICommand GoToMenuValidation { get; private set; }

        public MainPageViewModel()
        {
            GoToRegistration = new Command(OnButtonClick_ToRegistration);

            GoToMenuValidation = new Command(OnButtonClick_ToMenu);
            clickModel = new ClickModel();

        }

        private void OnButtonClick_ToRegistration()
        {
            clickModel.OnClick(new RegistrationPage());
            //NotyfyPropertyChanged(nameof(ClicksCount));
        }

        private void OnButtonClick_ToMenu()
        {
            clickModel.OnClick(new MenuPage());
        }
    }
}
