using System.ComponentModel;
using RSXamarinFormsControls.Controls;
using RSXamarinFormsControls.UWP.CustomRenderer;
using Windows.UI.Xaml.Controls;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(RSScrollViewBarHide), typeof(ScrollViewBarHideRenderer))]
namespace RSXamarinFormsControls.UWP.CustomRenderer
{
    public class ScrollViewBarHideRenderer : ScrollViewRenderer
    {
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Control.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
            Control.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;
        }
    }
}
