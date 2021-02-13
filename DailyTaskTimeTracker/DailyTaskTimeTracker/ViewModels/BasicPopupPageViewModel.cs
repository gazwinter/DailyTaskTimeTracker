using DailyTaskTimeTracker.Enums;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyTaskTimeTracker.ViewModels
{
    public class BasicPopupPageViewModel : BindableBase, INavigationAware
    {
        private INavigationService _navigationService { get; }

        public BasicPopupPageViewModel(INavigationService navigationService)
        {
            System.Diagnostics.Debug.WriteLine("Hello from the PopupViewViewModel");
            _navigationService = navigationService;
            NavigateBackCommand = new DelegateCommand(OnNavigateBackCommandExecuted);
        }

        private string _popupTitle;

        public string PopupTitle
        {
            get => _popupTitle;
            set { SetProperty(ref _popupTitle, value); }
        }

        private string _message;
        public string Message
        {
            get => _message; 
            set { SetProperty(ref _message, value); }
        }

        private PopupType _type;

        public PopupType PopUpType
        {
            get => _type;
            set { SetProperty(ref _type, value); }
        }

        public DelegateCommand NavigateBackCommand { get; }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
            System.Diagnostics.Debug.WriteLine($"{GetType().Name} Navigating To");
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            System.Diagnostics.Debug.WriteLine($"{GetType().Name} Navigated From");
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            System.Diagnostics.Debug.WriteLine($"{GetType().Name} Navigated To");

            var title = parameters.GetValue<string>("Title");
            var message = parameters.GetValue<string>("Message");

            //get a collection of typed parameters
            var type = parameters.GetValue<PopupType>("Type");

            if (parameters.ContainsKey("Message"))
            {
                Message = message;
            }
            else
            {
                Message = "Something went wrong!";
            }

            PopupTitle = title;
            PopUpType = type;
        }

        private async void OnNavigateBackCommandExecuted()
        {
            await _navigationService.GoBackAsync(new NavigationParameters{
                { "message", "Hello from the Popup View" }
            });
        }
    }
}
