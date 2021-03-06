﻿using DailyTaskTimeTracker.Data.Interfaces;
using DailyTaskTimeTracker.Enums;
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
        private ICommand _createAccountCmd;
        
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

        public ICommand CreateAccountCmd
        {
            get => _createAccountCmd;
            set { SetProperty(ref _createAccountCmd, value); }
        }
        #endregion



        public LoginPageViewModel(INavigationService navigationService, IAccountService accountService, IDailyTaskTimeTrackerRepository dailyTaskTimeTrackerRepository)
            : base(navigationService, accountService, dailyTaskTimeTrackerRepository)
        {            

            Title = "Login";            
            LoginCommand = new Command(async () => await AttemptLogin());
            CreateAccountCmd = new Command(async () => await GoToCreateAccount());
            
        }

        private async Task GoToCreateAccount()
        {
            await NavigationService.NavigateAsync("CreateAccountPage");
        }

        private async Task AttemptLogin()
        {
            if(await AccountService.LoginUser(Username, Password))
            {                
                await NavigationService.NavigateAsync("/DashboardPage");                
            }
            else
            {
                await DisplayPopup("Error", "Invalid username or password", PopupType.Error);
            }
        }
    }
}
