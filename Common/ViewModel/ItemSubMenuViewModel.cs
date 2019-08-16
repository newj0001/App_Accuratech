using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModel
{
    public class ItemSubMenuViewModel : INotifyPropertyChanged
    {
        private MenuItemEntity _menuItemEntity;
        public MenuItemEntity MenuItemEntity
        {
            get => _menuItemEntity;
            set
            {
                _menuItemEntity = value;
                NotifyPropertyChanged();
            }
        }

        public void Reset(MenuItemEntity menuItemEntity)
        {
            MenuItemEntity = menuItemEntity;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
