using System;
using System.Windows.Input;

namespace xf.exercise.atm.ViewModels
{
    public class ActionCommand<T> : ICommand
    {
        readonly Action<T> action;

        public ActionCommand(Action<T> action) => this.action = action;

        public bool CanExecute(object parameter) => true;

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter) => action((T)parameter);
    }
}
