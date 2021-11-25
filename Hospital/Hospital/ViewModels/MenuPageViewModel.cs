using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Hospital.ViewModels
{
    class MenuPageViewModel : BaseViewModel
    {
        private IClientClickModel clickModel;
        public ICommand GetResponse { get; private set; }
        public string Response { get; private set; }

        public MenuPageViewModel()
        {
            GetResponse = new Command(OnButtonClick_GetResponse);
            clickModel = new ClientClickModel();
        }

        private void OnButtonClick_GetResponse()
        {
            clickModel.OnClick();
            Response = clickModel.Response;
            NotyfyPropertyChanged(nameof(Response));

        }
    }
}
