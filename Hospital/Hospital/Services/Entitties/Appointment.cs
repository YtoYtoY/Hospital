using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Services.Entitties
{
    public class Appointment : IEntity
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? DiagnosisId { get; set; }
        public DateTime? Time { get; set; }
        public int? status { get; set; }
    }
}
