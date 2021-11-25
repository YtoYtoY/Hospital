using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Services.Entitties
{
    public class Doctors : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
