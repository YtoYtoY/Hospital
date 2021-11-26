using Microsoft.Data.Sqlite;
using SQLite;
using System;

namespace Hospital.Services.Entitties
{
    [Table("Users")]
    public class User : IEntity
    {
        [PrimaryKey, AutoIncrement, Column("u_id")]
        public int Id { get; set; }
        [Column("c_id")]
        public int MedCardId { get; set; }
        [Column("u_login")]
        public string Login { get; set; }
        [Column("u_password")]
        public string Password { get; set; }
        [Column("u_mail")]
        public string Mail { get; set; }
        [Column("u_level")]
        public int Level { get; set; }
        [Column("u_passport")]
        public string Passport { get; set; }

      
    }
}
