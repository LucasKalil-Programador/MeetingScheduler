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
        private Location location = default;
        private DateTime dateTime = default;

        public MeetingCreator()
        {
            InitializeComponent();
            locationButton.Click += (s, a) => OnLocationButtonClick();
            IsEnabledChanged += (s, a) => OnEnabledChange();
        }

        public void OnEnabledChange()
        {
            if (IsEnabled)
            {
                localRequest = new();
                dateRequest = new();
                locationButton.Content = "Adionar local";
            }
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
        }

        private void OnDateTimeButtonClick(object sender, RoutedEventArgs e)
        {
            dateRequest.ShowDialog();
            if(dateRequest.resultDateTime != default)
            {
                dateTime = dateRequest.resultDateTime;
                dateTimeButton.Content = $"Data selecionada: {dateTime.ToString()}";
            }
            dateRequest = new();
        }
    }
}
