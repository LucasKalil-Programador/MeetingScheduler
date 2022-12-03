using System;
using System.Collections.Generic;

namespace MeetingScheduler.Objects
{
    public struct Meeting
    {
        public readonly int Id;
        public readonly DateTime StartDateTime;
        public readonly DateTime EndDateTime;
        public readonly Client[] Participants;
        public readonly Location Location;
        public readonly string Description;
        public readonly string Subject;
        public readonly string Name;
        public readonly int Priority;

        public Meeting(int id, DateTime startDateTime, DateTime endDateTime, Client[] participants, Location location, string description, string subject, string name, int priority)
        {
            Id = id;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            Participants = participants;
            Location = location;
            Description = description;
            Subject = subject;
            Name = name;
            Priority = priority;
        }



        public override bool Equals(object? obj)
        {
            return obj is Meeting meeting &&
                   Id == meeting.Id &&
                   StartDateTime == meeting.StartDateTime &&
                   EndDateTime == meeting.EndDateTime &&
                   EqualityComparer<Client[]>.Default.Equals(Participants, meeting.Participants) &&
                   EqualityComparer<Location>.Default.Equals(Location, meeting.Location) &&
                   Description == meeting.Description &&
                   Subject == meeting.Subject &&
                   Name == meeting.Name &&
                   Priority == meeting.Priority;
        }

        public override int GetHashCode()
        {
            HashCode hash = new();
            hash.Add(Id);
            hash.Add(StartDateTime);
            hash.Add(EndDateTime);
            hash.Add(Participants);
            hash.Add(Location);
            hash.Add(Description);
            hash.Add(Subject);
            hash.Add(Name);
            hash.Add(Priority);
            return hash.ToHashCode();
        }

        public static bool operator ==(Meeting left, Meeting right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Meeting left, Meeting right)
        {
            return !left.Equals(right);
        }
    }

    public class MeetingFactory
    {
        public int Id = -1;
        public DateTime StartDateTime = default;
        public DateTime EndDateTime = default;
        public Client[] Participants = Array.Empty<Client>();
        public Location? Location = null;
        public string Description = string.Empty;
        public string Subject = string.Empty;
        public string Name = string.Empty;
        public int Priority = -1;

        public Meeting Build() => new(Id, StartDateTime, EndDateTime, Participants, Location.Value, Description, Subject, Name, Priority);

        public bool IsValid()
        {
            return Id != -1 &&
                   StartDateTime != default &&
                   EndDateTime != default &&
                   Participants.Length != 0 &&
                   Location.HasValue &&
                   Description != string.Empty &&
                   Subject != string.Empty &&
                   Name != string.Empty &&
                   Priority != -1;
        }

        public MeetingFactory SetId(int id)
        {
            this.Id = id;
            return this;
        }

        public MeetingFactory SetStartDateTime(DateTime startDateTime)
        {
            this.StartDateTime = startDateTime;
            return this;
        }

        public MeetingFactory SetEndDateTime(DateTime endDateTime)
        {
            this.EndDateTime = endDateTime;
            return this;
        }

        public MeetingFactory SetParticipants(Client[] participants)
        {
            this.Participants = participants;
            return this;
        }

        public MeetingFactory SetLocation(Location location)
        {
            this.Location = location;
            return this;
        }

        public MeetingFactory SetDescription(string description)
        {
            this.Description = description;
            return this;
        }

        public MeetingFactory SetSubject(string subject)
        {
            this.Subject = subject;
            return this;
        }

        public MeetingFactory SetName(string name)
        {
            this.Name = name;
            return this;
        }

        public MeetingFactory SetPriority(int priority)
        {
            this.Priority = priority;
            return this;
        }
    }
}
