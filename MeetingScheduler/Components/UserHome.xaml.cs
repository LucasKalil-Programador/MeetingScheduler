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
        private readonly UserControl[] userControls;
        private Client LogedClient;

        public UserHome()
        {
            InitializeComponent();
            userControls = GetControls();
            meetingButton.Click += (s, a) => ChangeControl(meetingCreator);
            ChangeControl(calendar);
        }

        public void LogClient(Client newClient)
        {
            LogedClient = newClient;
        }

        public void ChangeControl(UserControl newControl)
        {
            newControl.Visibility = Visibility.Visible;
            newControl.IsEnabled = true;
            foreach (UserControl oldControl in userControls)
            {
                if (oldControl != newControl)
                {
                    oldControl.Visibility = Visibility.Hidden;
                    oldControl.IsEnabled = false;
                }
            }
        }

        public UserControl[] GetControls()
        {
            List<UserControl> users = new();
            foreach (var childrens in Panel.Children)
            {
                if (childrens is UserControl children) users.Add(children);
            }
            return users.ToArray();
        }

    }
}
