using System;

namespace MeetingScheduler.Objects
{
    public struct Location
    {
        public readonly int Id;
        public readonly string Name;
        public readonly string Address;
        public readonly string Cep;
        public readonly int Capacity;
        public readonly string Room;

        public Location(int id, string name, string address, string cep, int capacity, string room)
        {
            this.Id = id;
            this.Name = name;
            this.Address = address;
            this.Cep = cep;
            this.Capacity = capacity;
            this.Room = room;
        }

        public override bool Equals(object? obj)
        {
            return obj is Location location &&
                   Id == location.Id &&
                   Name == location.Name &&
                   Address == location.Address &&
                   Cep == location.Cep &&
                   Capacity == location.Capacity &&
                   Room == location.Room;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Address, Cep, Capacity, Room);
        }

        public static bool operator ==(Location left, Location right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Location left, Location right)
        {
            return !left.Equals(right);
        }
    }

    public class LocationFactory
    {
        public int Id = -1;
        public string Name = string.Empty;
        public string Address = string.Empty;
        public string Cep = string.Empty;
        public int Capacity = -1;
        public string Room = string.Empty;

        public Location Build() => new(Id, Name, Address, Cep, Capacity, Room);

        public bool IsValid()
        {
            return Id != -1 && 
                   Name != string.Empty && 
                   Address != string.Empty && 
                   Cep != string.Empty && 
                   Capacity != -1 && 
                   Room != string.Empty;
        }

        public LocationFactory SetId(int id)
        {
            this.Id = id;
            return this;
        }

        public LocationFactory SetName(string name)
        {
            this.Name = name;
            return this;
        }

        public LocationFactory SetAddress(string address)
        {
            this.Address = address;
            return this;
        }

        public LocationFactory SetCep(string cep)
        {
            this.Cep = cep;
            return this;
        }

        public LocationFactory SetCapacity(int capacity)
        {
            this.Capacity = capacity;
            return this;
        }

        public LocationFactory SetRoom(string room)
        {
            this.Room = room;
            return this;
        }
    }
}
