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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sem_BCSH2_2023.View
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        private readonly UserLogins _loggedInUser;

        public HomeView()
        {
            InitializeComponent();
            HomeViewModel homeViewModel = new HomeViewModel(MainView.GetCurrentUser());
            _loggedInUser = homeViewModel.ActualUser;
            SetBoxes();

        }
       

        private void SetBoxes( )
        {
            tbFullName.Text = _loggedInUser.FullName;
            tbEmail.Text = _loggedInUser.Email;
            tbUserLogin.Text = _loggedInUser.Username;
            tbPassword.Text = _loggedInUser.Password;
        }
        
    }
}
