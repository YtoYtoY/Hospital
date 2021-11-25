using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Services.Entitties
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public int MedCardId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public int Level { get; set; }
        public string Passport { get; set; }
    }
}
