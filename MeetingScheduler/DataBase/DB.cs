using MeetingScheduler.Objects;
using MySql.Data.MySqlClient;
using System;
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
                List<Client> clients = new();
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

        public static bool ClientIsOcupedAtDate(Client client, DateTime dateTime)
        {
            int count = -1;
            lock (connection)
            {
                string command = "select count(*) from client inner join client_has_meeting, Meeting where " +
                    "client.idClient=client_has_meeting.Client and client_has_meeting.Meeting=meeting.idMeeting and " +
                    $"client.idClient={client.Id} and '{dateTime.ToMySQLDateTimeFormat()}' BETWEEN meeting.start_date_time and meeting.end_date_time;";
                MySqlCommand cmd = new(command, connection.Value);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    count = reader.GetInt32("count(*)");
                }
                reader.Close();
            }
            return count > 0;
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

        public static Location SelectAllLocationsWhereID(int id)
        {
            lock (connection)
            {
                Location location = default;
                string command = $"select * from location where idlocation;";
                MySqlCommand cmd = new(command, connection.Value);
                MySqlDataReader Reader = cmd.ExecuteReader();
                while (Reader.Read())
                {
                    location = new LocationFactory()
                        .SetId(Reader.GetInt32(0))
                        .SetName(Reader.GetString(1))
                        .SetAddress(Reader.GetString(2))
                        .SetCep(Reader.GetString(3))
                        .SetCapacity(Reader.GetInt32(4))
                        .SetRoom(Reader.GetString(5))
                        .Build();
                }
                Reader.Close();

                return location;
            }
        }

        public static bool LocationIsOcupedAtDate(Location location, DateTime dateTime)
        {
            int count = -1;
            lock (connection)
            {
                string command = "Select count(*) from location " +
                           $"inner join meeting where location.idLocation=meeting.Location and " +
                           $"{location.Id}=location.idLocation and" +
                           $"'{dateTime.ToMySQLDateTimeFormat()}' BETWEEN meeting.start_date_time AND meeting.end_date_time;";
                MySqlCommand cmd = new(command, connection.Value);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    count = reader.GetInt32("count(*)");
                }
                reader.Close();
            }
            return count > 0;
        }


        #endregion Location

        #region Meeting

        public static bool InsertMeeting(Meeting meeting)
        {
            lock (connection)
            {
                string command = "Insert Into Meeting " +
                    "(start_date_time, end_date_time, Location, description, subject, name, priority)" +
                    $"values ('{meeting.StartDateTime.ToMySQLDateTimeFormat()}', " +
                    $"'{meeting.EndDateTime.ToMySQLDateTimeFormat()}', " +
                    $"{meeting.Location.Id}, '{meeting.Description}', '{meeting.Subject}', " +
                    $"'{meeting.Name}', {meeting.Priority});";
                MySqlCommand cmd = new(command, connection.Value);
                int rows = cmd.ExecuteNonQuery();
            }


            int id = SelectIdFromMeeting(meeting);
            if (id != -1)
            {
                foreach (var client in meeting.Participants)
                {
                    InsertMeetingHasClient(id, client.Id);
                }
            }
            return id != -1;
        }

        public static bool InsertMeetingHasClient(int meetingId, int clientId)
        {
            lock (connection)
            {
                string command = $"Insert Into client_has_meeting (Client, Meeting) values ({clientId}, {meetingId})";
                MySqlCommand cmd = new(command, connection.Value);
                int rows = cmd.ExecuteNonQuery();
                return rows == 1;
            }
        }

        public static Meeting SelectMeetingFromMeeting(Client client, DateTime dateTime)
        {
            MeetingFactory factory = new();
            int locationID = 0;
            lock (connection)
            {
                string command = "select * from meeting inner join client_has_meeting, client where " +
                    "client.idClient=client_has_meeting.Client and client_has_meeting.Meeting=meeting.idMeeting and " +
                    $"client.idClient={client.Id} and '{dateTime.ToMySQLDateTimeFormat()}' BETWEEN meeting.start_date_time and meeting.end_date_time;";
                MySqlCommand cmd = new(command, connection.Value);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    factory
                        .SetId(reader.GetInt32(0))
                        .SetStartDateTime(reader.GetDateTime(1))
                        .SetEndDateTime(reader.GetDateTime(2))
                        .SetDescription(reader.GetString(4))
                        .SetSubject(reader.GetString(5))
                        .SetName(reader.GetString(6))
                        .SetPriority(reader.GetInt32(7));
                    locationID = reader.GetInt32(3);
                }
                reader.Close();
            }
            factory.SetLocation(SelectAllLocationsWhereID(locationID));


            return factory.Build();
        }

        public static int SelectIdFromMeeting(Meeting meeting)
        {
            int id = -1;
            lock (connection)
            {
                string command = $"Select idmeeting from meeting where " +
                    $"start_date_time='{meeting.StartDateTime.ToMySQLDateTimeFormat()}' and " +
                    $"end_date_time='{meeting.EndDateTime.ToMySQLDateTimeFormat()}' and " +
                    $"Location={meeting.Location.Id} and " +
                    $"description='{meeting.Description}' and " +
                    $"subject='{meeting.Subject}' and " +
                    $"name='{meeting.Name}' and " +
                    $"priority={meeting.Priority};";
                MySqlCommand cmd = new(command, connection.Value);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    id = reader.GetInt32("idmeeting");
                }
                reader.Close();
            }
            return id;
        }

        #endregion Meeting
    }
}
