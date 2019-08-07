using Library;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.ViewModel
{
    public class MenuViewModel
    {
        public ObservableCollection<MenuModel> Menus { get; set; }
        public MenuProcessor Load { get; set; }

        public void LoadMenus()
        {
            ObservableCollection<MenuModel> menuCollection = new ObservableCollection<MenuModel>();

            menuCollection.Add(new MenuModel { Title = "NewTitle", Description = "Des" });

            Menus = menuCollection;
        }
    }
}
