using Sem_BCSH2_2023.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        private readonly LoginViewModel loginVM;
        public LoginView()
        {
            InitializeComponent();
            loginVM = new();
            DataContext = loginVM;
        }


        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton==MouseButtonState.Pressed) { DragMove(); }
        }

        

        private void TbRegisterHere_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
                RegistrationView newRefistrationWindow = new RegistrationView(null);
                newRefistrationWindow.Show();
           
        }

       
    }
}
