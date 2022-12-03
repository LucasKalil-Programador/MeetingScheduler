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

        private Brush validBrush;

        public MeetingCreator()
        {
            InitializeComponent();
            locationButton.Click += (s, a) => OnLocationButtonClick();
            validBrush = nameTextBox.Background;
        }

        public void OnLocationButtonClick()
        {
            localRequest.ShowDialog();
            if (localRequest.ResultLocation != default)
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
            dateRequest.calendar.SetLocationAndParticipants(location, clients);
            dateRequest.ShowDialog();
            if (dateRequest.resultDateTime != default)
            {
                dateTime = dateRequest.resultDateTime;
                dateTimeButton.Content = $"Data selecionada: {dateTime}";
            }
            dateRequest = new();
        }

        private void OnUsersButtonClick(object sender, RoutedEventArgs e)
        {
            teamRequest.ShowDialog();
            if (teamRequest.resultClients.Length > 0)
            {
                clients = teamRequest.resultClients;
                usersButton.Content = $"{clients.Length} usuarios selecionados";
            }
            teamRequest = new(clients);
            dateTime = default;
            dateTimeButton.IsEnabled = location != default && clients.Length > 0;
        }

        private void OnCreateButtonClick(object sender, RoutedEventArgs e)
        {
            if (IsValidData())
            {
                Meeting meeting = new MeetingFactory()
                    .SetStartDateTime(dateTime)
                    .SetEndDateTime(dateTime.AddHours(1))
                    .SetParticipants(clients)
                    .SetLocation(location)
                    .SetDescription(descriptionTextBox.GetText().Trim())
                    .SetSubject(subjectTextBox.Text)
                    .SetName(nameTextBox.Text)
                    .SetPriority(priorityListBox.SelectedIndex)
                    .Build();
                
                if (DB.InsertMeeting(meeting))
                {
                    MessageBox.Show("Sucesso ao agendar reuniao", "Sucesso");
                    Clear();
                }
                else
                {
                    MessageBox.Show("Erro ao agendar reuniao", "Error");
                }
            }
        }

        private bool IsValidData()
        {
            Brush errorColor = new SolidColorBrush(Color.FromRgb(255, 100, 100));
            bool locationValid = true;
            if (location == default)
            {
                locationButton.Background = errorColor;
                locationValid = false;
            }
            else
            {
                locationButton.Background = validBrush;
            }

            bool teamValid = true;
            if (clients.Length == 0)
            {
                usersButton.Background = errorColor;
                teamValid = false;
            }
            else
            {
                usersButton.Background = validBrush;
            }

            bool dateValid = true;
            if (dateTime == default)
            {
                dateTimeButton.Background = errorColor;
                dateValid = false;
            }
            else
            {
                dateTimeButton.Background = validBrush;
            }

            if (string.IsNullOrWhiteSpace(descriptionTextBox.GetText()))
            {
                descriptionTextBox.Background = errorColor;
            }
            else
            {
                descriptionTextBox.Background = validBrush;
            }

            return nameTextBox.IsValidInput(@"\w(\w| )+", validBrush) &
                subjectTextBox.IsValidInput(@"\w(\w| )+", validBrush) &
                !string.IsNullOrWhiteSpace(descriptionTextBox.GetText()) &
                priorityListBox.SelectedItem != null &
                locationValid && teamValid && dateValid;
        }

        private void Clear()
        {
            priorityListBox.SelectedIndex = 1;
            nameTextBox.Clear();
            subjectTextBox.Clear();
            descriptionTextBox.Document.Blocks.Clear();
            clients = Array.Empty<Client>();
            location = default;
            dateTime = default;
            localRequest = new();
            dateRequest = new();
            teamRequest = new(Array.Empty<Client>());
        }
    }
}
