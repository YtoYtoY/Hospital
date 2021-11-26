using Hospital.Services;
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
    public partial class MenuPage : MasterDetailPage
    {
        
        public MenuPage()
        {
            InitializeComponent();
            this.Master = new Master();
            var detail = new Detail();
            CurrentUser.start += detail.Start;
            this.Detail = new NavigationPage(detail);

            App.MasterDetail = this;

            this.BindingContext = new MenuPageViewModel();
        } 
    }
}