using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Common;
using EO.Internal;

namespace WPF.ViewModel
{
    public class EditGeneralFieldSettingsViewModel : INotifyPropertyChanged
    {
        private readonly MenuItemEntityModel _parentMenuItem;

        public string FieldItemTitle { get; set; }

        public EditGeneralFieldSettingsViewModel(MenuItemEntityModel menuItem)
        {
            _parentMenuItem = menuItem;
        }

        public async Task Update()
        {
            var subItem = new SubItemEntityModel {Name = FieldItemTitle, MenuItemId = _parentMenuItem.Id};
            await Processor.UpdateFieldItemAsync(subItem, _parentMenuItem.Id);
            SubItemUpdated?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler SubItemUpdated;


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
