using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using App.Annotations;
using Common;

namespace App.ViewModel
{
    public class NewItemViewModel : INotifyPropertyChanged
    {
        
        public NewItemViewModel()
        {
          
        }
        public async Task Add(ICollection<RegistrationValue> registrationValues)
        {
          
            await Processor.CreateRegistrationValue(registrationValues);
            NewRegistrationValueCreated?.Invoke(this, EventArgs.Empty);
        }
        public event EventHandler NewRegistrationValueCreated;


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
