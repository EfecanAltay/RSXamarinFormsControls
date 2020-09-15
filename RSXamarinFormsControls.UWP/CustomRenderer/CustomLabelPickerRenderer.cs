using System;
using RSXamarinFormsControls.Controls;
using RSXamarinFormsControls.UWP.CustomRenderer;
using Windows.UI.Xaml.Input;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(RSLabelPicker), typeof(CustomLabelPickerRenderer))]
namespace RSXamarinFormsControls.UWP.CustomRenderer
{
    public class CustomLabelPickerRenderer : LabelRenderer
    {
        Label Label;
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Label = e.NewElement;
                this.Control.Holding += Label_Holding;
                this.Control.Tapped += Label_Tapped;
            }

        }

        void Label_Holding(object sender, HoldingRoutedEventArgs args)
        {
            var entryCounter = (Entry)((AbsoluteLayout)((StackLayout)Label.Parent).Children[1]).Children[2];
            if (Label.Text == "+")
            {
                entryCounter.Text = (Convert.ToInt32(entryCounter.Text) + 10).ToString();

            }
            else if (Label.Text == "-")
            {
                if (Convert.ToInt32(entryCounter.Text) > 10)
                {
                    entryCounter.Text = (Convert.ToInt32(entryCounter.Text) - 10).ToString();
                }
            }
        }

        void Label_Tapped(object sender, TappedRoutedEventArgs args)
        {
            var entryCounter = (Entry)((AbsoluteLayout)((StackLayout)Label.Parent).Children[1]).Children[2];
            if (Label.Text == "+")
            {
                entryCounter.Text = (Convert.ToInt32(entryCounter.Text) + 1).ToString();

            }
            else if (Label.Text == "-")
            {
                if (Convert.ToInt32(entryCounter.Text) > 0)
                {
                    entryCounter.Text = (Convert.ToInt32(entryCounter.Text) - 1).ToString();
                }
            }
        }
    }
}
