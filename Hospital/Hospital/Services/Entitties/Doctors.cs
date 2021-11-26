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
        public string StartTime { get; set; }
        [Column("d_end")]
        public string EndTime { get; set; }

    }
}
