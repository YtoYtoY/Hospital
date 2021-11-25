using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Services.Entitties
{
    public class Diagnosis : IEntity
    {
        public int Id { get; set; }
        public int CardId { get; set; }
        public string Title { get; set; }
        public string Info { get; set; }
    }
}
