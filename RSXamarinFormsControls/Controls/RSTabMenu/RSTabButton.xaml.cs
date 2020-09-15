using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RSXamarinFormsControls.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RSTabButton : ContentView
    {
        public event EventHandler<RSTabButtonEventArgs> tabButtonCallback;

        public string Tag
        {
            get
            {
                return _menuItemData?.Tag;
            }
        }

        private RSTabItemData _menuItemData = null;
        public TapGestureRecognizer TabGesture;

        public RSTabButton()
        {
            InitializeComponent();
            TabGesture = new TapGestureRecognizer();
            TabGesture.Command = TabGestureCommand;
            ContentRoot.GestureRecognizers.Add(TabGesture);
            lblText.TextColor = Color.FromHex("#9f9d9d");
            selectLine.IsVisible = false;
        }

        public void SetMenuItemData(RSTabItemData menuItemData)
        {
            _menuItemData = menuItemData;
            Text = _menuItemData.Text;
        }

        public Command TabGestureCommand => new Command(() =>
        {
            tabButtonCallback?.Invoke(this, new RSTabButtonEventArgs() { menuButtonData = _menuItemData });
        });

        #region IsActive Prop
        private bool isActive;
        public bool IsActive
        {
            get { return isActive; }
            set
            {
                IsActivePropertyChanged(this, isActive, value);
                isActive = value;
            }
        }

        public static readonly BindableProperty IsActiveProperty = BindableProperty.Create(
                 propertyName: "IsActive",
                 returnType: typeof(bool),
                 declaringType: typeof(RSTabButton),
                 defaultValue: false,
                 defaultBindingMode: BindingMode.TwoWay,
                 propertyChanged: IsActivePropertyChanged);

        private static void IsActivePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var controller = (RSTabButton)bindable;

            if ((bool)newValue)
            {
                controller.lblText.TextColor = Color.FromHex("#354145");
                controller.selectLine.IsVisible = true;
            }
            else
            {
                controller.lblText.TextColor = Color.FromHex("#9f9d9d");
                controller.selectLine.IsVisible = false;
            }
        }
        #endregion

        #region Text Prop
        private string text;
        public string Text
        {
            get { return text; }
            set
            {
                TextPropertyChanged(this, text, value);
                text = value;
            }
        }

        public static readonly BindableProperty TextProperty = BindableProperty.Create(
                 propertyName: "Text",
                 returnType: typeof(string),
                 declaringType: typeof(RSTabButton),
                 defaultValue: "",
                 defaultBindingMode: BindingMode.TwoWay,
                 propertyChanged: TextPropertyChanged);

        private static void TextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var controller = (RSTabButton)bindable;
            controller.lblText.Text = (string)newValue;
        }
        #endregion
    }
}
