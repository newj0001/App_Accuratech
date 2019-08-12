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

            var menuConfiguration = new List<SubItemViewModel>();
            menuConfiguration.Add(new SubItemViewModel("General", new UserControlGeneral()));
            var item0 = new ItemMenuViewModel("Configuration", menuConfiguration, PackIconKind.Register);

            var menuMain = new List<SubItemViewModel>();
            menuMain.Add(new SubItemViewModel("Add menu"));
            menuMain.Add(new SubItemViewModel("Order no."));
            var item1 = new ItemMenuViewModel("Receive", menuMain, PackIconKind.FileReport);

            Menu.Children.Add(new UserControlMenuItem(item0, this));
            Menu.Children.Add(new UserControlMenuItem(item1, this));
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
