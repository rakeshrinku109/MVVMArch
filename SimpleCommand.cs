using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMArch
{
    public class SimpleCommand : ICommand
    {

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        private Action<object> _executeMethod;
        private Predicate<object> _canExecute;
        public SimpleCommand(Action<object> ExecuteDelegate)
        {
            
        }

        public SimpleCommand(Action<object> ExecuteDelegate,Predicate<object> canExecute)
        {

            _executeMethod = ExecuteDelegate;
            _canExecute = canExecute;
        }

        /// <summary>
        /// Can execute method 
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        /// <summary>
        /// Execute method
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            _executeMethod.Invoke(parameter);
        }
    }
}
