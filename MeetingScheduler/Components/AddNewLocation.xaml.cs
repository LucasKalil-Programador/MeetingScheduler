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
    /// <summary>
    /// Interação lógica para AddNewLocation.xam
    /// </summary>
    public partial class AddNewLocation : UserControl
    {

        private readonly Brush ValidBrush;
        public AddNewLocation()
        {
            InitializeComponent();
            ValidBrush = nameTextBox.Background;
        }

        private void CreateLocalButtonClick(object sender, RoutedEventArgs e)
        {
            if (IsValidData())
            {
                Location newLocation = new LocationFactory()
                    .SetName(nameTextBox.Text)
                    .SetAddress(addressTextBox.Text)
                    .SetCapacity(int.Parse(capacityTextBox.Text))
                    .SetCep(cepTextBox.Text)
                    .SetRoom(roomTextBox.Text)
                    .Build();

                bool status = DB.InsertLocation(newLocation);
                if (status)
                {
                    MessageBox.Show(App.Current.MainWindow, "Local adicionado com sucesso", "Sucesso", MessageBoxButton.OK);
                    Clear();
                }
                else
                {
                    MessageBox.Show(App.Current.MainWindow, "Não foi possivel adicionar o local", "Erro", MessageBoxButton.OK);
                }
            }
        }

        private void Clear()
        {
            nameTextBox.Clear();
            addressTextBox.Clear();
            capacityTextBox.Clear();
            roomTextBox.Clear();
            cepTextBox.Clear();
        }

        private bool IsValidData()
        {
            return nameTextBox.IsValidInput(@"\w(\w| )+", ValidBrush) &
                   addressTextBox.IsValidInput(@"\w(\w| )+", ValidBrush) &
                   capacityTextBox.IsValidInput(@"\d+", ValidBrush) &
                   roomTextBox.IsValidInput(@"\w(\w| )+", ValidBrush) &
                   cepTextBox.IsValidInput(@"\w(\w| )+", ValidBrush);
        }
    }
}
