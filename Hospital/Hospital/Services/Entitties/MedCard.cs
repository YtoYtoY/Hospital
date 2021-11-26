using Microsoft.Data.Sqlite;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Services.Entitties
{
    [Table("Cards")]
    public class MedCard : IEntity
    {
        [PrimaryKey, AutoIncrement, Column("c_id")]
        public int Id { get; set; }
        [Column("u_id")]
        public int UserId { get; set; }
        [Column("c_fio")]
        public string Name { get; set; }
        [Column("c_adress")]
        public string Address { get; set; }
        [Column("c_birth")]
        public string Birth { get; set; }

    }


}
