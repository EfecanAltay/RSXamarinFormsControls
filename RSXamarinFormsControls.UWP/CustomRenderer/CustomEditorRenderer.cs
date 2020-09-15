using RSXamarinFormsControls.CustomControls;
using RSXamarinFormsControls.UWP.CustomRenderer;
using Windows.UI.Xaml.Media;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(RSEditor), typeof(CustomEditorRenderer))]
namespace RSXamarinFormsControls.UWP.CustomRenderer
{
    public class CustomEditorRenderer : EditorRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Transparent);
            }
        }
    }
}
