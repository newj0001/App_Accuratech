using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Common;
using EO.Wpf;

namespace WPF.ViewModel
{
    public class EditGeneralMenuSettingsViewModel : INotifyPropertyChanged
    {
        MenuItemDataStore menuItemDataStore = new MenuItemDataStore();
        private readonly MenuItemEntityModel _parentMenuItem;

        public string MenuItemTitle { get; set; }
        public IsMenuEnabled SelectedElementInIsMenuEnabled { get; set; }
        public EditGeneralMenuSettingsViewModel(MenuItemEntityModel menuItem)
        {
            _parentMenuItem = menuItem;
        }
        public async Task Update()
        {
            var menuItem = new MenuItemEntityModel
            {
                Header = MenuItemTitle,
                IsMenuEnabled = SelectedElementInIsMenuEnabled.ToString(),
                Id = _parentMenuItem.Id
            };
            await menuItemDataStore.UpdateItemAsync(menuItem, _parentMenuItem.Id);
            MenuItemUpdated?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler MenuItemUpdated;

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
