using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Independiente.Commands
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action<object> _execute {  get; set; }

        private Predicate<object> _canExecute { get; set; }
        public RelayCommand(Action<object> executeMethod, Predicate<object> canExecuteMethod) 
        {
            _execute = executeMethod;
            _canExecute = canExecuteMethod;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
