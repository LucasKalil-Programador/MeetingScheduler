using MeetingScheduler.Objects;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace MeetingScheduler.Components
{
    public partial class UserHome : UserControl
    {
        private readonly UserControl[] userControls;
        public Client LogedClient;

        public UserHome()
        {
            InitializeComponent();
            userControls = GetControls();
            meetingButton.Click += (s, a) => ChangeControl(meetingCreator);
            meetingDetailsButton.Click += (s, a) => ChangeControl(meetingDetails);
            ChangeControl(meetingCreator);
        }

        public void LogClient(Client newClient)
        {
            LogedClient = newClient;
            meetingDetails.SetClient(newClient);
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
