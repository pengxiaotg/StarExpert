using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
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
        }

        private void ShipListPage_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel.LoadData();
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
