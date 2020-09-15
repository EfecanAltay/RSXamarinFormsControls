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

[assembly: ExportRenderer(typeof(CustomListView), typeof(CustomListViewRenderer))]
namespace RSXamarinFormsControls.iOS.CustomRenderer
{
    public class CustomListViewRenderer : ListViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.ShowsVerticalScrollIndicator = false;
            }
        }
    }
}