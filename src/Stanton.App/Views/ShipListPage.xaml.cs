using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Controls.Primitives;
using Stanton.App.ViewModels;
using Stanton.App.Views.Detail;
using Stanton.App.Model;

namespace Stanton.App.Views
{
    public sealed partial class ShipListPage : Page, ISubPage
    {
        public string NavTitle => "Ship / Viecle";
        public ShipListViewModel ViewModel { get; } = new ShipListViewModel();
        private readonly ShipFilter _filter = new ShipFilter();

        public ShipListPage()
        {
            this.InitializeComponent();
            Loaded += ShipListPage_Loaded;
        }

        private async void ShipListPage_Loaded(object sender, RoutedEventArgs e)
        {
            await ViewModel.LoadDataAsync();
        }

        private void collection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Frame.Navigate(typeof(ShipDetailPage));
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            if (e.SourcePageType == typeof(ShipDetailPage))
            {
                //var animation = ConnectedAnimationService.GetForCurrentView().PrepareToAnimate("forwardAnimation", SourceImage);
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var animation = ConnectedAnimationService.GetForCurrentView().GetAnimation("backAnimation");
            if (animation != null)
            {
                //animation.TryStart(SourceImage);
            }
        }

        private async void FlightReadyButton_ClickAsync(object sender, RoutedEventArgs e)
        {
            var button = (ToggleButton)sender;
            _filter.IsFlightReady = (bool)button.IsChecked;
            await ViewModel.UpdateDataAsync(_filter);
        }

        private async void Manifacture_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combobox = sender as ComboBox;
            ShipManifacturer manifacturer = (combobox.SelectedItem) as ShipManifacturer;
            if (manifacturer.Name == "All")
            {
                _filter.Mainfacturer = null;
            }
            else
            {
                _filter.Mainfacturer = manifacturer.Name;
            }
            await ViewModel.UpdateDataAsync(_filter);
        }

        private async void Size_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combobox = sender as ComboBox;
            var size = (combobox.SelectedItem) as string;
            if (size == "All")
            {
                _filter.Size = null;
            }
            else
            {
                _filter.Size = size;
            }
            await ViewModel.UpdateDataAsync(_filter);
        }

        private async void Sorter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combobox = sender as ComboBox;
            var sort = (combobox.SelectedItem) as string;
            _filter.Sort = sort;
            await ViewModel.UpdateDataAsync(_filter);
        }

        private async void AutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            _filter.SearchText = args.QueryText;
            await ViewModel.UpdateDataAsync(_filter);
        }

        private async void AutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if(args.Reason ==AutoSuggestionBoxTextChangeReason.UserInput)
            {
                var text = sender.Text;
                if(text == string.Empty)
                {
                    _filter.SearchText = "";
                    await ViewModel.UpdateDataAsync(_filter);
                }
                else
                {
                    ViewModel.UpdateAutoSuggestionSource(text);
                }
            }
        }
    }
}
