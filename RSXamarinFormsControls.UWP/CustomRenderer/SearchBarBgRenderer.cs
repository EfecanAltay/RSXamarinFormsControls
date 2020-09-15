using RSXamarinFormsControls.CustomControls;
using RSXamarinFormsControls.UWP.CustomRenderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(RSSearchBar), typeof(SearchBarBgRenderer))]
namespace RSXamarinFormsControls.UWP.CustomRenderer
{
    public class SearchBarBgRenderer : SearchBarRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                e.NewElement.BackgroundColor = Xamarin.Forms.Color.Transparent;                
            }
        }
    }
}

