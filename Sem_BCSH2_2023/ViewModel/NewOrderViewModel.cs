using Sem_BCSH2_2023.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using Sem_BCSH2_2023.View;
using System.Net.Mail;
using System.Net;

namespace Sem_BCSH2_2023.ViewModel
{
    public class NewOrderViewModel : BaseViewModel
    {
        private int _id;
        private int _customerId;
        private double _orderPrice;
        private DateTime _orderDate;
        private bool _done;
        private DateTime? _doneDate;
        private ObservableCollection<Good> _listOfGoods;
        private string _fullname;
        private string _priceText;

        private Customer _selectedCustomer;



        //Proměnné text
        private string _btnAddEditConeText;
        private string _tbWindowText;
        private Visibility _cbVisibility;
        private Visibility _tbVisibility;
        private string _tbCustomerText;

        private ObservableCollection<Good> _goodsListShow;
        private ObservableCollection<Customer> _customerListShow;

        public ICommand LvItemsForOrder_SelectionChangedCommand { get; private set; }
        public ICommand AddGoodCommand { get; private set; }
        public ICommand AddNewOrderCommand { get; private set; }
        public ICommand DeleteGoodButtonCommand { get; private set; }
        public ICommand SendOrderEmailCommand { get; private set; }



        public ICommand CloseCommand { get; private set; }
        public ICommand MaximizeCommand { get; private set; }
        public ICommand MinimizeCommand { get; private set; }



        // Customer selectedCustomer;
        private Order order;
        private bool edit;

        public NewOrderViewModel(Order ord, int? customerID)
        {
            SelectedCustomer = CustomerViewModel.CustomersList.First();
            TBCustomerText = "Zákazník";

            //TBPriceText = "Cena: " + OrderViewModel.OrderPrice(order).ToString() + " Kč,-";

            CustomerListShow = CustomerViewModel.CustomersList;

            BtnAddEditConeText = "Přidat Položku";
            TBWindowText = "Nová Objednávka";


            if (customerID != null && ord != null)
            {
                BtnAddEditConeText = "Přidat další položku";
                TBWindowText = "Editace položek objednávky";
                TBVisibility = Visibility.Visible;

                CbVisibility = Visibility.Collapsed;
                edit = true;
                order = ord;
                SelectedCustomer = CustomerViewModel.CustomersList.First(x => x.Id == customerID);
                TBCustomerText = SelectedCustomer.ToString();
                GoodsListShow = ord.ListOfGoods;
                PriceText();
            }
            else
            {
                TBVisibility = Visibility.Collapsed;
                CbVisibility = Visibility.Visible;
                edit = false;
                order = OrderViewModel.NewOrder();
            }


            AddGoodCommand = new CommandViewModel(_ => AddGood());
            AddNewOrderCommand = new CommandViewModel(_ => AddOrder());
            DeleteGoodButtonCommand = new CommandViewModel(DeleteGoodButton);
            SendOrderEmailCommand = new CommandViewModel(SendOrderEmail);


            CloseCommand = new CommandViewModel(_ => Close());
            MaximizeCommand = new CommandViewModel(_ => Maximize());
            MinimizeCommand = new CommandViewModel(_ => Minimize());


        }
        private async void SendOrderEmail(object obj)
        {
            string to, from, pass, messageBody;
            MailMessage message = new MailMessage();
            to = SelectedCustomer.Email;
            from = "kvetinarstvi70@outlook.cz";
            pass = "kvetina123";


            messageBody = $"Dobrý den,<br><br>" +
                          $"Děkujeme za Vaši objednávku. Zde jsou detaily objednávky:<br><br>" +
                          $"Zákazník: {SelectedCustomer.Name + " " + SelectedCustomer.Surname}<br>" +
                          $"Cena objednávky: {OrderViewModel.OrderPrice(order)} Kč<br>" +
                          $"Přehled objednaných položek:<br>";

            foreach (var good in order.ListOfGoods)
            {
                messageBody += $"- {good.Name}: {good.Price} Kč<br>";
            }

            messageBody += "<br>Děkujeme za Vaši spolupráci.";

            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = messageBody;
            message.Subject = "Objednávka z květinářství Květinka";
            message.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient("smtp-mail.outlook.com");
            smtpClient.EnableSsl = true;
            smtpClient.Port = 587;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(from, pass);

            try
            {
                await Task.Run(() => smtpClient.Send(message));
                MessageBox.Show("E-mail odeslán");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Chyba při odesílání e-mailu: {ex.Message}");
            }
        }

