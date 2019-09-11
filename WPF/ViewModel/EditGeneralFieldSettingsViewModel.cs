using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.Services;
using EO.Internal;
using EO.Wpf;

namespace WPF.ViewModel
{
    public class EditGeneralFieldSettingsViewModel : INotifyPropertyChanged
    {
        private readonly FieldItemDataStore _fieldItemDataStore = new FieldItemDataStore();
        private readonly SubItemEntityModel _parentSubItem;
      
        public string SubItemTitle { get; set; }
        public int FieldMinLength { get; set; }
        public int FieldMaxLength { get; set; }
        public FieldEnabled SelectedElementInFieldEnabled { get; set; }
        public NumericField SelectedElementInNumericField { get; set; }
        public KeyboardInput SelectedElementInKeyboardInput { get; set; }
        public EmptyField SelectedElementInEmptyField { get; set; }
        public KeepFieldValue SelectedElementInKeepFieldValue { get; set; }

        public EditGeneralFieldSettingsViewModel(SubItemEntityModel subItem)
        {
            _parentSubItem = subItem;
        }

        public async Task Update()
        {
            var subItem = new SubItemEntityModel
            {
                Name = SubItemTitle,
                FieldValue = SubItemTitle,
                FieldEnabled = SelectedElementInFieldEnabled.ToString(),
                NumericField = SelectedElementInNumericField.ToString(),
                FieldMinLength = FieldMinLength,
                FieldMaxLength = FieldMaxLength,
                KeyboardInput = SelectedElementInKeyboardInput.ToString(),
                EmptyField = SelectedElementInEmptyField.ToString(),
                KeepFieldValue = SelectedElementInKeepFieldValue.ToString(),
                Id = _parentSubItem.Id,
                MenuItemId = _parentSubItem.MenuItemId
            };
            await _fieldItemDataStore.UpdateItemAsync(subItem, _parentSubItem.Id);
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
