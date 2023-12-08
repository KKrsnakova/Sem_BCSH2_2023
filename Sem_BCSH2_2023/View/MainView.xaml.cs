using Sem_BCSH2_2023.Model;
using Sem_BCSH2_2023.ViewModel;
using System.Windows;
using System.Windows.Input;

namespace Sem_BCSH2_2023.View
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {


        private UserLogins _loggedInUser;
        public UserLogins LoggedInUser
        {
            get { return _loggedInUser; }
            set { _loggedInUser = value; }
        }


        public MainViewModel? MainVM { get; set; }


        public MainView()
        {

            InitializeComponent();

          
        }

        private void NavBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void NavBar_MouseEnter(object sender, MouseEventArgs e)
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        private void BtnMinimal_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }



        private void BtnMaximal_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }
            else this.WindowState = WindowState.Normal;
        }

    }
}
