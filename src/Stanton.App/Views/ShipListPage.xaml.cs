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
using Stanton.App.Views.Detail;
using Stanton.App.ViewModels;
using System.Threading.Tasks;
using Windows.UI.ViewManagement;
using Windows.UI;
using Stanton.App.Services;
using System.Numerics;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace Stanton.App.Views
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class ShipListPage : Page, ISubPage
    {
        public string NavTitle => "Ship / Viecle";
        public ShipListViewModel ViewModel { get; } = new ShipListViewModel();

        public ShipListPage()
        {
            this.InitializeComponent();
            Loaded += ShipListPage_Loaded;
        }


        private async void ShipListPage_Loaded(object sender, RoutedEventArgs e)
        {
            var isDark = ThemeSelectorService.Theme == ElementTheme.Dark;
            if(ThemeSelectorService.Theme == ElementTheme.Default)
            {
                isDark = Application.Current.RequestedTheme == ApplicationTheme.Dark;
            }
            PriceText.Foreground = new SolidColorBrush(isDark ? Colors.LightGreen : Colors.DarkGreen);
            await ViewModel.LoadDataAsync();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ShipDetailPage));
        }
    }
}
