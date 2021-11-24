using Hospital.Services.Client;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Hospital.Models
{
    class ClientClickModel : IClientClickModel
    {
        public string Response { get; set; }
        public void OnClick()
        {
            Response = TcpClient.GetResponse("#322228");
        }
    }
}
