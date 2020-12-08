using Stanton.App.ViewModels;
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
using Stanton.App.Helpers;
using Stanton.App.Services;
// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace Stanton.App.Views
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class SettingsPage : Page, ISubPage
    {
        public SettingsViewModel ViewModel { get; } = new SettingsViewModel();

        public string NavTitle => "Settings_Title".GetLocalized();

        public SettingsPage()
        {
            this.InitializeComponent();
            LoadThemeSetting();
        }

        private void LoadThemeSetting()
        {
            List<string> _themeval = new List<string>
            {
                "Theme_Default".GetLocalized(),
                "Theme_Light".GetLocalized(),
                "Theme_Dark".GetLocalized()
            };
            ThemeChooser.ItemsSource = _themeval;
            ThemeChooser.SelectedIndex = (int)Enum.Parse(typeof(ElementTheme), ThemeSelectorService.Theme.ToString());
            ThemeChooser.Loaded += (s, e) =>
            {
                ThemeChooser.SelectionChanged += async (s1, e1) =>
                {
                    var themeComboBox = s1 as ComboBox;
                    switch (themeComboBox.SelectedIndex)
                    {
                        case 0:
                            await ThemeSelectorService.SetThemeAsync(ElementTheme.Default);
                            break;
                        case 1:
                            await ThemeSelectorService.SetThemeAsync(ElementTheme.Light);
                            break;
                        case 2:
                            await ThemeSelectorService.SetThemeAsync(ElementTheme.Dark);
                            break;
                    }
                };
            };
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await ViewModel.InitializeAsync();
        }
    }
}
