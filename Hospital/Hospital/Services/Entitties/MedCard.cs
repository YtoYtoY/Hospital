using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Services.Entitties
{
    public class MedCard : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
