using MeetingScheduler.Objects;
using System;
using System.Collections;
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
using System.Windows.Shapes;

namespace MeetingScheduler.OtherWindows
{
    public partial class TeamUserRequest : Window
    {
        public Client[] resultClients = Array.Empty<Client>();

        private List<Client> NonSelectedClients = new();
        private List<Client> SelectedClients = new();

        public TeamUserRequest(Client[] clients)
        {
            InitializeComponent();
            UpdateDataGrid(clients);
        }

        private void UpdateDataGrid(Client[] clients)
        {
            SelectedClients = new(clients);
            NonSelectedClients = new(DB.SelectAllClients());
            NonSelectedClients.RemoveAll((c) => clients.Contains(c));

            nonSelectedClientsDataGrid.ItemsSource = NonSelectedClients;
            selectedClientsDataGrid.ItemsSource = SelectedClients;
        }

        private void OnSelectButtonClick(object sender, RoutedEventArgs e)
        {
            foreach (var item in nonSelectedClientsDataGrid.SelectedItems)
            {
                if(item is Client client)
                {
                    NonSelectedClients.Remove(client);
                    SelectedClients.Add(client);
                }
            }
            nonSelectedClientsDataGrid.Items.Refresh();
            selectedClientsDataGrid.Items.Refresh();
        }

        private void OnUnSelectButtonClick(object sender, RoutedEventArgs e)
        {
            foreach (var item in selectedClientsDataGrid.SelectedItems)
            {
                if (item is Client client)
                {
                    NonSelectedClients.Add(client);
                    SelectedClients.Remove(client);
                }
            }
            nonSelectedClientsDataGrid.Items.Refresh();
            selectedClientsDataGrid.Items.Refresh();
        }

        private void OnConfirmButtonClick(object sender, RoutedEventArgs e)
        {
            resultClients = SelectedClients.ToArray();
            Close();
        }
    }
}
