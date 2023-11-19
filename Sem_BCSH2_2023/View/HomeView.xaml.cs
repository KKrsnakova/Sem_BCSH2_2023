using Sem_BCSH2_2023.Model;
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
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
            SetBoxes();
        }

        private void SetBoxes()
        {
            UserLogins usr = MainView.GetCurrentUser();
            tbFullName.Text = usr.FullName;
            tbEmail.Text = usr.Email;
            tbUserLogin.Text = usr.Username;
            tbPassword.Text = usr.Password;
        }
        
    }
}
