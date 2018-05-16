using System;
using System.Windows.Input;

namespace VsProjEdit.ViewModels
{
    public class RelayCommand : ICommand {
        Action<object> _executeMethod;
        Predicate<object> _canExecuteMethod;

        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {
        }

        public RelayCommand(Action<object> execteMethod, Predicate<object> canExecuteMethod)
        {
            _executeMethod = execteMethod ?? throw new ArgumentNullException("execteMethod");
            _canExecuteMethod = canExecuteMethod;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecuteMethod == null ? true : _canExecuteMethod(parameter);
        }

        public void Execute(object parameter)
        {
            _executeMethod(parameter);
        }

        public event EventHandler CanExecuteChanged {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }
    }
}

