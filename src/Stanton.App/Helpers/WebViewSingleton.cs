using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Stanton.App.Helpers
{
    public static class WebViewSingleton
    {
        private static WebView instance;

        public static WebView GetInstance()
        {
            if (instance == null)
            {
                instance = new WebView(WebViewExecutionMode.SeparateProcess)
                {
                    Source = new Uri("https://www.google.com/")
                };
            }
            return instance;
        }
    }
}
