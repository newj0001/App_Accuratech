using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Common;
using Xamarin.Forms;

namespace App.ViewModel
{
    public class AddRegistrationValueViewModel : INotifyPropertyChanged
    {
        private ICollection<SubItemEntity> _subItemsCollection;
        private ICollection<MenuItemEntity> _menuItemsCollection;

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

        public async Task Reset()
        {
            _subItemsCollection = await Processor.LoadSubItems();
            _menuItemsCollection = await Processor.LoadMenus();
        }

        async Task SaveRegistrationValue()
        {
            await Task.Delay(4000);
            await Application.Current.MainPage.DisplayAlert("Alert", "You have been alerted", "OK");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
