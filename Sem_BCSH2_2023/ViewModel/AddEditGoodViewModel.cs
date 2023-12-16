using Sem_BCSH2_2023.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;

namespace Sem_BCSH2_2023.ViewModel
{
    public class AddEditGoodViewModel: BaseViewModel
    {
        private Flower? editedFlower;
        private OtherItems? editedOtherItems;
        private bool isFlowerWindow;

        private int _id;
        private string _name;
        private double _price;

        private string _desc_usage;
        private string _flwSpecies_packageType;

        private string _windowName;
        private string _btnAddEdit; 
        
        private string _TBdescOrUsage;
        private string _TBspecOrPackage;

        public ICommand AddEditGoodCom { get; private set; }

        public ICommand CloseCommand { get; private set; }
        public ICommand MaximizeCommand { get; private set; }
        public ICommand MinimizeCommand { get; private set; }


        public AddEditGoodViewModel(int? id, bool flower_item)
        {
            WindowName = "Přidat novou rostlinu";
            BtnAddEdit = "Přidat";

            TBDescOrUsage = "Popis";
            TBSpecOrPackage = "Druh rostliny";

            isFlowerWindow = flower_item;

            if (isFlowerWindow)
            {
                editedFlower = null;

                if (id != null)
                {
                    editedFlower = (Flower?)GoodViewModel.GoodsList.FirstOrDefault(flower => flower.Id == id);
                    BtnAddEdit = "Editovat";
                    WindowName = "Editace položky";

                    Name = editedFlower.Name;
                    Price = editedFlower.Price;
                    Desc_Usage = editedFlower.Description;
                    FlwSpecies_PackageType = editedFlower.FlowerSpecies;
                }
            }
            else
            {
                WindowName = "Přidat zboží";
                TBDescOrUsage = "Použití";
                TBSpecOrPackage = "Popis balení";

                if (id != null)
                {
                    editedOtherItems = (OtherItems?)GoodViewModel.GoodsList.FirstOrDefault(otherItem => otherItem.Id == id);
                    BtnAddEdit = "Editovat";
                    WindowName = "Editace položky";

                    Name = editedOtherItems.Name;
                    Price = editedOtherItems.Price;
                    Desc_Usage = editedOtherItems.Usage;
                    FlwSpecies_PackageType = editedOtherItems.PackageType;
                }
            }
            AddEditGoodCom = new CommandViewModel(_ => AddEditGood());

            CloseCommand = new CommandViewModel(_ => Close());
            MaximizeCommand = new CommandViewModel(_ => Maximize());
            MinimizeCommand = new CommandViewModel(_ => Minimize());
        }

        private void AddEditGood()
        {

            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);

            if (isFlowerWindow)
            {

                if (editedFlower == null)
                {
                    if (CheckFlower())
                    {
                        _ = double.TryParse(Price.ToString(), out double price);
                        GoodViewModel.AddFlower(Name, price, Desc_Usage, FlwSpecies_PackageType);
                        window?.Close();
                    }

                }
                else
                {
                    if (CheckFlower())
                    {
                        double.TryParse(Price.ToString(), out double price);
                        editedFlower.Name = Name;
                        editedFlower.Price = price;
                        editedFlower.Description = Desc_Usage;
                        editedFlower.FlowerSpecies = FlwSpecies_PackageType;
                        window?.Close();
                    }


                }
            }
            //Editation of OtherItem
            else
            {

                if (editedOtherItems == null)
                {
                    if (CheckOtherItems())
                    {
                        double.TryParse(Price.ToString(), out double price);
                        GoodViewModel.AddOtherItems(Name, price, Desc_Usage, FlwSpecies_PackageType);
                        window?.Close();
                    }

                }
                else
                {
                    if (CheckOtherItems())
                    {
                        double.TryParse(Price.ToString(), out double price);
                        

                        editedOtherItems.Name = Name;
                        editedOtherItems.Price = price;
                        editedOtherItems.PackageType = FlwSpecies_PackageType;
                        editedOtherItems.Usage = Desc_Usage;
                        window?.Close();
                    }

                }
            }
        }

        private bool CheckFlower()
        {
            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Desc_Usage) ||
                string.IsNullOrEmpty(FlwSpecies_PackageType) || !double.TryParse(Price.ToString(), out _))
            {
                MessageBox.Show("Všechna pole musí být vyplněna a cena musí být platné číslo.", "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

        private bool CheckOtherItems()
        {
            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Desc_Usage) ||
                string.IsNullOrEmpty(FlwSpecies_PackageType) || string.IsNullOrEmpty(Price.ToString()) ||
                !double.TryParse(Price.ToString(), out _) )
            {
                MessageBox.Show("Všechna pole musí být vyplněna, cena a počet musí být platná čísla.", "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }



        public string Desc_Usage
        {
            get => _desc_usage;
            set => SetProperty(ref _desc_usage, value, nameof(Desc_Usage));
        }

        public string FlwSpecies_PackageType
        {
            get => _flwSpecies_packageType;
            set => SetProperty(ref _flwSpecies_packageType, value, nameof(FlwSpecies_PackageType));
        }

        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value, nameof(Id));
        }
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value, nameof(Name));
        }
        public double Price
        {
            get => _price;
            set => SetProperty(ref _price, value, nameof(Price));
        }




         public string WindowName
        {
            get => _windowName;
            set => SetProperty(ref _windowName, value, nameof(WindowName));
        } 
        
        public string BtnAddEdit
        {
            get => _btnAddEdit;
            set => SetProperty(ref _btnAddEdit, value, nameof(BtnAddEdit));
        }  
        
        public string TBDescOrUsage
        {
            get => _TBdescOrUsage;
            set => SetProperty(ref _TBdescOrUsage, value, nameof(TBDescOrUsage));
        } 
        
        public string TBSpecOrPackage
        {
            get => _TBspecOrPackage;
            set => SetProperty(ref _TBspecOrPackage, value, nameof(TBSpecOrPackage));
        }



        //Modification buttons
        private static void Close()
        {
            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
            window?.Close();
        }

        private static void Maximize()
        {
            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);

            if (window != null)
            {
                if (window.WindowState == WindowState.Normal)
                {
                    window.WindowState = WindowState.Maximized;
                }
                else
                {
                    window.WindowState = WindowState.Normal;
                }
            }
        }

        private static void Minimize()
        {
            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);

            if (window != null)
            {
                window.WindowState = WindowState.Minimized;
            }
        }
    }
}
