using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace Stanton.App
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            var MyWebView = new WebView(WebViewExecutionMode.SeparateProcess)
            {
                Source = new Uri("https://sketchfab.com/models/a6af6d1ae2744a55820d00599aca71f2/embed?autostart=1&internal=1&ui_infos=0&ui_snapshots=1&ui_stop=0&ui_watermark=0")
            };
            this.Root.Children.Add(MyWebView);
        }
    }
}
