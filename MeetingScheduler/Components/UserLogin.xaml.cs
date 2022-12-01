using MeetingScheduler.Objects;
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
            if(!(UserNameTextBox.IsValidInput(@"[a-zA-Z ]+", ValidColor) &
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
                MessageBox.Show(App.Current.MainWindow, "Invalid user name or password", "Login error", MessageBoxButton.OK);
            }
        }
    }
}
