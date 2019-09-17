using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class SubItemEntityModel : INotifyPropertyChanged
    {
        public SubItemEntityModel()
        {
            FieldValue = string.Empty;
        }
        public int Id { get; set; }

        private string _name;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                NotifyPropertyChanged();
            }
        }

        public int? MenuItemId { get; set; }
        private string _fieldValue = string.Empty;

        [Required(ErrorMessage = "Field value cannot be empty")]
        public string FieldValue
        {
            get => _fieldValue;
            set
            {
                if (_fieldValue == value)
                    return;

                _fieldValue = value;
                NotifyPropertyChanged();
            }
        }

        public string FieldEnabled { get; set; }
        public string NumericField { get; set; }
        public int FieldMinLength { get; set; }
        public int FieldMaxLength { get; set; }
        public string KeyboardInput { get; set; }
        public string EmptyField { get; set; }
        public string KeepFieldValue { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
