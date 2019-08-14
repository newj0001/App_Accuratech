using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModel
{
    public class ItemSubMenuViewModel : INotifyPropertyChanged
    {
        private ICollection<SubItemEntity> _subMenuItemsCollection;

        public ICollection<SubItemEntity> SubMenuItemsCollection
        {
            get { return _subMenuItemsCollection; }
            set
            {
                _subMenuItemsCollection = value;
                NotifyPropertyChanged();
            }
        }

        public async Task Reset()
        {
            SubMenuItemsCollection = await SubItemProcessor.LoadSubMenus();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
