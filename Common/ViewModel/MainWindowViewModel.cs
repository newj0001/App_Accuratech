﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Common.Commands;
using Xamarin.Forms;

namespace Common.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private ICollection<MenuItemEntity> _menuItemsCollection;
        private ICollection<SubItemEntity> _subItemsCollection;
        private MenuItemEntity _menuItemEntity;

        public MainWindowViewModel()
        {
            DeleteMenuItemCommand.MenuItemDeleted += (sender, args) => args.AsyncEventHandlers.Add(Reset());
            DeleteFieldItemCommand.FieldItemDeleted += (sender, args) => args.AsyncEventHandlers.Add(Reset());
        }
        public MenuItemDeleterCommand DeleteMenuItemCommand { get; }= new MenuItemDeleterCommand(new Processor());
        public FieldItemDeleterCommand DeleteFieldItemCommand { get; }= new FieldItemDeleterCommand(new Processor());
        public ICollection<MenuItemEntity> MenuItemsCollection
        {
            get => _menuItemsCollection;
            set
            {
                _menuItemsCollection = value;
                NotifyPropertyChanged();
            }
        }

        public ICollection<SubItemEntity> SubItemsCollection
        {
            get => _subItemsCollection;
            set
            {
                _subItemsCollection = value;
                NotifyPropertyChanged();
            }
        }

        public MenuItemEntity MenuItemEntity
        {
            get => _menuItemEntity;
            set
            {
                _menuItemEntity = value;
                NotifyPropertyChanged();
            }
        }

        public async Task Reset()
        {
            MenuItemsCollection = await Processor.LoadMenus();
            SubItemsCollection = await Processor.LoadSubItems();
        }

        public void Reset(MenuItemEntity menuItemEntity)
        {
            MenuItemEntity = menuItemEntity;
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}