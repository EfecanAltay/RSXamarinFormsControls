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
using Xamarin.Forms.Platform.Android;
using Android.Graphics.Drawables;
using Xamarin.Forms;
using System.ComponentModel;
using RSXamarinFormsControls.CustomControls;
using RSXamarinFormsControls.Droid.CustomRenderer;

[assembly: ExportRenderer(typeof(CustomViewCell),typeof(CustomViewCellRenderer))]
namespace RSXamarinFormsControls.Droid.CustomRenderer
{
    public class CustomViewCellRenderer : ViewCellRenderer
    {
        private Android.Views.View cellCore;
        private Drawable unselectedBackground;
        private bool selected;

        protected override Android.Views.View GetCellCore(Cell item, Android.Views.View convertView,ViewGroup parent,Context context)
        {
            cellCore = base.GetCellCore(item, convertView, parent, context);
            selected = false;
            unselectedBackground = cellCore.Background;
            return cellCore;
        }

        protected override void OnCellPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            base.OnCellPropertyChanged(sender, args);
            if (args.PropertyName == "IsSelected")
            {
                selected = !selected;
                if (selected)
                {
                    var customViewCell = sender as CustomViewCell;
                    cellCore.SetBackgroundColor(customViewCell.SelectedBackgroundColor.ToAndroid());
                }
                else
                {
                    cellCore.SetBackground(unselectedBackground);
                }
            }
        }
    }
}
