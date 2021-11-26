using Hospital.Services.Entitties;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using SQLite;
using System.Text;

namespace Hospital.DataBase
{
    public static class DataBaseSettings
    {
        public const string connectionString = @"Data Source=E:\Work\Startup\Hospital\Hospital\Hospital\DataBase\Users.db";

        public static SqliteConnection connection;
    }
}
