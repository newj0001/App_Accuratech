using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.Services;
using Common.ViewModel;
using Xamarin.Forms;

namespace UI_Mobile.ViewModels
{
    public class FieldItemsViewModel : INotifyPropertyChanged
    {
        public SubItemEntityModel Item { get; set; }
        private readonly RegistrationValueDataStore _datastore;
        private SubItemEntityModel _parentSubItem;
        private MenuItemEntityModel _menuItemEntityModel;
        private ICollection<SubItemEntityModel> _subItemsCollection;
        FieldItemDataStore fieldItemDataStore = new FieldItemDataStore();


        public ICollection<SubItemEntityModel> SubItemsCollection
        {
            get => _subItemsCollection;
            set
            {
                _subItemsCollection = value;
                NotifyPropertyChanged();
            }
        }

        public MenuItemEntityModel MenuItemEntityModel
        {
            get => _menuItemEntityModel;
            set
            {
                _menuItemEntityModel = value;
                NotifyPropertyChanged();
            }
        }

        public FieldItemsViewModel(SubItemEntityModel paramSubItem)
        {
            _parentSubItem = paramSubItem;
            _datastore = new RegistrationValueDataStore();
        }

        public FieldItemsViewModel()
        {
            
            _datastore = new RegistrationValueDataStore();
        }

        private static bool ValidateNumericField(SubItemEntityModel subItemEntity)
        {
            switch (subItemEntity.NumericField.ToUpper())
            {
                case "YES":
                    var res = int.TryParse(subItemEntity.FieldValue, out var _);
                    return res;

                default:
                    return true;
            }
        }

        private static bool ValidateLength(SubItemEntityModel subItemEntity)
        {
            int minlen = subItemEntity.FieldMinLength;
            int maxlen = subItemEntity.FieldMaxLength;

            var minValid = subItemEntity.FieldMinLength <= minlen;
            var maxValid = true;

            if (maxlen > 0)
            {
                maxValid = subItemEntity.FieldMaxLength >= maxlen;
            }

            return minValid && maxValid;
        }

        public async Task AddRegistrationValue(SubItemEntityModel subItemEntity)
        {
            if (subItemEntity == null) return;

            if (!ValidateLength(subItemEntity))
            {
                // feedback
                return;
            }

            if (!ValidateNumericField(subItemEntity))
            {
                //feedback til bruger
                return;
            }

            var fieldValue = _parentSubItem.FieldValue;


            ICollection<RegistrationValueModel> registrationValues = new List<RegistrationValueModel>();
            var subItem = new RegistrationValueModel()
            {
                SubItemId = _parentSubItem.Id,
                SubItemEntityModel = _parentSubItem,
                Value = fieldValue
            }; 
            registrationValues.Add(subItem);
            await _datastore.AddItemAsync(registrationValues);
            NewRegistrationValueCreated?.Invoke(this, EventArgs.Empty);
        }

        public void Reset(MenuItemEntityModel menuItemEntityModel)
        {
            MenuItemEntityModel = menuItemEntityModel;
        }
        public async void Reset()
        {
            SubItemsCollection = await fieldItemDataStore.GetItemsAsync();
        }

        public event EventHandler NewRegistrationValueCreated;

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
