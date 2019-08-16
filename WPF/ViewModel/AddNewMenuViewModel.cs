using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.ViewModel
{
    public class AddNewMenuViewModel
    {
        public string MenuItemTitle { get; set; }

        public async Task Add()
        {
            var menuItem = new MenuItemEntity {Header = MenuItemTitle};
            await MenuItemProcessor.CreateMenu(menuItem);
            NewMenuItemCreated?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler NewMenuItemCreated;
    }
}
