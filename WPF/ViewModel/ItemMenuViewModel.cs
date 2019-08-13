using Common;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPF.ViewModel
{
    public class ItemMenuViewModel : INotifyPropertyChanged
    {
        private ICollection<MenuItemEntity> _menuItemsCollection;

        public ICollection<MenuItemEntity> MenuItemsCollection
        {
            get { return _menuItemsCollection; }
            set
            {
                _menuItemsCollection = value;
                NotifyPropertyChanged();
            }
        }

        public ItemMenuViewModel()
        {
        }

        public async Task Reset()
        {
            MenuItemsCollection = await MenuItemProcessor.LoadMenus();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
