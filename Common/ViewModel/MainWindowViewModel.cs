using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Common.Commands;
using Xamarin.Forms;

namespace Common.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private ICollection<MenuItemEntityModel> _menuItemsCollection;
        private ICollection<SubItemEntityModel> _subItemsCollection;
        private MenuItemEntityModel _menuItemEntityModel;

        public MainWindowViewModel()
        {
            DeleteMenuItemCommand.MenuItemDeleted += (sender, args) => args.AsyncEventHandlers.Add(Reset());
            DeleteFieldItemCommand.FieldItemDeleted += (sender, args) => args.AsyncEventHandlers.Add(Reset());
        }
        public MenuItemDeleterCommand DeleteMenuItemCommand { get; }= new MenuItemDeleterCommand(new Processor());
        public FieldItemDeleterCommand DeleteFieldItemCommand { get; }= new FieldItemDeleterCommand(new Processor());
        public ICollection<MenuItemEntityModel> MenuItemsCollection
        {
            get => _menuItemsCollection;
            set
            {
                _menuItemsCollection = value;
                NotifyPropertyChanged();
            }
        }

        public ICollection<SubItemEntityModel> SubItemsCollection
        {
            get => _subItemsCollection;
            set
            {
                _subItemsCollection = value;
                NotifyPropertyChanged();
            }
        }

        public MenuItemEntityModel MenuItemEntityModel
        {
            get => _menuItemEntityModel;
            set
            {
                _menuItemEntityModel = value;
                NotifyPropertyChanged();
            }
        }


        public async Task Reset()
        {
            MenuItemsCollection = await Processor.LoadMenus();
            SubItemsCollection = await Processor.LoadSubItems();
        }

        public void Reset(MenuItemEntityModel menuItemEntityModel)
        {
            MenuItemEntityModel = menuItemEntityModel;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}