using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace WPF.ViewModel
{
    public enum IsMenuEnabled
    {
        Enabled,
        Disabled
    }
    public class GeneralMenuSettingsViewModel
    {
        private readonly MenuItemDataStore _menuItemDataStore = new MenuItemDataStore();

        public string MenuItemTitle { get; set; }
        public IsMenuEnabled SelectedElementInIsMenuEnabled { get; set; }

        public async Task AddMenuItem()
        {
            var menuItem = new MenuItemEntityModel
            {
                Header = MenuItemTitle,
                IsMenuEnabled = SelectedElementInIsMenuEnabled.ToString()
            };
            await _menuItemDataStore.AddItemAsync(menuItem);
            NewMenuItemCreated?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler NewMenuItemCreated;
    }
}
