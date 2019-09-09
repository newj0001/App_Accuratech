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
        private readonly SubItemEntityModel _parentSubItem;

        public string SubItemTitle { get; set; }

        public EditGeneralFieldSettingsViewModel(SubItemEntityModel subItem)
        {
            _parentSubItem = subItem;
        }

        public async Task Update()
        {
            var subItem = new SubItemEntityModel {Name = SubItemTitle};
            await Processor.UpdateFieldItemAsync(subItem, _parentSubItem.Id);
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
