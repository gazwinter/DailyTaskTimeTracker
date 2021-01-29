using DailyTaskTimeTracker.Data.Interfaces;
using DailyTaskTimeTracker.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DailyTaskTimeTracker.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        #region Privates
        private string _username;
        private string _password;
        private ICommand _loginCommand;
        
        #endregion

        #region Public Properties
        public string Username
        {
            get =>_username; 
            set { SetProperty(ref _username, value); }
        }

        public string Password
        {
            get => _password;
            set { SetProperty(ref _password, value); }
        }

        public ICommand LoginCommand
        {
            get => _loginCommand;
            set { SetProperty(ref _loginCommand, value); }
        }
        #endregion

       

        public LoginPageViewModel(INavigationService navigationService, IAccountService accountService, IDailyTaskTimeTrackerRepository dailyTaskTimeTrackerRepository)
            : base(navigationService, accountService, dailyTaskTimeTrackerRepository)
        {            

            Title = "Login";            
            LoginCommand = new Command(async () => await AttemptLogin());
            
        }

        private async Task AttemptLogin()
        {
            if(await AccountService.LoginUser(Username, Password))
            {
                await NavigationService.NavigateAsync("/DashboardPage");
            }
        }
    }
}
