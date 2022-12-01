using System;
using System.Collections.Generic;

namespace MeetingScheduler.Objects
{
    public struct Appointment
    {
        public int Id;
        public Client Client;
        public DateTime StartDateTime;
        public DateTime EndDateTime;
        public string Reason;

        public Appointment(int iD, Client client, DateTime startDateTime, DateTime endDateTime, string reason)
        {
            this.Id = iD;
            this.Client = client;
            this.StartDateTime = startDateTime;
            this.EndDateTime = endDateTime;
            this.Reason = reason;
        }

        public override bool Equals(object? obj)
        {
            return obj is Appointment appointment &&
                   Id == appointment.Id &&
                   EqualityComparer<Client>.Default.Equals(Client, appointment.Client) &&
                   StartDateTime == appointment.StartDateTime &&
                   EndDateTime == appointment.EndDateTime &&
                   Reason == appointment.Reason;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Client, StartDateTime, EndDateTime, Reason);
        }

        public static bool operator ==(Appointment left, Appointment right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Appointment left, Appointment right)
        {
            return !left.Equals(right);
        }
    }

    public class AppointmentFactory
    {
        public int Id = -1;
        public Client? Client = null;
        public DateTime StartDateTime = default;
        public DateTime EndDateTime = default;
        public string Reason = string.Empty;

        public Appointment Build() => new(Id, Client.Value, StartDateTime, EndDateTime, Reason);

        public bool IsValid()
        {
            return Id != -1 &&
                   Client.HasValue &&
                   StartDateTime != default &&
                   EndDateTime != default &&
                   Reason != string.Empty;
        }

        public AppointmentFactory SetId(int id)
        {
            this.Id = id;
            return this;
        }

        public AppointmentFactory SetId(Client client)
        {
            this.Client = client;
            return this;
        }

        public AppointmentFactory SetStartDateTime(DateTime startDateTime)
        {
            this.StartDateTime = startDateTime;
            return this;
        }

        public AppointmentFactory SetEndDateTime(DateTime endDateTime)
        {
            this.EndDateTime = endDateTime;
            return this;
        }

        public AppointmentFactory SetId(string reason)
        {
            this.Reason = reason;
            return this;
        }
    

    }
}
