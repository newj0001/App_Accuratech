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
            if (MainWindowViewModel != null) await MainWindowViewModel?.Reset();
        }

        MainWindowViewModel MainWindowViewModel => DataContext as MainWindowViewModel;

        private void ButtonPopUpLogout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnAddMenu_Click(object sender, RoutedEventArgs e)
        {
            var addNewMenuViewModel = new MenuConfigurationViewModel();
            addNewMenuViewModel.NewMenuItemCreated += async (_, __) => await MainWindowViewModel?.Reset();
            var addNewMenuView = new MenuConfigurationView { DataContext = addNewMenuViewModel };
            Main.Content = addNewMenuView;
        }

        private void AddNewField(object sender, RoutedEventArgs e)
        {
            var button = (Button) sender;
            var menuItem = (MenuItemEntity) button.DataContext;
            var fieldConfigurationViewModel = new FieldConfigurationViewModel(menuItem);
            fieldConfigurationViewModel.NewSubItemCreated += async (_, __) => await MainWindowViewModel?.Reset();
            var fieldConfigurationView = new FieldConfigurationView { DataContext = fieldConfigurationViewModel };
            Main.Content = fieldConfigurationView;
        }
    }
}