        private void DeleteGoodButton(object obj)
        {
            if (obj is Flower flw)
            {
                order.ListOfGoods.Remove(flw);
                GoodViewModel.AddFlower(flw);
            }
            else if (obj is OtherItems otitem)
            {
                order.ListOfGoods.Remove(otitem);
                GoodViewModel.AddOtherItems(otitem);
            }
            PriceText();

        }

        private void AddOrder()
        {
            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
            if (edit)
            {
                //Edit

                order.OrderPrice = (float)OrderViewModel.OrderPrice(order);
                window?.Close();

            }
            else
            {
                //Add

                order.OrderPrice = (float)OrderViewModel.OrderPrice(order);

                order.CustomerId = SelectedCustomer.Id;
                Customer customer = CustomerViewModel.GetCustomerById(SelectedCustomer.Id);
                order.FullName = OrderViewModel.GetCustomerNameById(customer.Id);

                OrderViewModel.AddOrder(order);


            }

            window?.Close();
        }

        private void AddGood()
        {
            AllGoodsView windowAllGoods = new(order);
            windowAllGoods.ShowDialog();
            GoodsListShow = order.ListOfGoods;
            PriceText();

        }

        private void PriceText()
        {
            TBPriceText = "Cena: " + OrderViewModel.OrderPrice(order).ToString() + " Kč,-";

        }

        public ObservableCollection<Good> GoodsListShow
        {
            get { return _goodsListShow; }
            set
            {
                if (_goodsListShow != value)
                {
                    _goodsListShow = value;
                    OnPropertyChanged(nameof(GoodsListShow));
                }
            }
        }


        public ObservableCollection<Customer> CustomerListShow
        {
            get => _customerListShow;
            set => SetProperty(ref _customerListShow, value, nameof(CustomerListShow));
        }



        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value, nameof(Id));
        }
        public int CustomerId
        {
            get => _customerId;
            set => SetProperty(ref _customerId, value, nameof(CustomerId));
        }
        public double OrderPrice
        {
            get => _orderPrice;
            set => SetProperty(ref _orderPrice, value, nameof(OrderPrice));
        }
        public DateTime DateOfCreation
        {
            get => _orderDate;
            set => SetProperty(ref _orderDate, value, nameof(DateOfCreation));
        }
        public ObservableCollection<Good> ListOfGoods
        {
            get => _listOfGoods;
            set => SetProperty(ref _listOfGoods, value, nameof(ListOfGoods));
        }
        public bool Done
        {
            get => _done;
            set => SetProperty(ref _done, value, nameof(Done));
        }
        public DateTime? DateCompletion
        {
            get => _doneDate;
            set => SetProperty(ref _doneDate, value, nameof(DateCompletion));
        }

        public string FullName
        {
            get => _fullname;
            set => SetProperty(ref _fullname, value, nameof(FullName));
        }

        public Customer SelectedCustomer
        {
            get => _selectedCustomer;
            set => SetProperty(ref _selectedCustomer, value, nameof(SelectedCustomer));
        }

        //Proměnné text
        public string BtnAddEditConeText
        {
            get => _btnAddEditConeText;
            set => SetProperty(ref _btnAddEditConeText, value, nameof(BtnAddEditConeText));
        }

        public string TBWindowText
        {
            get => _tbWindowText;
            set => SetProperty(ref _tbWindowText, value, nameof(TBWindowText));
        }
        public string TBCustomerText
        {
            get => _tbCustomerText;
            set => SetProperty(ref _tbCustomerText, value, nameof(TBCustomerText));
        }
        public string TBPriceText
        {
            get => _priceText;
            set => SetProperty(ref _priceText, value, nameof(TBPriceText));
        }



        public Visibility CbVisibility
        {
            get => _cbVisibility;

            set => SetProperty(ref _cbVisibility, value, nameof(CbVisibility));
        }
        public Visibility TBVisibility
        {
            get => _tbVisibility;

            set => SetProperty(ref _tbVisibility, value, nameof(TBVisibility));
        }




        //Window modification
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
