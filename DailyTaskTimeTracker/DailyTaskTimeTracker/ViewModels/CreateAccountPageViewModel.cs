using DailyTaskTimeTracker.Data.Entities;
using DailyTaskTimeTracker.Data.Interfaces;
using DailyTaskTimeTracker.Enums;
using DailyTaskTimeTracker.Helpers;
using DailyTaskTimeTracker.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DailyTaskTimeTracker.ViewModels
{
    public class CreateAccountPageViewModel : ViewModelBase
    {
        #region privates
        private string _firstname;
        private string _surname;
        private string _email;
        private string _password;
        private string _confirmPassword;
        private ICommand _createAccountCmd;
        #endregion

        #region Properties
        public string Firstname
        {
            get => _firstname;
            set => SetProperty(ref _firstname, value);
        }

        public string Surname
        {
            get => _surname;
            set => SetProperty(ref _surname, value);
        }

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public string ConfirmPassword
        {
            get => _confirmPassword;
            set => SetProperty(ref _confirmPassword, value);
        }

        public ICommand CreateAccountCmd
        {
            get => _createAccountCmd;
            set => SetProperty(ref _createAccountCmd, value);
        }
        #endregion

        #region Constructor and Initialize
        public CreateAccountPageViewModel(INavigationService navigationService, IAccountService accountService, IDailyTaskTimeTrackerRepository dailyTaskTimeTrackerRepository) 
            : base(navigationService, accountService, dailyTaskTimeTrackerRepository)
        {
            Title = "Create Account";


        }

        public override void Initialize(INavigationParameters parameters)
        {
            base.Initialize(parameters);
            CreateAccountCmd = new Command(async () => await CreateUserAccount());
        }

        private async Task CreateUserAccount()
        {
            if(await AccountService.SignUp(Firstname, Surname, Email, Password))
            {
                await NavigationService.NavigateAsync("/DashboardPage");
            }            
            else
            {
                await DisplayPopup("Error", "Please make sure that you filled in all of the fields", PopupType.Error);
            }

        }
        #endregion
    }
}
