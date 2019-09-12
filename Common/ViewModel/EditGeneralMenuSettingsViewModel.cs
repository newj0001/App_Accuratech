using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Common.ViewModel
{
    public class EditGeneralMenuSettingsViewModel : INotifyPropertyChanged
    {
        MenuItemDataStore menuItemDataStore = new MenuItemDataStore();
        private readonly MenuItemEntityModel _parentMenuItem;

        public string MenuItemTitle { get; set; }
        public bool SelectedElementInIsMenuEnabled { get; set; }
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
