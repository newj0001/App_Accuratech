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
using Common;
using Common.ViewModel;
using WPF.ViewModel;

namespace WPF.View
{
    /// <summary>
    /// Interaction logic for EditGeneralMenuSettingsView.xaml
    /// </summary>
    public partial class EditGeneralMenuSettingsView : UserControl
    {
        public EditGeneralMenuSettingsView()
        {
            InitializeComponent();
        }

        EditGeneralMenuSettingsViewModel EditGeneralMenuSettingsViewModel => DataContext as EditGeneralMenuSettingsViewModel;

        private async void BtnUpdateMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            await EditGeneralMenuSettingsViewModel.Update();
        }
    }
}
