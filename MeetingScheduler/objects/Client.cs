namespace MeetingScheduler.Objects
{
    public struct Client
    {
        public readonly int Id;
        public readonly string Name;
        public readonly string Document;
        public readonly string Phone;
        public readonly string Email;
        public readonly string Office;

        public Client(int id, string name, string document, string phone, string email, string office)
        {
            this.Id = id;
            this.Name = name;
            this.Document = document;
            this.Phone = phone;
            this.Email = email;
            this.Office = office;
        }
    }

    public class Clientfactory
    {
        public int Id = -1;
        public string Name = string.Empty;
        public string Document = string.Empty;
        public string Phone = string.Empty;
        public string Email = string.Empty;
        public string Office = string.Empty;

        public Client Build() => new(Id, Name, Document, Phone, Email, Office);

        public Clientfactory SetId(int id)
        {
            this.Id = id;
            return this;
        }

        public Clientfactory SetName(string name)
        {
            this.Name = name;
            return this;
        }

        public Clientfactory SetDocument(string document)
        {
            this.Document = document;
            return this;
        }

        public Clientfactory SetPhone(string phone)
        {
            this.Phone = phone;
            return this;
        }

        public Clientfactory SetEmail(string email)
        {
            this.Email = email;
            return this;
        }

        public Clientfactory SetOffice(string office)
        {
            this.Office = office;
            return this;
        }
    }
}
