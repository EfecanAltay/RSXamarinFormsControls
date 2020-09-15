using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using RSXamarinFormsControls.Droid.CustomRenderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(MasterDetailPage), typeof(CustomMasterDetailPageRenderer))]
namespace RSXamarinFormsControls.Droid.CustomRenderer
{
    public class CustomMasterDetailPageRenderer : MasterDetailPageRenderer
    {
        public CustomMasterDetailPageRenderer(Context context) : base(context)
        {

        }    

        bool firstDone;
        public override void AddView(Android.Views.View child)
        {
            if (firstDone)
            {                
                var p = (LayoutParams)child.LayoutParameters;
                p.Width = 550;
                base.AddView(child, p);
            }
            else
            {
                firstDone = true;
                base.AddView(child);
            }

        }
    }
}
