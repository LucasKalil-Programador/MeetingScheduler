using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace MeetingScheduler
{
    public static class DB
    {
        public const string password = "admin";
        public const string DataBaseName = "meetingscheduler_db";
        public const string ConnectionString = $"server=localhost;uid=root;database={DataBaseName};pwd={password}";

        private static readonly Lazy<MySqlConnection> connection = new Lazy<MySqlConnection>(DB.CreateNewConnection);

        private static MySqlConnection CreateNewConnection()
        {
            MySqlConnection connection = new(ConnectionString);
            connection.Open();
            return connection;
        }

        public static string Ping()
        {
            string status = connection.Value.Ping() ? "Ok" : "Error";
            return $"Status {status}";     
        }
    }
}
