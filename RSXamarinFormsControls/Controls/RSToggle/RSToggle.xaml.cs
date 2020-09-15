using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RSXamarinFormsControls.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RSToggle : ContentView
    {
        public event EventHandler<RSToggleButtonEventArgs> toggledCallback;

        private bool isActive;
        public bool IsActive
        {
            get { return isActive; }
            set
            {
                isActive = value;
                OnPropertyChanged("IsActive");
            }
        }

        private string text;
        public string Text
        {
            get { return text; }
            set
            {
                TitleTextPropertyChanged(this, text, value);
                text = value;
            }
        }

        private static void TitleTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (RSToggle)bindable;
            control.lblText.Text = newValue.ToString();
        }
        public static readonly BindableProperty TitleTextProperty = BindableProperty.Create(
                                                         propertyName: "Text",
                                                         returnType: typeof(string),
                                                         declaringType: typeof(RSToggle),
                                                         defaultValue: "",
                                                         defaultBindingMode: BindingMode.TwoWay,
                                                         propertyChanged: TitleTextPropertyChanged);

        public RSToggle()
        {
            InitializeComponent();
        }

        private void CheckFrame_Tapped(object sender, EventArgs e)
        {
            try
            {
                IsEnabled = false;
                isActive = !tickIcon.IsVisible;
                tickIcon.IsVisible = IsActive;
            }
            catch
            {

            }
            finally
            {
                IsEnabled = true;
                toggledCallback?.Invoke(this, new RSToggleButtonEventArgs() { IsActive = this.IsActive, Text = this.Text });
            }
        }

        public void SetActive(bool isActive)
        {
            this.IsActive = isActive;
            tickIcon.IsVisible = isActive;
        }
    }
}
