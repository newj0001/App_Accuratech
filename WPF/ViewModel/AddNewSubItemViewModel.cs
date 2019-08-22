using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common;
using Common.ViewModel;

namespace WPF.ViewModel
{
    public class AddNewSubItemViewModel
    {
        private readonly MenuItemEntity _parentMenuItem;

        public AddNewSubItemViewModel(MenuItemEntity menuItem)
        {
            _parentMenuItem = menuItem;
        }

        public string SubItemTitle { get; set; }


        public async Task AddSubItem()
        {
            var subItem = new SubItemEntity() { Name = SubItemTitle, MenuItemId = _parentMenuItem.Id};
            await Processor.CreateSubMenu(subItem);
            NewSubItemCreated?.Invoke(this, EventArgs.Empty);
        }

        //public async Task DeleteSubItem()
        //{
        //    var subItem = new SubItemEntity();
        //    await Processor.DeleteSubItem(subItem);
        //    SubItemRemoved?.Invoke(this, EventArgs.Empty);
            
        //}
        public event EventHandler NewSubItemCreated;
        //public event EventHandler SubItemRemoved;
    }
}
