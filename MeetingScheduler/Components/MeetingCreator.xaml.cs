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
        private LocationUserRequest request = new();
        private Location location = default;

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
                request = new();
                locationButton.Content = "Adionar local";
            }
        }

        public void OnLocationButtonClick()
        {
            request.ShowDialog();
            if(request.ResultLocation != default)
            {
                location = request.ResultLocation;
                locationButton.Content = $"Local: {location.Name} Sala: {location.Room}";
            }
            request = new();
        }
    }
}
