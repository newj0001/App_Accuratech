using Common.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Common.ViewModel
{
    public class EditGeneralMenuSettingsViewModel : INotifyPropertyChanged
    {
        MenuItemDataStore _menuItemDataStore = new MenuItemDataStore();
        FieldItemDataStore _fieldItemDataStore = new FieldItemDataStore();
        private readonly MenuItemEntityModel _parentMenuItem;
        private ICollection<MenuItemEntityModel> _menuItemsCollection;
        private ICollection<SubItemEntityModel> _subItemsCollection;

        public EditGeneralMenuSettingsViewModel(MenuItemEntityModel menuItem)
        {
            _parentMenuItem = menuItem;
        }


        public bool SelectedElementInIsMenuEnabled { get; set; }

        public async Task Update()
        {
            var menuItem = new MenuItemEntityModel
            {
                Header = _parentMenuItem.Header,
                IsMenuEnabled = SelectedElementInIsMenuEnabled.ToString(),
                Id = _parentMenuItem.Id
            };
            await _menuItemDataStore.UpdateItemAsync(menuItem, _parentMenuItem.Id);
            MenuItemUpdated?.Invoke(this, EventArgs.Empty);
        }

        public ICollection<MenuItemEntityModel> MenuItemsCollection
        {
            get => _menuItemsCollection;
            set
            {
                _menuItemsCollection = value;
                NotifyPropertyChanged();
            }
        }

        public ICollection<SubItemEntityModel> SubItemsCollection
        {
            get => _subItemsCollection;
            set
            {
                _subItemsCollection = value;
                NotifyPropertyChanged();
            }
        }

        public async Task Reset()
        {
            MenuItemsCollection = await _menuItemDataStore.GetItemsAsync();
            SubItemsCollection = await _fieldItemDataStore.GetItemsAsync();
        }

        public event EventHandler MenuItemUpdated;

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
