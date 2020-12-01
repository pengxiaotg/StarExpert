using System;
using System.Numerics;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Hosting;


// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace Stanton.App.Views
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class HomePage : Page
    {
        private readonly WebView MyWebView;
        public HomePage()
        {
            this.InitializeComponent();
            
            MyWebView = new WebView(WebViewExecutionMode.SeparateProcess)
            {
                Source = new Uri("https://sketchfab.com/models/a6af6d1ae2744a55820d00599aca71f2/embed?autostart=1&internal=1&ui_infos=0&ui_snapshots=1&ui_stop=0&ui_watermark=0")
            };
            WeaponryTab.Children.Add(MyWebView);

        }

        private void GridView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            
            var col = Math.Min(Math.Ceiling(ActualWidth / 400), GridView.Items.Count);
            ((ItemsWrapGrid)GridView.ItemsPanelRoot).ItemWidth = e.NewSize.Width / col;
            MyWebView.Width = e.NewSize.Width - 24;
            MyWebView.Height = e.NewSize.Width /2;
            
        }

        private void Page_LayoutUpdated(object sender, object e)
        {

        }
    }
}
