using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.Services;

namespace WPF.ViewModel
{
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
    public class GeneralFieldSettingsViewModel
    {
       private readonly FieldItemDataStore  _fieldItemDataStore = new FieldItemDataStore();
       private readonly MenuItemEntityModel _parentMenuItem;

       public string SubItemTitle { get; set; }
       public int FieldMinLength { get; set; }
       public int FieldMaxLength { get; set; }
       public FieldEnabled SelectedElementInFieldEnabled { get; set; }
       public NumericField SelectedElementInNumericField { get; set; }
       public KeyboardInput SelectedElementInKeyboardInput { get; set; }
       public EmptyField SelectedElementInEmptyField { get; set; }

       public GeneralFieldSettingsViewModel(MenuItemEntityModel menuItem)
       {
           _parentMenuItem = menuItem;
       }

       public async Task AddFieldItem()
       {
           var subItem = new SubItemEntityModel()
           {
               Name = SubItemTitle,
               FieldValue = SubItemTitle,
               FieldEnabled = SelectedElementInFieldEnabled.ToString(),
               NumericField = SelectedElementInNumericField.ToString(),
               FieldMinLength = FieldMinLength,
               FieldMaxLength = FieldMaxLength,
               KeyboardInput = SelectedElementInKeyboardInput.ToString(),
               EmptyField = SelectedElementInEmptyField.ToString(),
               MenuItemId = _parentMenuItem.Id,
           };
           await _fieldItemDataStore.AddItemAsync(subItem);
           NewSubItemCreated?.Invoke(this, EventArgs.Empty);
       }

       public event EventHandler NewSubItemCreated;
    }
}
