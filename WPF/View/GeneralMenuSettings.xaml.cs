using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF.ViewModel;

namespace WPF.View
{
    /// <summary>
    /// Interaction logic for GeneralMenuSettings.xaml
    /// </summary>
    public partial class GeneralMenuSettings : UserControl
    {
        public GeneralMenuSettings()
        {
            InitializeComponent();
        }

        public MenuConfigurationViewModel MenuViewModel => DataContext as MenuConfigurationViewModel;

        private async void BtnSaveMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            await MenuViewModel.Add();
        }

        private void BtnCancelMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
