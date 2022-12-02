using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using MeetingScheduler.OtherWindows;
using MeetingScheduler.Objects;

namespace MeetingScheduler.Components
{
    public partial class MeetingCreator : UserControl
    {
        private LocationUserRequest localRequest = new();
        private DateTimeUserRequest dateRequest = new();
        private TeamUserRequest teamRequest = new(Array.Empty<Client>());

        private Client[] clients = Array.Empty<Client>();
        private Location location = default;
        private DateTime dateTime = default;

        public MeetingCreator()
        {
            InitializeComponent();
            locationButton.Click += (s, a) => OnLocationButtonClick();
        }

        public void OnLocationButtonClick()
        {
            localRequest.ShowDialog();
            if(localRequest.ResultLocation != default)
            {
                location = localRequest.ResultLocation;
                locationButton.Content = $"Local: {location.Name} Sala: {location.Room}";
            }
            localRequest = new();
            dateTime = default;
            dateTimeButton.IsEnabled = location != default && clients.Length > 0;
        }

        private void OnDateTimeButtonClick(object sender, RoutedEventArgs e)
        {
            dateRequest.ShowDialog();
            if(dateRequest.resultDateTime != default)
            {
                dateTime = dateRequest.resultDateTime;
                dateTimeButton.Content = $"Data selecionada: {dateTime}";
            }
            dateRequest = new();
        }

        private void OnUsersButtonClick(object sender, RoutedEventArgs e)
        {
            teamRequest.ShowDialog();
            if(teamRequest.resultClients.Length > 0)
            {
                clients = teamRequest.resultClients;
                usersButton.Content = $"{clients.Length} usuarios selecionados";
            }
            teamRequest = new(clients);
            dateTime = default;
            dateTimeButton.IsEnabled = location != default && clients.Length > 0;
        }
    }
}
