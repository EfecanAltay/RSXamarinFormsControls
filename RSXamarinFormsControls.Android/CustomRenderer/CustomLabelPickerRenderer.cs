using System;
using System.Threading.Tasks;
using Android.Content;
using Android.Text.Format;
using Android.Views;
using RSXamarinFormsControls.CustomControls;
using RSXamarinFormsControls.Droid.CustomRenderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomLabelPicker), typeof(CustomLabelPickerRenderer))]
namespace RSXamarinFormsControls.Droid.CustomRenderer
{
    public class CustomLabelPickerRenderer : LabelRenderer
    {
        private Label label;
        private bool longTab = false;
        private bool isTimerLive = false;
        
        public CustomLabelPickerRenderer(Context context) : base(context)
        {
        

        }
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                label = e.NewElement;
            }
        }

        public override bool OnTouchEvent(MotionEvent e)
        {
            if (e.Action == MotionEventActions.Down)
            {
                if(longTab == false)
                {
                    Device.StartTimer(TimeSpan.FromMilliseconds(700), () =>
                    {
                        longTab = true;
                        return false;
                    });
                }
            }
            else if(e.Action == MotionEventActions.Move)
            {
                if (longTab && isTimerLive == false)
                {
                    Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                    {
                        SetValue(10);
                        isTimerLive = longTab;
                        Console.WriteLine("time");
                        return longTab;
                    });
                }
            }
            else if (e.Action == MotionEventActions.Up)
            {
                longTab = false;
                if (longTab == false)
                {
                    SetValue(1);
                }
            }
            return true;
        }

        private void SetValue(int value)
        {
            var entryCounter = (Entry)((AbsoluteLayout)((StackLayout)label.Parent).Children[1]).Children[2];
            int entryCounterValue = Convert.ToInt32(entryCounter.Text);
            if (label.Text == "+")
            {
                entryCounter.Text = (entryCounterValue + value).ToString();
            }
            else if (label.Text == "-")
            {
                
                if (entryCounterValue - value > 0)
                {
                    entryCounter.Text = (entryCounterValue - value).ToString();
                }else
                {
                    entryCounter.Text = "0";
                }
            }
        }
    }
}
