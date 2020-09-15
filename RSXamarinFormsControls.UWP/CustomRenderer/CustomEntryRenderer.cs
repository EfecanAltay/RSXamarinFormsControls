using RSXamarinFormsControls.CustomControls;
using RSXamarinFormsControls.UWP.CustomRenderer;
using Windows.UI.Xaml.Media;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(RSEntry), typeof(CustomEntryRenderer))]
namespace RSXamarinFormsControls.UWP.CustomRenderer
{
    public class CustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.IsReadOnly = true;
                Control.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Transparent);
                Control.BorderThickness = new Windows.UI.Xaml.Thickness(0);
            }
        }
    }
}
