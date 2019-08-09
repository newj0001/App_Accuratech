using Library;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPF.ViewModel
{
    public class MenuViewModel : INotifyPropertyChanged
    {
        //private ICollection<MenuTable> menus;

        //public ICollection<MenuTable> Menus {
        //    get => menus;
        //    set {
        //        menus = value;
        //        RaisePropertyChanged();
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

    //public int Id
    //    {
    //        get { return m.Id; }
    //        set
    //        {
    //            if (m.Id != value)
    //                m.Id = value;
    //            RaisePropertyChanged("Id");
    //            RaisePropertyChanged("MenuItem");
    //        }
    //    }
    //    public string Title
    //    {
    //        get { return m.Title; }
    //        set
    //        {
    //            if (m.Title != value)
    //                m.Title = value;
    //            RaisePropertyChanged("Title");
    //            RaisePropertyChanged("MenuItem");
    //        }
    //    }

    //    public string Description
    //    {
    //        get { return m.Description; }
    //        set
    //        {
    //            if (m.Description != value)
    //                m.Description = value;
    //            RaisePropertyChanged("Description");
    //            RaisePropertyChanged("MenuItem");
    //        }
    //    }


        //public ObservableCollection<MenuModel> Menus { get; set; }
        //public MenuProcessor Load { get; set; }

        //public void LoadMenus()
        //{
        //    ObservableCollection<MenuModel> menuCollection = new ObservableCollection<MenuModel>();

        //    menuCollection.Add(new MenuModel { Title = "NewTitle", Description = "Des" });

        //    Menus = menuCollection;
        //}

        //public async void Load()
        //{
        //    var menus = await MenuProcessor.LoadMenus();

        //    foreach(var menuItem in menus)
        //    {

        //    }
        //}

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