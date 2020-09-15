using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;

using Foundation;
using RSXamarinFormsControls.iOS.CustomRenderer;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(MasterDetailPage), typeof(CustomMasterDetailPageRenderer))]
namespace RSXamarinFormsControls.iOS.CustomRenderer
{
    public class CustomMasterDetailPageRenderer : PhoneMasterDetailRenderer
    {        
       
    }
}
