using MeetingScheduler.Objects;
using System;
using System.Windows.Controls;

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
