using DailyTaskTimeTracker.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyTaskTimeTracker.ViewModels
{
    public class ProfilePageViewModel : ViewModelBase
    {
        public ProfilePageViewModel(INavigationService navigationService, IAccountService accountService) : base(navigationService, accountService)
        {
            Title = "Profile";
        }
    }
}
