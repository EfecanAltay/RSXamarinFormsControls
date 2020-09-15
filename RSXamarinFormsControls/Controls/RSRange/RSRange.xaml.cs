using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RSXamarinFormsControls.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RSRange : ContentView
    {
        public EventHandler<RSRangeEventArgs> ValuesChanged;
        private double minValue = 0;
        private double maxValue = 1;

        public RSRange()
        {
            InitializeComponent();
        }

        #region lblheaderMin Text
        private string headerMinText;
        public string HeaderMinText
        {
            get { return headerMinText; }
            set
            {
                HeaderMinTextPropertyChanged(this, headerMinText, value);
                headerMinText = value;
            }
        }

        public static readonly BindableProperty HeaderMinTextProperty = BindableProperty.Create(
         propertyName: "HeaderMinText",
         returnType: typeof(string),
         declaringType: typeof(RSRange),
         defaultValue: "",
         defaultBindingMode: BindingMode.TwoWay,
         propertyChanged: HeaderMinTextPropertyChanged);

        private static void HeaderMinTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (RSRange)bindable;
            control.lblheaderMin.Text = (string)newValue;
            control.input1.Placeholder = (string)newValue;
        }
        #endregion

        #region lblheaderMax Text
        private string headerMaxText;
        public string HeaderMaxText
        {
            get { return headerMaxText; }
            set
            {
                HeaderMaxTextPropertyChanged(this, headerMaxText, value);
                headerMaxText = value;
            }
        }

        public static readonly BindableProperty HeaderMaxTextProperty = BindableProperty.Create(
         propertyName: "HeaderMaxText",
         returnType: typeof(string),
         declaringType: typeof(RSRange),
         defaultValue: "",
         defaultBindingMode: BindingMode.TwoWay,
         propertyChanged: HeaderMaxTextPropertyChanged);

        private static void HeaderMaxTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (RSRange)bindable;
            control.lblheaderMax.Text = (string)newValue;
            control.input2.Placeholder = (string)newValue;
        }
        #endregion

        private void Input1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(e.NewTextValue) == false)
            {
                try
                {
                    if (String.IsNullOrWhiteSpace(e.NewTextValue) == false)
                    {
                        minValue = int.Parse(e.NewTextValue);
                        if (minValue >= maxValue)
                        {
                            maxValue = minValue + 1;
                            input2.Placeholder = "" + maxValue;
                            if (String.IsNullOrWhiteSpace(input2.Text) == false)
                                input2.Text = "" + maxValue;
                        }
                    }
                }
                catch
                {
                    //
                }
            }
            else
            {
                minValue = 0;
                input1.Placeholder = "" + minValue;
            }
            ValuesChanged?.Invoke(sender, new RSRangeEventArgs() { minValue = minValue, maxValue = maxValue });
        }

        private void Input2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(e.NewTextValue) == false)
            {
                try
                {
                    maxValue = int.Parse(e.NewTextValue);
                }
                catch
                {
                    //
                }
            }
            else
            {
                maxValue = minValue + 1;
                input2.Placeholder = "" + maxValue;
            }
            ValuesChanged?.Invoke(sender, new RSRangeEventArgs() { minValue = minValue, maxValue = maxValue });
        }

        private void Input2_Unfocused(object sender, FocusEventArgs e)
        {
            if (minValue >= maxValue)
            {
                //this.Warning("Max Minden küçük olamaz", "Hatalı Değer");
                maxValue = minValue + 1;
                input2.Text = "" + maxValue;
                ValuesChanged?.Invoke(sender, new RSRangeEventArgs() { minValue = minValue, maxValue = maxValue });
            }

        }
    }
}
