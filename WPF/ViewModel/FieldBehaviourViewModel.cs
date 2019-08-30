using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Common.Commands;
using WPF.Annotations;

namespace WPF.ViewModel
{
    public class FieldBehaviourViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<string> _dataTypes;
        public ICommand Command { get; set; }

        public ObservableCollection<string> DataTypes
        {
            get => _dataTypes;
            set
            {
                _dataTypes = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
