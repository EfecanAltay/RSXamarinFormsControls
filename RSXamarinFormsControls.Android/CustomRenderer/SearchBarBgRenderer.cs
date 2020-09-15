using System.ComponentModel;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;
using RSXamarinFormsControls.CustomControls;
using RSXamarinFormsControls.CustomDependencies;
using RSXamarinFormsControls.Droid.CustomRenderer;
using RSXamarinFormsControls.Resx;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomSearchBar), typeof(SearchBarBgRenderer))]
namespace RSXamarinFormsControls.Droid.CustomRenderer
{
    public class SearchBarBgRenderer : SearchBarRenderer
    {
        public SearchBarBgRenderer(Context context) : base(context)
        {
        }

        // https://android.googlesource.com/platform/frameworks/base/+/refs/heads/master/core/res/res/layout/search_view.xml

        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            { 
                var searchView = (Control as SearchView);            
                searchView.SetInputType(InputTypes.ClassText | InputTypes.TextVariationNormal);
                
                int textViewId = searchView.Context.Resources.GetIdentifier("android:id/search_src_text", null, null);
                int textEditPlateId = searchView.Context.Resources.GetIdentifier("android:id/search_plate", null, null);

                var textView = (searchView.FindViewById(textViewId) as EditText);
                var searchEditPlate = (searchView.FindViewById(textEditPlateId) as LinearLayout);

                GradientDrawable gd = new GradientDrawable();
                gd.SetColor(Android.Graphics.Color.Transparent.ToArgb());
                textView.SetBackground(gd);
                searchEditPlate.SetBackground(gd);

                LinearLayout.LayoutParams lp = new LinearLayout.LayoutParams(-1, -1);
                lp.SetMargins(0,0,0,0);
                
                textView.LayoutParameters = lp; 
                Control.Background = new ColorDrawable(Android.Graphics.Color.White);
            }
        }
       
    }
}
