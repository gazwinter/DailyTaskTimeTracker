using DailyTaskTimeTracker.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyTaskTimeTracker.ViewModels
{
    public class HistoryPageViewModel : ViewModelBase
    {
        public HistoryPageViewModel(INavigationService navigationService, IAccountService accountService) : base(navigationService, accountService)
        {
            Title = "History";
        }
    }
}
