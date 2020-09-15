using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using RSXamarinFormsControls.CustomControls;
using RSXamarinFormsControls.Droid.CustomRenderer;
using Xamarin.Forms.Platform.Android;

[assembly: Xamarin.Forms.ExportRenderer(typeof(CustomSwitch), typeof(CustomSwitchRenderer))]
namespace RSXamarinFormsControls.Droid.CustomRenderer
{
    public class CustomSwitchRenderer : SwitchRenderer
    {
        private CustomSwitch view;
        private Color SwitchOnColor = new Color(80,181,113);
        private Color SwitchOffColor = new Color(18, 52, 88);
        private Color SwitchThumbColor = new Color(217, 217, 217);

        public CustomSwitchRenderer(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Switch> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null || e.NewElement == null)
                return;
            view = (CustomSwitch)Element;
            if (Control != null)
            {
                if (Control.Checked)
                {
                    Control.TrackDrawable.SetColorFilter(SwitchThumbColor, PorterDuff.Mode.SrcAtop);
                    Control.ThumbDrawable.SetColorFilter(SwitchOnColor, PorterDuff.Mode.SrcAtop);
                }
                else
                {
                    Control.TrackDrawable.SetColorFilter(SwitchThumbColor, PorterDuff.Mode.SrcAtop);
                    Control.ThumbDrawable.SetColorFilter(SwitchOffColor, PorterDuff.Mode.SrcAtop);
                }
                Control.CheckedChange += OnCheckedChange;
            }
        }

        private void OnCheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            if (Control.Checked)
            {
                Control.TrackDrawable.SetColorFilter(SwitchThumbColor, PorterDuff.Mode.SrcAtop);
                Control.ThumbDrawable.SetColorFilter(SwitchOnColor, PorterDuff.Mode.SrcAtop);
            }
            else
            {
                Control.TrackDrawable.SetColorFilter(SwitchThumbColor, PorterDuff.Mode.SrcAtop);
                Control.ThumbDrawable.SetColorFilter(SwitchOffColor, PorterDuff.Mode.SrcAtop);
            }
        }
    }
}
