using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Security.Cryptography;
using System.Windows.Documents;

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
            textBox.Background = validColor;
            return true;
        }

        public static bool IsValidInput(this RichTextBox textBox, string regex, Brush validColor)
        {
            Regex regexp = new(regex);

            if (string.IsNullOrEmpty(textBox.GetText()) || !string.IsNullOrEmpty(regexp.Replace(textBox.GetText(), "", 1)))
            {
                textBox.Background = new SolidColorBrush(Color.FromRgb(255, 100, 100));
                return false;
            }
            textBox.Background = validColor;
            return true;
        }

        public static string HashPassword(string password)
        {
            var sha = SHA256.Create();
            var bytes = Encoding.Default.GetBytes(password);
            var hash = sha.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        public static string GetText(this RichTextBox r)
        {
            return new TextRange(r.Document.ContentStart, r.Document.ContentEnd).Text;
        }
    
        public static string ToMySQLDateTimeFormat(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
