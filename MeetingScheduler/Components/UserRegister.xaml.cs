using MeetingScheduler.Objects;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace MeetingScheduler.Components
{
    /// <summary>
    /// Interação lógica para UserRegister.xam
    /// </summary>
    public partial class UserRegister : UserControl
    {
        private readonly Brush ValidColor;

        public event Action<Client> OnRegisterNewClient = (c) => { };

        public UserRegister()
        {
            InitializeComponent();
            ValidColor = NameTextBox.Background;
        }

        private void OnRegisterButtonClick(object sender, EventArgs args)
        {
            if (!IsValidData()) return;

            Client newClient = new Clientfactory()
                .SetId(-1)
                .SetName(NameTextBox.Text)
                .SetPhone(PhoneTextBox.Text)
                .SetEmail(EmailTextBox.Text)
                .SetOffice(OfficeTextBox.Text)
                .SetDocument(DocumentTextBox.Text)
                .Build();


            bool status = DB.InsertClient(newClient, PasswordTextBox.Text);

            ShowMessage(status);
            if (status)
            {
                OnRegisterNewClient.Invoke(DB.SelectClientByNameAndPassword(NameTextBox.Text, PasswordTextBox.Text));
                CleanTextBox();
            }
        }

        private void ShowMessage(bool success)
        {
            if (success)
            {
                MessageBox.Show(App.Current.MainWindow, "Usuario registrado com sucesso", "Sucesso", MessageBoxButton.OK);
            }
            else
            {
                string errorSTR = "Erro ao registrar usuario";
                if (DB.ExistsClientByName(NameTextBox.Text))
                {
                    errorSTR += "\r\nNome de usuario ja existente";
                    NameTextBox.Background = new SolidColorBrush(Color.FromRgb(255, 100, 100));
                }
                MessageBox.Show(App.Current.MainWindow, errorSTR, "Error", MessageBoxButton.OK);
            }
        }

        private void CleanTextBox()
        {
            NameTextBox.Clear();
            PhoneTextBox.Clear();
            EmailTextBox.Clear();
            OfficeTextBox.Clear();
            DocumentTextBox.Clear();
            PasswordTextBox.Clear();
        }

        private bool IsValidData()
        {
            return NameTextBox.IsValidInput(@"[a-zA-Z ]+", ValidColor) &
                   PasswordTextBox.IsValidInput(@"\w+", ValidColor) &
                   PhoneTextBox.IsValidInput(@"\d{2} ?\d{5}(-| )?\d{4}", ValidColor) &
                   EmailTextBox.IsValidInput(@"[\w]+(\.[\w]+)*\@\w+(\.[\w]+)+", ValidColor) &
                   OfficeTextBox.IsValidInput(@"[a-zA-Z ]+", ValidColor) &
                   DocumentTextBox.IsValidInput(@"(\d|-|\.)+|\d+", ValidColor);
        }
    }
}
