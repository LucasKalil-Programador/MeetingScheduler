using MySql.Data.MySqlClient;
using System;
using System.Data;
using MeetingScheduler.Objects;

namespace MeetingScheduler
{
    public static class DB
    {
        public const string password = "admin";
        public const string DataBaseName = "meetingscheduler_db";
        public const string ConnectionString = $"server=localhost;uid=root;database={DataBaseName};pwd={password}";

        private static readonly Lazy<MySqlConnection> connection = new(DB.CreateNewConnection);

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

        #region Client

        public static bool InsertClient(Client client, string password)
        {
            lock (connection)
            {
                if (ExistsClientByName(client.Name)) return false;
                string command =
                    "Insert into Client (name, password, document, phone, email, office) " +
                    $"values ('{client.Name}', '{password.GetHashCode()}', '{client.Document}', '{client.Phone}', '{client.Email}', '{client.Office}');";
                Console.WriteLine(command);
                MySqlCommand cmd = new(command, connection.Value);
                int rows = cmd.ExecuteNonQuery();
                return rows == 1;
            }
        }

        public static Client SelectClientByNameAndPassword(string name, string password)
        {
            lock (connection)
            {
                Client client = default;
                string command = $"select * from client where name='{name}' and password='{password.GetHashCode()}';";
                Console.WriteLine(command);
                MySqlCommand cmd = new(command, connection.Value);
                MySqlDataReader Reader = cmd.ExecuteReader();
                while (Reader.Read())
                {
                    client = new Clientfactory()
                        .SetId(int.Parse(Reader.GetString(0)))
                        .SetName(Reader.GetString(1))
                        .SetDocument(Reader.GetString(3))
                        .SetPhone(Reader.GetString(4))
                        .SetEmail(Reader.GetString(5))
                        .SetOffice(Reader.GetString(6))
                        .Build();
                }
                Reader.Close();

                return client;
            }
        }

        public static bool ExistsClientByName(string name)
        {
            lock (connection)
            {
                string command = $"select count(*) from client where name = '{name}';";
                MySqlCommand cmd = new(command, connection.Value);
                MySqlDataReader Reader = cmd.ExecuteReader();
                Reader.Read();
                int count = Reader.GetInt32(0);
                Reader.Close();
                return count >= 1;
            }
        }

        #endregion Client
    }
}
