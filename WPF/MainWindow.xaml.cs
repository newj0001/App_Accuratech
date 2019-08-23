//using Library;
using Common;
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
using Common.ViewModel;
using WPF.View;
using WPF.ViewModel;

namespace WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
             InitializeComponent();
            ApiHelper.InitializeClient();
            DataContextChanged += Reset;
            DataContext = new MainWindowViewModel();
        }

        private async void Reset(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (ItemMenuViewModel != null) await ItemMenuViewModel?.Reset();
        }

        MainWindowViewModel ItemMenuViewModel => DataContext as MainWindowViewModel;

        private void ButtonPopUpLogout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnAddMenu_Click(object sender, RoutedEventArgs e)
        {
            var addNewMenuViewModel = new AddNewMenuHeaderViewModel();
            addNewMenuViewModel.NewMenuItemCreated += async (_, __) => await ItemMenuViewModel?.Reset();
            var addNewMenuView = new AddNewMenuView { DataContext = addNewMenuViewModel };
            Main.Content = addNewMenuView;
        }

        private void AddNewField(object sender, RoutedEventArgs e)
        {
            var button = (Button) sender;
            var menuItem = (MenuItemEntity) button.DataContext;
            var addNewSubMenuViewModel = new FieldConfigurationViewModel(menuItem);
            addNewSubMenuViewModel.NewSubItemCreated += async (_, __) => await ItemMenuViewModel?.Reset();
            var addNewSubMenuView = new AddNewSubItemView { DataContext = addNewSubMenuViewModel };
            Main.Content = addNewSubMenuView;
        }
    }
}
