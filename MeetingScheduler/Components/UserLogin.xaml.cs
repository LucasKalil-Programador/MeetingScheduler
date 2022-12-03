using MeetingScheduler.Objects;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MeetingScheduler.Components
{
    public partial class UserLogin : UserControl
    {

        private readonly Brush ValidColor;

        public Action<Client> OnLogin = (c) => { };

        public UserLogin()
        {
            InitializeComponent();
            ValidColor = UserNameTextBox.Background;
        }

        private void OnLoginButtonClick(object sender, RoutedEventArgs e)
        {
            if (!(UserNameTextBox.IsValidInput(@"[a-zA-Z ]+", ValidColor) &
                PasswordTextBox.IsValidInput(@"\w+", ValidColor)))
            {
                return;
            }
            string userName = UserNameTextBox.Text;
            string password = PasswordTextBox.Password.ToString();

            Client client = DB.SelectClientByNameAndPassword(userName, password);
            if (client != default)
            {
                OnLogin.Invoke(client);
            }
            else
            {
                MessageBox.Show(App.Current.MainWindow, "Usuario ou senha invalida", "Login error", MessageBoxButton.OK);
            }
        }
    }
}
