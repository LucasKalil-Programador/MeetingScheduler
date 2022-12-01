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
using System.Windows.Shapes;
using MeetingScheduler.Objects;

namespace MeetingScheduler.OtherWindows
{
    public partial class LocationUserRequest : Window
    {
        private Location[] locations = Array.Empty<Location>();
        public Location ResultLocation = default;

        public LocationUserRequest()
        {
            InitializeComponent();
            IsVisibleChanged += (s, a) => OnVisibleChange();
            locationsDataGrid.SelectionChanged += (s, a) => OnSelected();
        }

        private void OnVisibleChange()
        {
            if (IsVisible) UpdateDataGrid();  
        }

        private void ChangeButtonClick(object sender, EventArgs args)
        {
            if (locationsDataGrid.IsEnabled)
            {
                locationsDataGrid.IsEnabled = false;
                locationsDataGrid.Visibility = Visibility.Hidden;
                addNewLocationButton.IsEnabled = true;
                addNewLocationButton.Visibility = Visibility.Visible;
                changeButton.Content = "Retornar";
            }
            else
            {
                UpdateDataGrid();
                locationsDataGrid.IsEnabled = true;
                locationsDataGrid.Visibility = Visibility.Visible;
                addNewLocationButton.IsEnabled = false;
                addNewLocationButton.Visibility = Visibility.Hidden;
                changeButton.Content = "Adicionar novo local";
            }
        }
    
        private void UpdateDataGrid()
        {
            locations = DB.SelectAllLocations();
            locationsDataGrid.ItemsSource = locations;
        }

        private void OnSelected()
        {
            ResultLocation = locations[locationsDataGrid.SelectedIndex];
            Close();
        }
    }
}
