using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Common.Services;

namespace Common.ViewModel
{
    public class EditGeneralFieldSettingsViewModel
    {
        #region Enums
        public enum FieldEnabled
        {
            Yes,
            No
        }
        public enum NumericField
        {
            Yes,
            No
        }
        public enum KeyboardInput
        {
            Enabled,
            Disabled
        }
        public enum EmptyField
        {
            Yes,
            No
        }
        public enum KeepFieldValue
        {
            Yes,
            No
        }
        #endregion Enums

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
                IsFieldEnabled = SelectedElementInFieldEnabled.ToString(),
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
