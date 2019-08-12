using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPF.ViewModel
{
    public class ItemMenuViewModel
    {
        public ItemMenuViewModel(string header, List<SubItemViewModel> subItems, PackIconKind icon)
        {
            Header = header;
            SubItems = subItems;
            Icon = icon;
        }

        public string Header { get; set; }
        public PackIconKind Icon { get; set; }
        public List<SubItemViewModel> SubItems { get; set; }
        public UserControl Screen { get; set; }
    }
}
