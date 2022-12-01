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
using MeetingScheduler.Objects;

namespace MeetingScheduler.Components
{
    public partial class UserHome : UserControl
    {
        private Client LogedClient;

        public UserHome()
        {
            InitializeComponent();
        }

        public void LogClient(Client newClient)
        {
            LogedClient = newClient;
            userNameTextBlock.Text = $"Area do usuario: {LogedClient.Name}";
        }
    }
}
