using System;
using System.Numerics;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Stanton.App.Helpers;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace Stanton.App.Views
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class HomePage : Page
    {
        private static readonly WebView MyWebView = WebViewSingleton.GetInstance();

        public HomePage()
        {
            this.InitializeComponent();
        }

        private void GridView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var col = Math.Min(Math.Ceiling(ActualWidth / 400), GridView.Items.Count);
            ((ItemsWrapGrid)GridView.ItemsPanelRoot).ItemWidth = e.NewSize.Width / col;
            MyWebView.Width = e.NewSize.Width - 12;
            MyWebView.Height = MyWebView.Width * 9 / 16;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var uri = new Uri("https://sketchfab.com/models/a6af6d1ae2744a55820d00599aca71f2/embed?autostart=1&internal=1&ui_infos=0&ui_snapshots=1&ui_stop=0&ui_watermark=0");
            if (MyWebView.Source != uri )
            {
                MyProgressRing.IsActive = true;
                MyWebView.Opacity = 0.1;
                MyWebView.Navigate(uri);
            }
            else
            {
                MyProgressRing.IsActive = false;
                MyWebView.Opacity = 1;
            }
            if (!WeaponryTab.Children.Contains(MyWebView))
            {
                WeaponryTab.Children.Add(MyWebView);
            }
            MyWebView.DOMContentLoaded += MyWebView_DOMContentLoaded;
        }

        private void MyWebView_DOMContentLoaded(WebView sender, WebViewDOMContentLoadedEventArgs args)
        {
            MyProgressRing.IsActive = false;
            MyWebView.Opacity = 1;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            if (WeaponryTab.Children.Contains(MyWebView))
            {
                WeaponryTab.Children.Remove(MyWebView);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyProgressRing.IsActive = false;
            MyWebView.Opacity = 1;
        }

        private void Page_LayoutUpdated(object sender, object e)
        {
        }
    }
}
