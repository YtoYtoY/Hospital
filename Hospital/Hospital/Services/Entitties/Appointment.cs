using Microsoft.Data.Sqlite;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Services.Entitties
{
    [Table("Appointment")]
    public class Appointment : IEntity
    {
        [PrimaryKey, AutoIncrement, Column("a_id")]
        public int Id { get; set; }
        [Column("u_id")]
        public int? UserId { get; set; }
        [Column("d_id")]
        public int? DoctorId { get; set; }
        [Column("start_time")]
        public DateTime? Time { get; set; }
        [Column("a_status")]
        public int? Status { get; set; }

        public void SetData(SqliteDataReader reader)
        {
            Id = Convert.ToInt32(reader.GetValue(0));
            UserId = Convert.ToInt32(reader.GetValue(1));
            DoctorId = Convert.ToInt32(reader.GetValue(2));
            Time = Convert.ToDateTime(reader.GetValue(3));
            Status = Convert.ToInt32(reader.GetValue(4));
        }
    }
}
