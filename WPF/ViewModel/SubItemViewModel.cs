using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPF.ViewModel
{
    public class SubItemViewModel
    {
        public SubItemViewModel(string name, UserControl screen = null)
        {
            Name = name;
        }
        public string Name { get; private set; }
    }
}
