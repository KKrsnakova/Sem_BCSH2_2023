using Sem_BCSH2_2023.Model;
using Sem_BCSH2_2023.View;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Sem_BCSH2_2023.ViewModel
{
    /// <summary>
    /// Interaction logic for AddEditGoods.xaml
    /// </summary>
    public partial class AddEditGoods : Window
    {
        
        private readonly AddEditGoodViewModel addEditGoodVM;
        public AddEditGoods(int? id, bool flower_item)
        {
            InitializeComponent();
            addEditGoodVM = new AddEditGoodViewModel(id, flower_item);
            DataContext = addEditGoodVM;
        }




        //Modifications

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