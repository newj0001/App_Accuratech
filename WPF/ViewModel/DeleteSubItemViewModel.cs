using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace WPF.ViewModel
{
    public class DeleteSubItemViewModel
    {
        private readonly MenuItemEntity _parentMenuItem;

        public DeleteSubItemViewModel(MenuItemEntity menuItem)
        {
            _parentMenuItem = menuItem;
        }

        public async Task DeleteSubItem()
        {
            var subItem = new SubItemEntity();
            await Processor.DeleteSubItem(subItem);
            SubItemRemoved?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler SubItemRemoved;
    }
}
