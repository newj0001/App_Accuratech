using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Common.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private ICollection<MenuItemEntity> _menuItemsCollection;
        private ICollection<SubItemEntity> _subItemsCollection;
        private MenuItemEntity _menuItemEntity;
        private RegistrationValue _registrationValue;
        private ICollection<Registration> _registrations;

        public ICollection<MenuItemEntity> MenuItemsCollection
        {
            get => _menuItemsCollection;
            set
            {
                _menuItemsCollection = value;
                NotifyPropertyChanged();
            }
        }

        public ICollection<SubItemEntity> SubItemsCollection
        {
            get => _subItemsCollection;
            set
            {
                _subItemsCollection = value;
                NotifyPropertyChanged();
            }
        }

        public MenuItemEntity MenuItemEntity
        {
            get => _menuItemEntity;
            set
            {
                _menuItemEntity = value;
                NotifyPropertyChanged();
            }
        }

        public ICollection<Registration> Registrations
        {
            get => _registrations;
            set
            {
                _registrations = value;
                NotifyPropertyChanged();
            }
        }

        public RegistrationValue RegistrationValue
        {
            get => _registrationValue;
            set
            {
                _registrationValue = value;
                NotifyPropertyChanged();
            }
        }

        public async Task Reset()
        {
            MenuItemsCollection = await Processor.LoadMenus();
            SubItemsCollection = await Processor.LoadSubItems();
            Registrations = await Processor.LoadRegistrations();
        }

        public void Reset(MenuItemEntity menuItemEntity)
        {
            MenuItemEntity = menuItemEntity;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}