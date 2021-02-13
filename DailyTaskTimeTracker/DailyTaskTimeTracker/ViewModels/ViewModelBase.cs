using DailyTaskTimeTracker.Data.Interfaces;
using DailyTaskTimeTracker.Enums;
using DailyTaskTimeTracker.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DailyTaskTimeTracker.ViewModels
{
    public class ViewModelBase : BindableBase, IInitialize, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; private set; }
        protected IAccountService AccountService { get; private set; }
        protected IDailyTaskTimeTrackerRepository DailyTaskTimeTrackerRepo { get; private set; }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ViewModelBase(INavigationService navigationService, IAccountService accountService, IDailyTaskTimeTrackerRepository dailyTaskTimeTrackerRepository)
        {
            NavigationService = navigationService;
            AccountService = accountService;
            DailyTaskTimeTrackerRepo = dailyTaskTimeTrackerRepository;

        }

        public virtual void Initialize(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public virtual void Destroy()
        {

        }

        public async Task DisplayPopup(string title, string message, PopupType type)
        {
            var popupNavigationParameters = new NavigationParameters
            {

                { "Title", title },
                { "Message", message },
                { "Type", type }
            };

            await NavigationService.NavigateAsync("BasicPopupPage", popupNavigationParameters);
        }
    }
}
