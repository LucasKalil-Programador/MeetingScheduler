using System;
using System.Windows;

namespace MeetingScheduler.OtherWindows
{
    public partial class DateTimeUserRequest : Window
    {
        public DateTime resultDateTime = default;

        public DateTimeUserRequest()
        {
            InitializeComponent();
            calendar.OnDateClick += (date) =>
            {
                resultDateTime = date;
                Close();
            };
        }
    }
}
