using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Models
{
    public interface IClientClickModel
    {
        void OnClick(string code);
        string Response { get; set; }
    }
}
