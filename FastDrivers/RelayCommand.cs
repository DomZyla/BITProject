using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FastDrivers
{
    public class RelayCommand : ICommand
    {
        private Action _whatToExecute;

        public event EventHandler CanExecuteChanged;

        private bool _canExecute;

        public bool CanExecute(object parameter)
        {
            return _canExecute;
        }

        public void Execute(object parameter)
        {
            _whatToExecute.Invoke();
        }

        public RelayCommand(Action what, bool CanExecute)
        {
            _whatToExecute = what;
            _canExecute = CanExecute;
        }

    }
}
