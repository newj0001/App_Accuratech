using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Library;
using RESTWebservice.Model;

namespace App_Accurratech.ViewModel
{
    public class MobileMenuViewModel : INotifyPropertyChanged
    {
        private ICollection<MenuTable> menus;

        public ICollection<MenuTable> Menus
        {
            get => menus;
            set
            {
                menus = value;
                RaisePropertyChanged();
            }
        }


        public MobileMenuViewModel()
        {
            LoadMenu();
        }

        public async void LoadMenu()
        {
            Menus = await MenuProcessor.LoadMenus();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string property = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
