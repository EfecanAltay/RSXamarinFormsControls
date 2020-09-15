using RSXamarinFormsControls.CustomControls;
using RSXamarinFormsControls.UWP.CustomRenderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(RSListView), typeof(CustomListViewRenderer))]
namespace RSXamarinFormsControls.UWP.CustomRenderer
{
    public class CustomListViewRenderer : ListViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
                Windows.UI.Xaml.Controls.ScrollViewer.SetVerticalScrollBarVisibility((Control as Windows.UI.Xaml.Controls.ListView), Windows.UI.Xaml.Controls.ScrollBarVisibility.Hidden);
        }
    }
}
