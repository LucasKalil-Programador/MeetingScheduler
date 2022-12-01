﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace MeetingScheduler
{
    public static class Utils
    {
        public static bool IsValidInput(this TextBox textBox, string regex, Brush validColor)
        {
            Regex regexp = new(regex);
                
            if (string.IsNullOrEmpty(textBox.Text) || !string.IsNullOrEmpty(regexp.Replace(textBox.Text, "", 1)))
            {
                textBox.Background = new SolidColorBrush(Color.FromRgb(255, 100, 100));
                return false;
            }
            Console.WriteLine(regexp.Replace(textBox.Text, "", 1));
            textBox.Background = validColor;
            return true;
        }

        public static bool IsValidInput(this PasswordBox textBox, string regex, Brush validColor)
        {
            Regex regexp = new(regex);

            if (string.IsNullOrEmpty(textBox.Password.ToString()) || !string.IsNullOrEmpty(regexp.Replace(textBox.Password.ToString(), "", 1)))
            {
                textBox.Background = new SolidColorBrush(Color.FromRgb(255, 100, 100));
                return false;
            }
            Console.WriteLine(regexp.Replace(textBox.Password.ToString(), "", 1));
            textBox.Background = validColor;
            return true;
        }
    }
}
