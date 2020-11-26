using Stanton.App.Views;
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
using NavigationView = Microsoft.UI.Xaml.Controls.NavigationView;
using NavigationViewItem = Microsoft.UI.Xaml.Controls.NavigationViewItem;
using NavigationViewBackRequestedEventArgs = Microsoft.UI.Xaml.Controls.NavigationViewBackRequestedEventArgs;
using NavigationViewItemInvokedEventArgs = Microsoft.UI.Xaml.Controls.NavigationViewItemInvokedEventArgs;
using Stanton.App.Views.Detail;

#nullable enable

namespace Stanton.App
{
    public sealed partial class Shell : UserControl
    {
        private readonly IReadOnlyCollection<NavEntry> NavigationItems;

        public Shell()
        {
            this.InitializeComponent();

            NavigationItems = new[]
            {
                new NavEntry(HomeItem, typeof(HomePage)),
                new NavEntry(ShipItem, typeof(ShipDetail)),
                new NavEntry((NavigationViewItem)NavigationView.SettingsItem, typeof(SettingsPage))
            };

            // Set the custom title bar to act as a draggable region
            Window.Current.SetTitleBar(TitleBarBorder);
        }


        // Select the introduction item when the shell is loaded
        private void Shell_OnLoaded(object sender, RoutedEventArgs e)
        {
            NavigationView.SelectedItem = HomeItem;
            NavigationFrame.Navigate(typeof(HomePage));
        }


        private void NavigationView_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            if (NavigationFrame.BackStack.LastOrDefault() is PageStackEntry entry)
            {
                NavigationView.SelectedItem = NavigationItems.First(item => item.PageType == entry.SourcePageType).Item;

                NavigationFrame.GoBack();
            }
        }

        private void NavigationFrame_Navigated(object sender, NavigationEventArgs e)
        {
            NavigationView.IsBackEnabled = ((Frame)sender).BackStackDepth > 0;
            if (e.SourcePageType == typeof(SettingsPage))
            {
                NavigationView.SelectedItem = NavigationView.SettingsItem;
            }
        }


        private void NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if(args.IsSettingsInvoked)
            {
                NavigationFrame.Navigate(typeof(SettingsPage));
            }
            if (NavigationItems.FirstOrDefault(item => item.Item == args.InvokedItemContainer)?.PageType is Type pageType)
            {
                NavigationFrame.Navigate(pageType);
            }
        }

        /// <summary>
        /// A simple model for tracking pages associated with buttons.
        /// </summary>
        public sealed class NavEntry
        {
            public NavEntry(NavigationViewItem viewItem, Type pageType, string? name = null, string? tags = null)
            {
                Item = viewItem;
                PageType = pageType;
                Name = name;
                Tags = tags;
            }

            /// <summary>
            /// The navigation item for the current entry.
            /// </summary>
            public NavigationViewItem Item { get; }

            /// <summary>
            /// The associated page type for the current entry.
            /// </summary>
            public Type PageType { get; }

            /// <summary>
            /// Gets the name of the current entry.
            /// </summary>
            public string? Name { get; }

            /// <summary>
            /// Gets the tag for the current entry, if any.
            /// </summary>
            public string? Tags { get; }
        }
    }
}
