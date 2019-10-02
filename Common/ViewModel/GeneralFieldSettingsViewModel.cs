using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.Services;

namespace Common.ViewModel
{
   

    //public class GeneralFieldSettingsViewModel
    //{
    //    private readonly FieldItemDataStore _fieldItemDataStore = new FieldItemDataStore();
    //    private readonly MenuItemEntityModel _parentMenuItem;

    //    public string SubItemTitle { get; set; }
    //    public int FieldMinLength { get; set; }
    //    public int FieldMaxLength { get; set; }
    //    public FieldEnabled SelectedElementInFieldEnabled { get; set; }
    //    public NumericField SelectedElementInNumericField { get; set; }
    //    public KeyboardInput SelectedElementInKeyboardInput { get; set; }
    //    public EmptyField SelectedElementInEmptyField { get; set; }
    //    public KeepFieldValue SelectedElementInKeepFieldValue { get; set; }

    //    public GeneralFieldSettingsViewModel(MenuItemEntityModel menuItem)
    //    {
    //        _parentMenuItem = menuItem;
    //    }

    //    public async Task AddFieldItem()
    //    {
    //        var subItem = new SubItemEntityModel()
    //        {
    //            Name = SubItemTitle,
    //            FieldValue = SubItemTitle,
    //            IsFieldEnabled = SelectedElementInFieldEnabled.ToString(),
    //            NumericField = SelectedElementInNumericField.ToString(),
    //            FieldMinLength = FieldMinLength,
    //            FieldMaxLength = FieldMaxLength,
    //            KeyboardInput = SelectedElementInKeyboardInput.ToString(),
    //            EmptyField = SelectedElementInEmptyField.ToString(),
    //            KeepFieldValue = SelectedElementInKeepFieldValue.ToString(),
    //            MenuItemId = _parentMenuItem.Id,
    //        };
    //        await _fieldItemDataStore.AddItemAsync(subItem);
    //        NewSubItemCreated?.Invoke(this, EventArgs.Empty);
    //    }

    //    public event EventHandler NewSubItemCreated;
    //}
}
