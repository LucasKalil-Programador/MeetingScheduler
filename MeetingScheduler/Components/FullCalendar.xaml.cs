using MeetingScheduler.Objects;
using System;
using System.Windows;
using System.Windows.Controls;

namespace MeetingScheduler.Components
{
    /// <summary>
    /// Interação lógica para FullCalendar.xam
    /// </summary>
    public partial class FullCalendar : UserControl
    {
        private int minute = 0;
        private int hour = 1;
        private int month = 1;
        private int year = 1;
        private int day = 1;

        public Action<DateTime> OnDateClick = (date) => { };
        public Action<DateTime> OnOcupedDateClick = (date) => { };

        public FullCalendar()
        {
            InitializeComponent();

            DateTime now = DateTime.Now;
            monthCalendar.SetYearAndMonth(now.Year, now.Month);
            monthCalendar.OnDayClick += OnDayClick;
            dayCalendar.returnButton.Click += (s, a) => OnReturnButtonCLick();
            dayCalendar.OnHourClick += OnHourClick;
            dayCalendar.OnOcupedHourClick += OnOcupedHourClick;
            month = monthCalendar.Month;
            year = monthCalendar.Year;
            UpdateDate();
        }

        private void OnDayClick(int day)
        {
            dayCalendar.SetDate(new DateTime(year, month, day));
            this.day = day;
            monthGrid.Visibility = Visibility.Hidden;
            monthGrid.IsEnabled = false;

            dayGrid.Visibility = Visibility.Visible;
            dayGrid.IsEnabled = true;
        }

        private void OnReturnButtonCLick()
        {
            monthGrid.Visibility = Visibility.Visible;
            monthGrid.IsEnabled = true;

            dayGrid.Visibility = Visibility.Hidden;
            dayGrid.IsEnabled = false;
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

        private void OnHourClick(string time)
        {
            string[] timeSplited = time.Split(":");
            hour = int.Parse(timeSplited[0]);
            minute = int.Parse(timeSplited[1]);

            DateTime dateTime = new(year, month, day, hour, minute, 0);
            OnDateClick.Invoke(dateTime);
        }

        private void OnOcupedHourClick(string time)
        {
            string[] timeSplited = time.Split(":");
            hour = int.Parse(timeSplited[0]);
            minute = int.Parse(timeSplited[1]);

            DateTime dateTime = new(year, month, day, hour, minute, 0);
            OnOcupedDateClick.Invoke(dateTime);
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

        public void SetLocationAndParticipants(Location location, Client[] clients)
        {
            dayCalendar.SetLocationAndParticipants(location, clients);
        }
    }
}
