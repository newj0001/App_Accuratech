using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModel
{
    public class NewItemViewModel : INotifyPropertyChanged
    {
        private readonly SubItemEntity _parentSubItem;
        private SubItemEntity _subItemEntity;

        public NewItemViewModel(SubItemEntity subItem)
        {
            _parentSubItem = subItem;
        }

        public SubItemEntity SubItemEntity
        {
            get => _subItemEntity;
            set
            {
                _subItemEntity = value;
                NotifyPropertyChanged();
            }
        }

        public string FieldValue { get; set; }
        public async Task AddRegistrationValue(string fieldValue)
        {
            ICollection<RegistrationValue> registrationValues = new List<RegistrationValue>();
            var regItem = new RegistrationValue()
            {
                SubItemId = _parentSubItem.Id,
                SubItemEntity = _parentSubItem,
                Value = fieldValue
            };
            registrationValues.Add(regItem);
            await Processor.CreateRegistrationValue(registrationValues);
            NewRegistrationValueCreated?.Invoke(this, EventArgs.Empty);
        }

        public void Reset(SubItemEntity subItemEntity)
        {
            SubItemEntity = subItemEntity;
        }

        public event EventHandler NewRegistrationValueCreated;
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
