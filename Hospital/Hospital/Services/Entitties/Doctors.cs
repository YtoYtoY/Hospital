using Microsoft.Data.Sqlite;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Services.Entitties
{
    [Table("Doctors")]
    public class Doctors : IEntity
    {
        [PrimaryKey, AutoIncrement, Column("d_id")]
        public int Id { get; set; }
        [Column("d_fio")]
        public string Name { get; set; }
        [Column("d_specialization")]
        public string Specialization { get; set; }
        [Column("d_start")]
        public DateTime? StartTime { get; set; }
        [Column("d_end")]
        public DateTime? EndTime { get; set; }


        public void SetData(SqliteDataReader reader)
        {
            Id = Convert.ToInt32(reader.GetValue(0));
            Name = reader.GetValue(1).ToString();
            Specialization = reader.GetValue(2).ToString();
            StartTime = Convert.ToDateTime(reader.GetValue(3));
            EndTime = Convert.ToDateTime(reader.GetValue(4));
        }
    }
}
