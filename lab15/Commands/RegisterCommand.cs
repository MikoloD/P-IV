using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace lab15.Commands
{
    public class RegisterCommand : ICommand
    {
        private RegisterViewModelValidator validator = new RegisterViewModelValidator();

        public event EventHandler CanExecuteChanged
        {
           add { CommandManager.RequerySuggested += value; }
           remove { CommandManager.RequerySuggested -= value; }
        }
        public bool CanExecute(object parameter)
        {
            var model = parameter as RegisterViewModel;
            if(model is null) return false;
            var resoults = validator.Validate(model);
            model.Errors = string.Join(" ", resoults.Errors);
            return resoults.IsValid;
        }

        public void Execute(object parameter)
        {
            var model = parameter as RegisterViewModel;
            MessageBox.Show($"Zarejstrowano urzytkownika {model.Email}", "Powodzenie", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}