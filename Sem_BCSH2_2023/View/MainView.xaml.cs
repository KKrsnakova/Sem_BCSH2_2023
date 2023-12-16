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


    }
}
