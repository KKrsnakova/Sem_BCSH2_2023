using Sem_BCSH2_2023.Model;
using Sem_BCSH2_2023.ViewModel;
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

namespace Sem_BCSH2_2023.View
{
    /// <summary>
    /// Interaction logic for AddEditCustomer.xaml
    /// </summary>
    public partial class AddEditCustomer : Window
    {
        private Customer? editedCustomer;
        public AddEditCustomer(int? id)
        {
            InitializeComponent();
            editedCustomer = null;

            if (id != null)
            {

                editedCustomer = CustomerViewModel.CustomersList.FirstOrDefault(customer => customer.Id == id);
                btnAdd.Content = "Editovat";
                windowName.Text = "Editace údajů o zákazníkovi";
                tbName.Text = editedCustomer.Name;
                tbSurname.Text = editedCustomer.Surname;
                tbAddress.Text = editedCustomer.Address;
                tbCity.Text = editedCustomer.City;
                tbPhoneNumber.Text = editedCustomer.PhoneNumber.ToString();
                tbEmail.Text = editedCustomer.Email;

            }


        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (editedCustomer == null)
            {
                if (CheckFill())
                {
                    _ = long.TryParse(tbPhoneNumber.Text, out long phone);
                    CustomerViewModel.AddCustomer(tbName.Text, tbSurname.Text, tbAddress.Text, tbCity.Text, phone, tbEmail.Text);
                    this.Close();
                }
            }
            else
            {
                if (CheckFill())
                {
                    _ = long.TryParse(tbPhoneNumber.Text, out long phone);
                    editedCustomer.Name = tbName.Text;
                    editedCustomer.Surname = tbSurname.Text;
                    editedCustomer.Address = tbAddress.Text;
                    editedCustomer.City = tbCity.Text;
                    editedCustomer.PhoneNumber = phone;
                    editedCustomer.Email = tbEmail.Text;
                    GetWindow(this).Close();
                }
            }


        }

        private bool CheckFill()
        {
            if (string.IsNullOrEmpty(tbName.Text) || string.IsNullOrEmpty(tbSurname.Text) ||
            string.IsNullOrEmpty(tbAddress.Text) || string.IsNullOrEmpty(tbCity.Text) ||
            string.IsNullOrEmpty(tbPhoneNumber.Text) || string.IsNullOrEmpty(tbEmail.Text))
            {
                MessageBox.Show("Všechna pole musí být vyplněna.", "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!long.TryParse(tbPhoneNumber.Text, out _))
            {
                MessageBox.Show("Telefonní číslo musí být číslo.", "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            string emailRegex = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(tbEmail.Text, emailRegex))
            {
                MessageBox.Show("Nesprávný formát e-mailu.", "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;

        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnMaximal_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }
            else this.WindowState = WindowState.Normal;
        }


        private void BtnMinimal_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void NavBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }



        private void NavBar_MouseEnter(object sender, MouseEventArgs e)
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }


    }

}
