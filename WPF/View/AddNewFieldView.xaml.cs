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
    /// Interaction logic for AddNewSubItemView.xaml
    /// </summary>
    public partial class AddNewSubItemView : Page
    {
        public AddNewSubItemView()
        {
            InitializeComponent();
        }

        public AddNewFieldViewModel AddNewSubItemViewModel => DataContext as AddNewFieldViewModel;
        private async void BtnSaveSubItem_OnClick(object sender, RoutedEventArgs e)
        {
             await AddNewSubItemViewModel.AddSubItem();
        }
    }
}
