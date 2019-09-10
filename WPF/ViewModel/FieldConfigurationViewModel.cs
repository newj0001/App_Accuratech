using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common;
using Common.Services;
using Common.ViewModel;

namespace WPF.ViewModel
{
    public class FieldConfigurationViewModel
    {
        FieldItemDataStore fieldItemDataStore = new FieldItemDataStore();
        private readonly MenuItemEntityModel _parentMenuItem;
        private readonly SubItemEntityModel _parentSubItem;

        public FieldConfigurationViewModel(MenuItemEntityModel menuItem)
        {
            _parentMenuItem = menuItem;
        }

        public FieldConfigurationViewModel(SubItemEntityModel subItem)
        {
            _parentSubItem = subItem;
        }

        public string SubItemTitle { get; set; }
        public bool IsFieldEnabled { get; set; }

        public async Task AddField()
        {
            var subItem = new SubItemEntityModel()
            {
                Name = SubItemTitle,
                MenuItemId = _parentMenuItem.Id,
                FieldEnabled = IsFieldEnabled
            };
            await fieldItemDataStore.AddItemAsync(subItem);
            NewSubItemCreated?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler NewSubItemCreated;
    }
}
