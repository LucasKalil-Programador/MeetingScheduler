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
    /// Interação lógica para FullCalendar.xam
    /// </summary>
    public partial class FullCalendar : UserControl
    {
        private int month;
        private int year;

        public Action<DateTime> OnDateClick = (date) => { };

        public FullCalendar()
        {
            InitializeComponent();
            monthCalendar.OnDayClick += OnDayClick;

            DateTime now = DateTime.Now; 
            monthCalendar.SetYearAndMonth(now.Year, now.Month);
            month = monthCalendar.Month;
            year = monthCalendar.Year;
            UpdateDate();
        }

        private void OnDayClick(Button button, int day)
        {
            DateTime ClickedDate = new DateTime(year, month, day);
            if (ClickedDate > DateTime.Now)
            {
                OnDateClick.Invoke(ClickedDate);
            }
        }

        private void NextMonthClick(object sender, RoutedEventArgs e)
        {
            if (month < 12)
            {
                month++;
            }
            else
            {
                month = 1;
                year++;
            }
            UpdateDate();
        }

        private void PreviousButtonClick(object sender, RoutedEventArgs e)
        {
            if (month > 1)
            {
                month--;
            }
            else
            {
                month = 12;
                year--;
            }
            UpdateDate();
        }

        private void UpdateDate()
        {
            dateTextBlock.Text = $"{month}/{year}";
            monthCalendar.SetYearAndMonth(year, month);
        }
    }
}
