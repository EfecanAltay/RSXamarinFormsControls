using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RSXamarinFormsControls.Controls;
using RSXamarinFormsControls.CustomControls;
using RSXamarinFormsControls.UWP;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(RSPicker), typeof(PlaceholderPickerRenderer))]
namespace RSXamarinFormsControls.UWP
{
    public class PlaceholderPickerRenderer : PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.PlaceholderText = Element.Title;
                Control.Header = null;
            }
        }
    }
}
