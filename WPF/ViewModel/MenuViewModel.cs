//using Library;
using Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPF.ViewModel
{
    public class MenuViewModel : INotifyPropertyChanged
    {
        //private ICollection<MenuItemEntity> menus;

        //public ICollection<MenuItemEntity> Menus
        //{
        //    get => menus;
        //    set
        //    {
        //        menus = value;
        //        NotifyPropertyChanged();
        //    }
        //}

        //public MenuViewModel()
        //{
        //    LoadMenu();
        //}

        //public async void LoadMenu()
        //{
        //    Menus = await MenuProcessor.LoadMenus();
        //}

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string property = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}