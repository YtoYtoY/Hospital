using Microsoft.Data.Sqlite;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital.Services.Entitties
{
    [Table("Diagnosis")]
    public class Diagnosis : IEntity
    {
        [PrimaryKey, AutoIncrement, Column("diagn_id")]
        public int Id { get; set; }
        [Column("c_id")]
        public int CardId { get; set; }
        [Column("diagn_title")]
        public string Title { get; set; }
        [Column("diagn_info")]
        public string Info { get; set; }

    }
}
