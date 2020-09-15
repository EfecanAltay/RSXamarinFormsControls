using Xamarin.Forms;

namespace RSXamarinFormsControls.Controls
{
    public class RSPicker : Picker
    {
        public static readonly BindableProperty ImageProperty = BindableProperty.Create(nameof(Icon), typeof(string), typeof(RSPicker), string.Empty);

        public string Icon
        {
            get
            {
                return (string)GetValue(ImageProperty);
            }
            set
            {
                SetValue(ImageProperty, value);
            }
        }
    }
}
