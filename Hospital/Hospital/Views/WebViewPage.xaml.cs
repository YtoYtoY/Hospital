using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Hospital.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WebViewPage : ContentPage
    {

        //public int PageId { get; set; }

        //private string _path = Path.Combine(Hospital.Hospital.Android.);

        public WebViewPage(StringBuilder page)
        {
            InitializeComponent();
            //try
            //{
            //    using (FileStream fs = File.Create(_path, 4096))
            //    {
            //        Byte[] info = new UTF8Encoding(true).GetBytes(page.ToString());
            //        fs.Write(info, 0, info.Length);
            //    }

            Web.Source = @"E:\Work\Startup\Hospital\Server\#123456.html";
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}
        }
    }
}