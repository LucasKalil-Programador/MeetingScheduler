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

namespace MeetingScheduler.Components
{
    /// <summary>
    /// Interação lógica para DayCalendar.xam
    /// </summary>
    public partial class DayCalendar : UserControl
    {

        public Action<string> OnHourClick = (hour) => { };

        public DayCalendar()
        {
            InitializeComponent();
            foreach (var control in stackPanel.Children)
            {
                if (control is Button button)
                {
                    button.Click += OnHour_Click;
                }
            }
        }

        private void OnHour_Click(object sender, RoutedEventArgs args)
        {
            if (sender is Button button)
            {
                OnHourClick.Invoke((string)button.Content);
            }
        }

        public void SetDate(DateTime date)
        {
            foreach (var control in stackPanel.Children)
            {
                if (control is Button button)
                {
                    string time = (string)button.Content;
                    string[] timeSplited = time.Split(":");
                    int hour = int.Parse(timeSplited[0]);
                    int minute = int.Parse(timeSplited[1]);

                    DateTime dateTime = new(date.Year, date.Month, date.Day, hour, minute, 0);
                    if(dateTime < DateTime.Now)
                    {
                        button.IsEnabled = false;
                    }
                }
            }
        }
    }
}
