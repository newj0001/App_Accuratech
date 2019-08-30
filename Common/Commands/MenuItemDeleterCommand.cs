using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Common.Commands
{
    public class MenuItemDeleterCommand : ICommand
    {
        private readonly IProcessor _processor;

        public MenuItemDeleterCommand(IProcessor processor)
        {
            _processor = processor;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            await ExecuteAsync(parameter);
        }

        public async Task ExecuteAsync(object parameter)
        {
            await _processor.DeleteMenuItemAsync(((MenuItemEntityModel)parameter).Id);
            var executeAsyncCompletedEventArgs = new ExecuteAsyncCompletedEventArgs();
            MenuItemDeleted?.Invoke(this, executeAsyncCompletedEventArgs);
            await Task.WhenAll(executeAsyncCompletedEventArgs.AsyncEventHandlers);
        }

        public event EventHandler CanExecuteChanged;
        public event EventHandler<ExecuteAsyncCompletedEventArgs> MenuItemDeleted;
    }

    public class ExecuteAsyncCompletedEventArgs : EventArgs
    {
        public ICollection<Task> AsyncEventHandlers { get; } = new List<Task>();
    }


}