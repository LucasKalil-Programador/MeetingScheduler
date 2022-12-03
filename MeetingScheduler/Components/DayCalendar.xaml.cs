using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MeetingScheduler.Objects;

namespace MeetingScheduler.Components
{
    public partial class DayCalendar : UserControl
    {

        private Brush NormalButtonBackGround;

        private DateTime date = default;
        private Location location = default;
        private Client[] clients = Array.Empty<Client>();

        public Action<string> OnHourClick = (hour) => { };

        public DayCalendar()
        {
            InitializeComponent();
            NormalButtonBackGround = Background;
            foreach (var control in stackPanel.Children)
            {
                if (control is Button button)
                {
                    button.Click += OnHour_Click;
                    NormalButtonBackGround = button.Background;
                }
            }
        }

        private void OnHour_Click(object sender, RoutedEventArgs args)
        {
            if (sender is Button button)
            {
                if (button.Background != NormalButtonBackGround)
                {
                    return;
                }
                OnHourClick.Invoke((string)button.Content);
            }
        }

        public void SetDate(DateTime date)
        {
            this.date = date;
            foreach (var control in stackPanel.Children)
            {
                if (control is Button button)
                {
                    string time = (string)button.Content;
                    string[] timeSplited = time.Split(":");
                    int hour = int.Parse(timeSplited[0]);
                    int minute = int.Parse(timeSplited[1]);

                    DateTime dateTime = new(date.Year, date.Month, date.Day, hour, minute, 0);
                    if (dateTime < DateTime.Now)
                    {
                        button.IsEnabled = false;
                    }
                }
            }
            CheckLocationIsOcuped();
            CheckClientIsOcuped();
        }

        public void SetLocationAndParticipants(Location location, Client[] clients)
        {
            this.clients = clients;
            this.location = location;
            CheckLocationIsOcuped();
            CheckClientIsOcuped();
        }

        private void CheckClientIsOcuped()
        {
            if (clients.Length > 0 && date != default)
            {
                foreach (var control in stackPanel.Children)
                {
                    if (control is Button button)
                    {
                        string time = (string)button.Content;
                        string[] timeSplited = time.Split(":");
                        int hour = int.Parse(timeSplited[0]);
                        int minute = int.Parse(timeSplited[1]) + 30;

                        DateTime dateTime = new(date.Year, date.Month, date.Day, hour, minute, 0);
                        foreach (var client in clients)
                        {
                            button.Background = DB.ClientIsOcupedAtDate(client, dateTime) ?
                                (button.Background == Brushes.Yellow ? Brushes.Purple : Brushes.Blue) : 
                                (button.Background == Brushes.Yellow ? Brushes.Yellow : NormalButtonBackGround);
                        }
                    }
                }
            }
        }

        private void CheckLocationIsOcuped()
        {
            if (location != default && date != default)
            {
                foreach (var control in stackPanel.Children)
                {
                    if (control is Button button)
                    {
                        string time = (string)button.Content;
                        string[] timeSplited = time.Split(":");
                        int hour = int.Parse(timeSplited[0]);
                        int minute = int.Parse(timeSplited[1]) + 30;

                        DateTime dateTime = new(date.Year, date.Month, date.Day, hour, minute, 0);
                        button.Background = DB.LocationIsOcupedAtDate(location, dateTime) ?
                            Brushes.Yellow : NormalButtonBackGround;
                    }
                }
            }
        }
    }
}
