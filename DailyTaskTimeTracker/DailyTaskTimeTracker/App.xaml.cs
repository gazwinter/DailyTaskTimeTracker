using DailyTaskTimeTracker.Data;
using DailyTaskTimeTracker.Data.Interfaces;
using DailyTaskTimeTracker.Interfaces;
using DailyTaskTimeTracker.Services;
using DailyTaskTimeTracker.ViewModels;
using DailyTaskTimeTracker.Views;
using Prism;
using Prism.Ioc;
using Prism.Plugin.Popups;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

[assembly: ExportFont("FontAwesome5BrandsRegular.otf", Alias = "FA#BrandsRegular")]
[assembly: ExportFont("FontAwesome5Regular.otf", Alias = "FA#Regular")]
[assembly: ExportFont("FontAwesome5Solid.otf", Alias = "FA#Solid")]
namespace DailyTaskTimeTracker
{    
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/LoginPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

            containerRegistry.RegisterPopupNavigationService();

            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();
            containerRegistry.RegisterSingleton<IAccountService, AccountService>();
            containerRegistry.RegisterSingleton<IDailyTaskTimeTrackerContext, DailyTaskTimeTrackerContext>();
            containerRegistry.RegisterSingleton<IDailyTaskTimeTrackerRepository, DailyTaskTimeTrackerRepository>();
            

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<DashboardPage, DashboardPageViewModel>();
            containerRegistry.RegisterForNavigation<TimerPage, TimerPageViewModel>();
            containerRegistry.RegisterForNavigation<HistoryPage, HistoryPageViewModel>();
            containerRegistry.RegisterForNavigation<SettingsPage, SettingsPageViewModel>();
            containerRegistry.RegisterForNavigation<ProfilePage, ProfilePageViewModel>();
            containerRegistry.RegisterForNavigation<CreateAccountPage, CreateAccountPageViewModel>();
            containerRegistry.RegisterForNavigation<BasicPopupPage, BasicPopupPageViewModel>();

        }
    }
}
