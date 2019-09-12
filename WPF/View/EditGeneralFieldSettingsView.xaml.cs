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
using Common.ViewModel;

namespace WPF.View
{
    /// <summary>
    /// Interaction logic for EditGeneralFieldSettingsView.xaml
    /// </summary>
    public partial class EditGeneralFieldSettingsView : UserControl
    {
        public EditGeneralFieldSettingsView()
        {
            InitializeComponent();
        }

        EditGeneralFieldSettingsViewModel EditGeneralFieldSettingsViewModel => DataContext as EditGeneralFieldSettingsViewModel;
        private async void BtnUpdateFieldItem_OnClick(object sender, RoutedEventArgs e)
        {
            await EditGeneralFieldSettingsViewModel.Update();
        }
    }
}
