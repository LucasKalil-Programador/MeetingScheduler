﻿using System;
using System.Windows;
using System.Windows.Controls;

namespace MeetingScheduler.Components
{
    /// <summary>
    /// Interação lógica para Calendar.xam
    /// </summary>
    public partial class MonthCalendar : UserControl
    {
        public int VisibleDays { get; private set; }
        public int Year { get; private set; }
        public int Month { get; private set; }

        public Action<int> OnDayClick = (day) => { };

        public MonthCalendar()
        {
            InitializeComponent();
            for (int i = 0; i < monthGrid.Children.Count; i++)
            {
                Button? button = GetButtonDay(i);
                if (button != null)
                {
                    int day = i;
                    button.Tag = day;
                    button.Content = day.ToString();
                    button.Click += (s, a) => OnDayClick.Invoke(day);
                }
            }
        }

        public Button? GetButtonDay(int day)
        {
            day--;
            foreach (FrameworkElement control in monthGrid.Children)
            {
                if (control is Button button)
                {
                    if ((day / 7) + 1 == Grid.GetRow(button) && (day % 7) == Grid.GetColumn(button))
                    {
                        return button;
                    }
                }
            }
            return null;
        }

        public void SetButtonContent(int day, object content)
        {
            Button? button = GetButtonDay(day);
            if (button != null) button.Content = content;
        }

        public void SetYearAndMonth(int year, int month)
        {
            Year = year;
            Month = month;
            VisibleDays = DateTime.DaysInMonth(year, month);
            for (int i = 0; i < monthGrid.Children.Count; i++)
            {
                Button? button = GetButtonDay(i);
                if (button != null)
                {
                    if (i <= VisibleDays)
                    {
                        button.Visibility = Visibility.Visible;
                        button.IsEnabled = new DateTime(year, month, i, 23, 59, 59) > DateTime.Now;
                    }
                    else
                    {
                        button.Visibility = Visibility.Hidden;
                        button.IsEnabled = false;
                    }
                }
            }
        }
    }
}
