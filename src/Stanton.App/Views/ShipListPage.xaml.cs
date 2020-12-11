using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Navigation;
using Stanton.App.Services;
using Stanton.App.ViewModels;
using Stanton.App.Views.Detail;

namespace Stanton.App.Views
{
    public sealed partial class ShipListPage : Page, ISubPage
    {
        public string NavTitle => "Ship / Viecle";
        public ShipListViewModel ViewModel { get; } = new ShipListViewModel();

        public ShipListPage()
        {
            this.InitializeComponent();
            Loaded += ShipListPage_Loaded;
            UISettings uiSettings = new UISettings();
            uiSettings.ColorValuesChanged += UISettings_ColorValuesChangedAsync;
        }

        // Thanks to https://stackoverflow.com/questions/65220165/how-to-change-color-to-adjust-theme-setting-in-uwp/65244990#65244990
        private async void UISettings_ColorValuesChangedAsync(UISettings sender, object args)
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                AdjustThemeSetting();
            });
        }

        private void AdjustThemeSetting()
        {
            bool isDark;
            if (ThemeSelectorService.Theme == ElementTheme.Default)
            {
                isDark = Application.Current.RequestedTheme == ApplicationTheme.Dark;
            }
            else
            {
                isDark = ThemeSelectorService.Theme == ElementTheme.Dark;
            }
            //PriceText.Foreground = new SolidColorBrush(isDark ? Colors.LightGreen : Colors.DarkGreen);
        }

        private void ShipListPage_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel.LoadData();
            AdjustThemeSetting();
        }

        private void collection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Frame.Navigate(typeof(ShipDetailPage));
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            if(e.SourcePageType == typeof(ShipDetailPage))
            {
                //var animation = ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("forwardAnimation", SourceImage);
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var animation = ConnectedAnimationService.GetForCurrentView().GetAnimation("backAnimation");
            if(animation != null)
            {
                //animation.TryStart(SourceImage);
            }
        }
    }
}
