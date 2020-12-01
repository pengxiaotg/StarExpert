using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Composition;
using Windows.UI.Xaml.Hosting;
using System.Numerics;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace Stanton.App.Views.Detail
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class ShipDetail : Page
    {
        public ShipDetail()
        {
            this.InitializeComponent();
        }

        private void Page_LayoutUpdated(object sender, object e)
        {
            FlipView.Height = Image.ActualHeight;
            var height = FlipView.ActualHeight - HeaderText.ActualHeight + 1;
            
            CompositionPropertySet scrollerPropertySet = ElementCompositionPreview.GetScrollViewerManipulationPropertySet(MainScrollViewer);
            Compositor compositor = scrollerPropertySet.Compositor;

            // Get the visual that represents our HeaderTextBlock 
            // And define the progress animation string
            var headerVisual = ElementCompositionPreview.GetElementVisual(ScrollHeader);
            String progress = $"Clamp(Abs(scroller.Translation.Y) / {height}, 0.0, 1.0)";

            // Create the expression and add in our progress string.
            var textExpression = compositor.CreateExpressionAnimation("Lerp(1.5, 1, " + progress + ")");
            textExpression.SetReferenceParameter("scroller", scrollerPropertySet);

            // Shift the header by 50 pixels when scrolling down
            var offsetExpression = compositor.CreateExpressionAnimation($"-scroller.Translation.Y - {progress} * {height}");
            offsetExpression.SetReferenceParameter("scroller", scrollerPropertySet);
            headerVisual.StartAnimation("Offset.Y", offsetExpression);

            
            Visual textVisual = ElementCompositionPreview.GetElementVisual(HeaderText);
            Vector3 finalOffset = new Vector3(0, 0, 0);
            var headerOffsetAnimation = compositor.CreateExpressionAnimation($"Lerp(Vector3(0,0,0), finalOffset, {progress})");
            headerOffsetAnimation.SetReferenceParameter("scroller", scrollerPropertySet);
            headerOffsetAnimation.SetVector3Parameter("finalOffset", finalOffset);
            textVisual.StartAnimation(nameof(Visual.Offset), headerOffsetAnimation);
            
            var opacityExpression = compositor.CreateExpressionAnimation($"{progress}");
            opacityExpression.SetReferenceParameter("scroller", scrollerPropertySet);
            textVisual.StartAnimation("opacity", opacityExpression);
            

        }



        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void GridView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var col = Math.Min(Math.Ceiling(ActualWidth / 400), GridView.Items.Count);
            ((ItemsWrapGrid)GridView.ItemsPanelRoot).ItemWidth = e.NewSize.Width / col;
        }

        private void MyButton_Click(object sender, RoutedEventArgs e)
        {
            //Frame.Navigate(typeof(SettingsPage));
        }
    }
}
