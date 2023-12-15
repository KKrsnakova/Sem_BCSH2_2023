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

namespace Sem_BCSH2_2023.View
{
    /// <summary>
    /// Interaction logic for PasswordUserControl.xaml
    /// </summary>
    public partial class PasswordUserControl : UserControl
    {


          public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(string), typeof(PasswordUserControl), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty Password2Property =
           DependencyProperty.Register("Password2", typeof(string), typeof(PasswordUserControl), new PropertyMetadata(string.Empty));



        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        public string Password2
        {
            get { return (string)GetValue(Password2Property); }
            set { SetValue(Password2Property, value); }
        }

        public PasswordUserControl()
        {
            InitializeComponent();
        }


        private void TbPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Password = tbPassword.Password;
        }

        private void TbPassword2_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Password2 = tbPassword.Password;
        }
    }
}
