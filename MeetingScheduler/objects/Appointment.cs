﻿using System;

namespace MeetingScheduler.objects
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
    }

    public class AppointmentFactory
    {
        private int Id = -1;
        private Client? Client = null;
        private DateTime StartDateTime = default;
        private DateTime EndDateTime = default;
        private string Reason = string.Empty;

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