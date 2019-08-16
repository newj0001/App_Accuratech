using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common;

namespace WPF.ViewModel
{
    public class AddNewSubItemViewModel
    {
        public string SubItemTitle { get; set; }

        public async Task AddSubItem()
        {
            var subItem = new SubItemEntity() {Name = SubItemTitle};
            await MenuItemProcessor.CreateSubMenu(subItem);
            NewSubItemCreated?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler NewSubItemCreated;
    }
}
