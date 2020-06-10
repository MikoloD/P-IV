using FluentValidation;
using lab15.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace lab15
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            Model = new RegisterViewModel();
            RegisterCommand = new RegisterCommand();
        }
        public RegisterViewModel Model { get; set; }
        public ICommand RegisterCommand { get; set; }
    }

    public class RegisterViewModelValidator : AbstractValidator<RegisterViewModel>
    {
        public RegisterViewModelValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password)
                .NotNull()
                .NotEmpty()
                .MinimumLength(6)
                .Must(x => x != x.ToLower())
                .WithMessage("Hasło musi zawierc przynajmniej jedną wielką literę")
                .Must(x => x != x.ToUpper())
                .WithMessage("Hasło musi zawierc przynajmniej jedną małą literę")
                .Matches(@".*\d.*")
                .WithMessage("Hasło musi zawierc conajmniej jedna cyfre");

            RuleFor(x => x.IsHuman)
                .Must(x => x)
                .WithMessage("Music potwierdzic że jestes czlowiekiem");
        }
    }

    public class RegisterViewModel : INotifyPropertyChanged
    {
        private string _email;

        public string Email
        {
            get { return _email; }
            set { 
                if(_email !=value)
                {
                    _email = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Email"));
                }
            
            }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Password"));
                }

            }
        }
        private bool _isHuman;

        public bool IsHuman
        {
            get { return _isHuman; }
            set
            {
                if (_isHuman != value)
                {
                    _isHuman = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsHuman"));
                }

            }
        }
        private string _errors;

        public string Errors
        {
            get { return _errors; }
            set
            {
                if (_errors != value)
                {
                    _errors = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Errors"));
                }

            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
