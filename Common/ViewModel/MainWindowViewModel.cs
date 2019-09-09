using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Common.Commands;
using Common.Services;
using Xamarin.Forms;

namespace Common.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly MenuItemDataStore _menuItemDataStore = new MenuItemDataStore();
        private readonly FieldItemDataStore _fieldItemDataStore = new FieldItemDataStore();


        private ICollection<MenuItemEntityModel> _menuItemsCollection;
        private ICollection<SubItemEntityModel> _subItemsCollection;
        private MenuItemEntityModel _menuItemEntityModel;

        public MainWindowViewModel()
        {
            DeleteMenuItemCommand.MenuItemDeleted += (sender, args) => args.AsyncEventHandlers.Add(Reset());
            DeleteFieldItemCommand.FieldItemDeleted += (sender, args) => args.AsyncEventHandlers.Add(Reset());
        }
        public MenuItemDeleterCommand DeleteMenuItemCommand { get; }= new MenuItemDeleterCommand(new MenuItemDataStore());
        public FieldItemDeleterCommand DeleteFieldItemCommand { get; }= new FieldItemDeleterCommand(new FieldItemDataStore());
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
            MenuItemsCollection = await _menuItemDataStore.GetItemsAsync();
            SubItemsCollection = await _fieldItemDataStore.GetItemsAsync();
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