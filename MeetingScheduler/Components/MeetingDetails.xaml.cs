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
    public partial class MeetingDetails : UserControl
    {
        public MeetingDetails()
        {
            InitializeComponent();
            calendar.OnOcupedDateClick += (date) => Console.WriteLine(date);
        }

        public void SetClient(Client client)
        {
            calendar.SetLocationAndParticipants(default, new Client[] { client });
        }
    }
}
