using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MeetingScheduler
{
    public partial class MainWindow : Window
    {
        private readonly UserControl[] userControls;

        public MainWindow()
        {         
            InitializeComponent();
            Console.WriteLine("Banco de dados: " + DB.Ping());
            userControls = GetControls();
            ChangeControl(userLogin);

            userRegister.OnRegisterNewClient += (c) => ChangeControl(userLogin);
            userRegister.ReturnButton.Click += (s, a) => ChangeControl(userLogin);

            userLogin.RegisterButton.Click += (s, a) => ChangeControl(userRegister);
            userLogin.OnLogin += userHome.LogClient;
            userLogin.OnLogin += (c) => ChangeControl(userHome);
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
