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
using System.Windows.Shapes;
using WPF.ViewModels;

namespace WPF.View
{
    /// <summary>
    /// Interaction logic for UpdateMenuItemView.xaml
    /// </summary>
    public partial class UpdateMenuItemView : Window
    {
        public UpdateMenuItemView()
        {
            InitializeComponent();
        }
        public CreateFieldItemViewModel CreateMenuItemViewModel => DataContext as CreateFieldItemViewModel;

        private void btnSaveMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancelMenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
