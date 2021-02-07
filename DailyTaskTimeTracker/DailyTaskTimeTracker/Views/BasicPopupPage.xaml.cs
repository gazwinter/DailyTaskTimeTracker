using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace DailyTaskTimeTracker.Views
{
    public partial class BasicPopupPage : PopupPage
    {
        
            public BasicPopupPage()
            {
                InitializeComponent();
                AnnounceBindingContext();
            }

            protected override void OnBindingContextChanged()
            {
                base.OnBindingContextChanged();
                AnnounceBindingContext();
            }

            private void AnnounceBindingContext()
            {
                System.Diagnostics.Debug.WriteLine(GetType().Name);
                System.Diagnostics.Debug.WriteLine($"BindingContext: {BindingContext?.GetType()?.Name}");
            }

        
    }
}
