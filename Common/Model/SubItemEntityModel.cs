using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class SubItemEntityModel : INotifyPropertyChanged
    {
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
        public string FieldValue { get; set; } = string.Empty;
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
