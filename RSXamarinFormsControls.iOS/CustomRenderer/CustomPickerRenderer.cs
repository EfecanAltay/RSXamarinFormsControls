using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using RSXamarinFormsControls.CustomControls;
using RSXamarinFormsControls.iOS.CustomRenderer;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomPickerRenderer))]
namespace RSXamarinFormsControls.iOS.CustomRenderer
{
    public class CustomPickerRenderer : PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            var element = (CustomPicker)this.Element;

            if (this.Control != null && this.Element != null && !string.IsNullOrEmpty(element.Icon))
            {
                var downArrow = UIImage.FromBundle(element.Icon);
                Control.RightViewMode = UITextFieldViewMode.Always;
                Control.RightView = new UIImageView(downArrow);
            }
        }
    }
}
