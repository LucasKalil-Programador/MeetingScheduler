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

namespace MeetingScheduler.Components
{
    public partial class MeetingCreator : UserControl
    {

        private LocationUserRequest request = new();

        public MeetingCreator()
        {
            InitializeComponent();
            locationButton.Click += (s, a) => request.ShowDialog();
            IsEnabledChanged += (s, a) => OnEnabledChange();
        }

        public void OnEnabledChange()
        {
            if (IsEnabled)
            {
                request = new();
            }
        }
    }
}
