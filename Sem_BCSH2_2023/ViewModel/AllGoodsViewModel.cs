using CommunityToolkit.Mvvm.Input;
using Sem_BCSH2_2023.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Sem_BCSH2_2023.ViewModel
{
    public class AllGoodsViewModel: BaseViewModel
    {
    //    Order actualOrder;

    //    private int _id;
    //    private int _customerId;
    //    private double _orderPrice;
    //    private DateTime _orderDate;
    //    private bool _done;
    //    private DateTime? _doneDate;
    //    private ObservableCollection<Good> _listOfGoods;
    //    private string _fullname;


    //    private ObservableCollection<Good> _goodsListShow;

    //    public ICommand BtnAddRowCommand { get; private set; }
    //    public ICommand DoneAddGoodsToOrderComm { get; private set; }


    //    public ICommand CloseCommand { get; private set; }
    //    public ICommand MaximizeCommand { get; private set; }
    //    public ICommand MinimizeCommand { get; private set; }


    //    public AllGoodsViewModel(Order ord)
    //    {
    //        actualOrder = ord;

    //        GoodsListShow = GoodViewModel.GoodsList;

    //        BtnAddRowCommand = new RelayCommand<int>(AddRowToOrder);
    //        DoneAddGoodsToOrderComm = new CommandViewModel(_ => DoneAdd());

    //        CloseCommand = new CommandViewModel(_ => Close());
    //        MaximizeCommand = new CommandViewModel(_ => Maximize());
    //        MinimizeCommand = new CommandViewModel(_ => Minimize());

    //    }

    //    private static void DoneAdd()
    //    {
    //        var window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
    //        window?.Close();
    //    }

    //    private void AddRowToOrder(int selectedID)
    //    {
    //        Good? good = GoodViewModel.GoodsList.FirstOrDefault(objekt => objekt.Id == selectedID);

    //        if (good != null)
    //        {
    //            MessageBox.Show($"Object with ID {selectedID} added to the order.", "Added to Order", MessageBoxButton.OK);

    //            GoodViewModel.GoodsList.Remove(good);
    //            actualOrder.SellGoods(good);


    //        }
    //    }


    //    private static void Close()
    //    {
    //        var window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
    //        window?.Close();
    //    }

    //    private static void Maximize()
    //    {
    //        var window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);

    //        if (window != null)
    //        {
    //            if (window.WindowState == WindowState.Normal)
    //            {
    //                window.WindowState = WindowState.Maximized;
    //            }
    //            else
    //            {
    //                window.WindowState = WindowState.Normal;
    //            }
    //        }
    //    }

    //    private static void Minimize()
    //    {
    //        var window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);

    //        if (window != null)
    //        {
    //            window.WindowState = WindowState.Minimized;
    //        }
    //    }



    //    public ObservableCollection<Good> GoodsListShow
    //    {
    //        get => _goodsListShow;
    //        set => SetProperty(ref _goodsListShow, value, nameof(GoodsListShow));
    //    }



    //    public int Id
    //    {
    //        get => _id;
    //        set => SetProperty(ref _id, value, nameof(Id));
    //    }
    //    public int CustomerId
    //    {
    //        get => _customerId;
    //        set => SetProperty(ref _customerId, value, nameof(CustomerId));
    //    }
    //    public double OrderPrice
    //    {
    //        get => _orderPrice;
    //        set => SetProperty(ref _orderPrice, value, nameof(OrderPrice));
    //    }
    //    public DateTime DateOfCreation
    //    {
    //        get => _orderDate;
    //        set => SetProperty(ref _orderDate, value, nameof(DateOfCreation));
    //    }
    //    public ObservableCollection<Good> ListOfGoods
    //    {
    //        get => _listOfGoods;
    //        set => SetProperty(ref _listOfGoods, value, nameof(ListOfGoods));
    //    }
    //    public bool Done
    //    {
    //        get => _done;
    //        set => SetProperty(ref _done, value, nameof(Done));
    //    }
    //    public DateTime? DateCompletion
    //    {
    //        get => _doneDate;
    //        set => SetProperty(ref _doneDate, value, nameof(DateCompletion));
    //    }

    //    public string FullName
    //    {
    //        get => _fullname;
    //        set => SetProperty(ref _fullname, value, nameof(FullName));
    //    }
    }
}
