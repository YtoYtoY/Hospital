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


        public static List<T> Select<T>(string query) where T: IEntity, new()
        {
            var db = new SQLiteConnection(connectionString);
            List<T> result = new List<T>();
            try
            {
                using (var connection = new SqliteConnection(DataBaseSettings.connectionString))
                {
                    connection.Open();
                    SqliteCommand command = new SqliteCommand();
                    command.Connection = connection;
                    command.CommandText = query;

                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                T obj = new T();
                                obj.SetData(reader);

                                result.Add(obj);
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public static int Insert(string query)
        {
            int number = 0;
            using (var connection = new SqliteConnection(DataBaseSettings.connectionString))
            {
                connection.Open();
                SqliteCommand command = new SqliteCommand();
                command.Connection = connection;
                command.CommandText = query;
                number = command.ExecuteNonQuery();
            }
            return number;
        }
    }
}
