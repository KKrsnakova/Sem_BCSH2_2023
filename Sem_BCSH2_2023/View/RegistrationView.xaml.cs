using Microsoft.VisualBasic.ApplicationServices;
using Sem_BCSH2_2023.Manager;
using Sem_BCSH2_2023.Model;
using Sem_BCSH2_2023.Repository;
using Sem_BCSH2_2023.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for RegistrationView.xaml
    /// </summary>
    public partial class RegistrationView : Window
    {
        private readonly RegistrationViewModel registrationVM;


        public RegistrationView(int? id)
        {
            InitializeComponent();
            registrationVM = new(id);
            DataContext = registrationVM;

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
