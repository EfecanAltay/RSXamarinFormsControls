using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
/// <summary>
/// Custom Slider:
/// https://medium.com/@sumeyyaarar/xamarin-forms-custom-slider-with-floating-text-26b09af707cd
/// </summary>
namespace RSXamarinFormsControls.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RSSlider : ContentView
    {
        public EventHandler<EventArgs> SliderValueChanged;
        public RSSlider()
        {
            InitializeComponent();
            Device.StartTimer(TimeSpan.FromMilliseconds(500), Initialize);
        }

        public bool Initialize()
        {
            var newStep = Math.Round(10000d / 100);
            mySlider.Value = newStep * 100;
            infoText.TranslateTo(mySlider.Value * ((mySlider.Width - infoText.ColumnDefinitions[0].Width.Value) / mySlider.Maximum), 0, 10);
            lblText.Text = mySlider.Value.ToString();
            return false;
        }

        private void Slider_ValueChanged(object sender, Xamarin.Forms.ValueChangedEventArgs e)
        {
            var newStep = Math.Round(e.NewValue / 100);
            mySlider.Value = newStep * 100;
            infoText.TranslateTo(mySlider.Value * ((mySlider.Width - infoText.ColumnDefinitions[0].Width.Value) / mySlider.Maximum), 0, 10);
            lblText.Text = mySlider.Value.ToString();
            SliderValueChanged?.Invoke(sender, e);
        }

        public void SetValue(int value)
        {
            var newStep = Math.Round((double)value / 100);
            mySlider.Value = newStep * 100;
            infoText.TranslateTo(mySlider.Value * ((mySlider.Width - infoText.ColumnDefinitions[0].Width.Value) / mySlider.Maximum), 0, 10);
            lblText.Text = mySlider.Value.ToString();
        }

        public int GetValue()
        {
            return (int)mySlider?.Value;
        }
    }
}
