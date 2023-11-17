using Sem_BCSH2_2023.Model;
using Sem_BCSH2_2023.View;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Sem_BCSH2_2023.ViewModel
{
    /// <summary>
    /// Interaction logic for AddGoods.xaml
    /// </summary>
    public partial class AddGoods : Window
    {
        private Flower? editedFlower;
        private OtherItems? editedOtherItems;
        private bool isFlowerWindow;
        public AddGoods(int? id, bool flower_item)
        {
            isFlowerWindow = flower_item;
            InitializeComponent();

            if (isFlowerWindow)
            {

                editedFlower = null;

                if (id != null)
                {
                    editedFlower = (Flower?)GoodViewModel.GoodsList.FirstOrDefault(flower => flower.Id == id);
                    btnAdd.Content = "Editovat";
                    windowName.Text = "Editace položky";
                    tbName.Text = editedFlower.Name;
                    tbPrice.Text = editedFlower.Price.ToString();
                    tbDesc_tbCount.Text = editedFlower.Description;
                    tbSpec_tbUsage.Text = editedFlower.FlowerSpecies;
                }
            }
            else
            {
                windowName.Text = "Přidat položku";
                text3.Text = "Počet";
                text4.Text = "Oblast použití";

                if (id != null)
                {
                    editedOtherItems = (OtherItems?)GoodViewModel.GoodsList.FirstOrDefault(otherItem => otherItem.Id == id);
                    btnAdd.Content = "Editovat";
                    windowName.Text = "Editace položky";
                    tbName.Text = editedOtherItems.Name;
                    tbPrice.Text = editedOtherItems.Price.ToString();
                    tbDesc_tbCount.Text = editedOtherItems.Count.ToString();
                    tbSpec_tbUsage.Text = editedOtherItems.Usage;
                }
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (isFlowerWindow)
            {

                if (editedFlower == null)
                {
                    if (CheckFlower())
                    {
                        _ = double.TryParse(tbPrice.Text, out double price);
                        GoodViewModel.AddFlower(tbName.Text, price, tbDesc_tbCount.Text, tbSpec_tbUsage.Text);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Chyba", "Špatně zadaná hodnota", MessageBoxButton.OK);
                        this.Close();
                    }
                }
                else
                {
                    if (CheckFlower())
                    {
                        double.TryParse(tbPrice.Text, out double price);
                        editedFlower.Name = tbName.Text;
                        editedFlower.Price = price;
                        editedFlower.Description = tbDesc_tbCount.Text;
                        editedFlower.FlowerSpecies = tbSpec_tbUsage.Text;
                    }
                    else
                    {
                        MessageBox.Show("Chyba", "Špatně zadaná hodnota", MessageBoxButton.OK);
                        this.Close();
                    }
                    GetWindow(this).Close();
                }
            }
            //Editation of OtherItem
            else
            {

                if (editedOtherItems == null)
                {
                    if (CheckOtherItems())
                    {
                        double.TryParse(tbPrice.Text, out double price);
                        int.TryParse(tbDesc_tbCount.Text, out int count);
                        GoodViewModel.AddOtherItems(tbName.Text, price, count, tbSpec_tbUsage.Text);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Chyba", "Špatně zadaná hodnota", MessageBoxButton.OK);
                        this.Close();
                    }
                }
                else
                {
                    if (CheckOtherItems())
                    {
                        double.TryParse(tbPrice.Text, out double price);
                        int.TryParse(tbDesc_tbCount.Text, out int count);

                        editedOtherItems.Name = tbName.Text;
                        editedOtherItems.Price = price;
                        editedOtherItems.Count = count;
                        editedOtherItems.Usage = tbSpec_tbUsage.Text;
                    }
                    else
                    {
                        MessageBox.Show("Chyba", "Špatně zadaná hodnota", MessageBoxButton.OK);
                        this.Close();
                    }
                    GetWindow(this).Close();
                }
            }
            

        }

        //Modification buttons

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
            DragMove();
        }



        private void NavBar_MouseEnter(object sender, MouseEventArgs e)
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        private bool CheckFlower()
        {
            if (!String.IsNullOrEmpty(tbName.Text) &&
                !String.IsNullOrEmpty(tbDesc_tbCount.Text) &&
                !String.IsNullOrEmpty(tbSpec_tbUsage.Text) &&
                double.TryParse(tbPrice.Text, out double price))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CheckOtherItems()
        {
            if (!String.IsNullOrEmpty(tbName.Text) &&
                !String.IsNullOrEmpty(tbDesc_tbCount.Text) &&
                !String.IsNullOrEmpty(tbSpec_tbUsage.Text) &&
                !String.IsNullOrEmpty(tbPrice.Text) &&
                double.TryParse(tbPrice.Text, out _) &&
                int.TryParse(tbDesc_tbCount.Text, out _))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

       
    }
}