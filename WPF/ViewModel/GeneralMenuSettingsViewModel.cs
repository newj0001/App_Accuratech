using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace WPF.ViewModel
{
    public class GeneralMenuSettingsViewModel
    {
        private readonly MenuItemDataStore _menuItemDataStore = new MenuItemDataStore();

        public string MenuItemTitle { get; set; }

        public async Task AddMenuItem()
        {
            var menuItem = new MenuItemEntityModel { Header = MenuItemTitle };
            await _menuItemDataStore.AddItemAsync(menuItem);
            NewMenuItemCreated?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler NewMenuItemCreated;
    }
}
