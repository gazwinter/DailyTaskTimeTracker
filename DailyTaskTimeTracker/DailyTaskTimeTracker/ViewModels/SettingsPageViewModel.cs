﻿using DailyTaskTimeTracker.Data.Interfaces;
using DailyTaskTimeTracker.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyTaskTimeTracker.ViewModels
{
    public class SettingsPageViewModel : ViewModelBase
    {
        public SettingsPageViewModel(INavigationService navigationService, IAccountService accountService, IDailyTaskTimeTrackerRepository dailyTaskTimeTrackerRepository) : base(navigationService, accountService, dailyTaskTimeTrackerRepository)
        {
            Title = "Settings";
        }
    }
}
