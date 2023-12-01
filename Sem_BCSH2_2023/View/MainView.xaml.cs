using CommunityToolkit.Mvvm.Input;
using Sem_BCSH2_2023.Manager;
using Sem_BCSH2_2023.Model;
using Sem_BCSH2_2023.Repository;
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
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
       

         public static UserLogins? ActualUser { get; set; }
      

        public MainView(UserLogins actualUser)
        {


            ActualUser = actualUser;


                InitializeComponent();
                tbUserNameActual.Text = actualUser.FullName;
               
            


        }

        //public static void SetCurrentUser(UserLogins user)
        //{
        //    ActualUser = user;

        //}
        public static UserLogins GetCurrentUser()
        {
            return ActualUser;

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

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnMaximal_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }
            else this.WindowState = WindowState.Normal;
        }


        private void BtnLogOut_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Odhlášeno");
            //Repo.Dispose();
            // Uzavřít aktuální okno
            //Window currentWindow = Application.Current.MainWindow;
            //currentWindow.Close();
            LoginView loginView = new LoginView();
            this.Close();

            // Vytvořit a zobrazit nové přihlašovací okno

            loginView.Show();
        }

       



    }
}
