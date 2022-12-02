using MySql.Data.MySqlClient;
using System;
using System.Data;
using MeetingScheduler.Objects;
using MeetingScheduler;
using System.Collections.Generic;

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
                    $"values ('{client.Name}', '{Utils.HashPassword(password)}', '{client.Document}', '{client.Phone}', '{client.Email}', '{client.Office}');";
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
                string command = $"select * from client where name='{name}' and password='{Utils.HashPassword(password)}';";
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

        public static Client[] SelectAllClients()
        {
            lock (connection)
            {
                List<Client> clients = new List<Client>();
                string command = $"select * from client;";
                MySqlCommand cmd = new(command, connection.Value);
                MySqlDataReader Reader = cmd.ExecuteReader();
                while (Reader.Read())
                {
                    clients.Add(new Clientfactory()
                        .SetId(int.Parse(Reader.GetString(0)))
                        .SetName(Reader.GetString(1))
                        .SetDocument(Reader.GetString(3))
                        .SetPhone(Reader.GetString(4))
                        .SetEmail(Reader.GetString(5))
                        .SetOffice(Reader.GetString(6))
                        .Build());
                }
                Reader.Close();

                return clients.ToArray();
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

        #region Location

        public static bool InsertLocation(Location location)
        {
            lock (connection)
            {
                string command =
                    "Insert into Location (name, address, cep, capacity, room) " +
                    $"values ('{location.Name}','{location.Address}','{location.Cep}', {location.Capacity},'{location.Room}');";
                MySqlCommand cmd = new(command, connection.Value);
                int rows = cmd.ExecuteNonQuery();
                return rows == 1;
            }
        }

        public static Location[] SelectAllLocations()
        {
            lock (connection)
            {
                List<Location> locations = new();
                string command = $"select * from location;";
                MySqlCommand cmd = new(command, connection.Value);
                MySqlDataReader Reader = cmd.ExecuteReader();
                while (Reader.Read())
                {
                    locations.Add(new LocationFactory()
                        .SetId(Reader.GetInt32(0))
                        .SetName(Reader.GetString(1))
                        .SetAddress(Reader.GetString(2))
                        .SetCep(Reader.GetString(3))
                        .SetCapacity(Reader.GetInt32(4))
                        .SetRoom(Reader.GetString(5))
                        .Build());
                }
                Reader.Close();

                return locations.ToArray();
            }
        }

        #endregion Location
    }
}
