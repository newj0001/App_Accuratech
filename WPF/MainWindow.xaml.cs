//using Library;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
using WPF.ViewModel;

namespace WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 


    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var menuRegister = new List<SubItemViewModel>();
            menuRegister.Add(new SubItemViewModel("Customer", new UserControlCustomers()));
            menuRegister.Add(new SubItemViewModel("Providers", new UserControlProviders()));
            menuRegister.Add(new SubItemViewModel("Employees"));
            menuRegister.Add(new SubItemViewModel("Products"));
            var item6 = new ItemMenuViewModel("Register", menuRegister, PackIconKind.Register);

            var menuSchedule = new List<SubItemViewModel>();
            menuSchedule.Add(new SubItemViewModel("Services"));
            menuSchedule.Add(new SubItemViewModel("Meetings"));
            var item1 = new ItemMenuViewModel("Appointments", menuSchedule, PackIconKind.Schedule);

            var menuReports = new List<SubItemViewModel>();
            menuReports.Add(new SubItemViewModel("Customers"));
            menuReports.Add(new SubItemViewModel("Providers"));
            menuReports.Add(new SubItemViewModel("Products"));
            menuReports.Add(new SubItemViewModel("Stock"));
            menuReports.Add(new SubItemViewModel("Sales"));
            var item2 = new ItemMenuViewModel("Reports", menuReports, PackIconKind.FileReport);

            var menuExpenses = new List<SubItemViewModel>();
            menuExpenses.Add(new SubItemViewModel("Fixed"));
            menuExpenses.Add(new SubItemViewModel("Variable"));
            var item3 = new ItemMenuViewModel("Expenses", menuExpenses, PackIconKind.ShoppingBasket);

            var menuFinancial = new List<SubItemViewModel>();
            menuFinancial.Add(new SubItemViewModel("Cash flow"));
            var item4 = new ItemMenuViewModel("Financial", menuFinancial, PackIconKind.ScaleBalance);

            Menu.Children.Add(new UserControlMenuItem(item6, this));
            Menu.Children.Add(new UserControlMenuItem(item2, this));
            Menu.Children.Add(new UserControlMenuItem(item3, this));
            Menu.Children.Add(new UserControlMenuItem(item4, this));

            //ApiHelper.InitializeClient();
            //DataContext = new MenuViewModel();
        }

        internal void SwitchScreen(object sender)
        {
            var screen = ((UserControl)sender);

            if (screen!=null)
            {
                StackPanelMain.Children.Clear();
                StackPanelMain.Children.Add(screen);
            }
        }
    }
}
