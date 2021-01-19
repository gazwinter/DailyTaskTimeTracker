using DailyTaskTimeTracker.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyTaskTimeTracker.ViewModels
{
    public class TimerPageViewModel : ViewModelBase
    {
        public TimerPageViewModel(INavigationService navigationService, IAccountService accountService) : base(navigationService, accountService)
        {
            Title = "Timer";
        }
    }
}
