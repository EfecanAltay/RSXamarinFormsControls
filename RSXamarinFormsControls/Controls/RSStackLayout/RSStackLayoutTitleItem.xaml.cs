using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RSXamarinFormsControls.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RSStackLayoutTitleItem : ContentView
    {
        #region TitleText
        private string titleText;
        public string TitleText
        {
            get { return titleText; }
            set
            {
                TitleTextPropertyChanged(this, titleText, value);
                titleText = value;
            }
        }

        private static void TitleTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (RSStackLayoutTitleItem)bindable;
            control.title.Text = newValue.ToString();
        }
        public static readonly BindableProperty TitleTextProperty = BindableProperty.Create(
                                                         propertyName: "TitleText",
                                                         returnType: typeof(string),
                                                         declaringType: typeof(RSStackLayoutTitleItem),
                                                         defaultValue: "",
                                                         defaultBindingMode: BindingMode.TwoWay,
                                                         propertyChanged: TitleTextPropertyChanged);
        #endregion

        #region LineSeparatorVisiable
        private bool lineSeparatorVisiable;
        public bool LineSeparatorVisiable
        {
            get { return lineSeparatorVisiable; }
            set
            {
                LineSeparatorVisiablePropertyChanged(this, lineSeparatorVisiable, value);
                lineSeparatorVisiable = value;
            }
        }
        public static readonly BindableProperty LineSeparatorVisiableProperty = BindableProperty.Create(
                 propertyName: "LineSeparatorVisiable",
                 returnType: typeof(bool),
                 declaringType: typeof(RSStackLayoutTitleItem),
                 defaultValue: true,
                 defaultBindingMode: BindingMode.TwoWay,
                 propertyChanged: LineSeparatorVisiablePropertyChanged);
        private static void LineSeparatorVisiablePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (RSStackLayoutTitleItem)bindable;
            control.lineSeparator.IsVisible = (bool)newValue;
        }
        #endregion

        #region TextMargin
        private Thickness textMargin;
        public Thickness TextMargin
        {
            get { return textMargin; }
            set
            {
                TextMarginPropertyChanged(this, textMargin, value);
                textMargin = value;
            }
        }
        private static void TextMarginPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (RSStackLayoutTitleItem)bindable;
            control.title.Margin = (Thickness)newValue;
        }
        public static readonly BindableProperty TextMarginProperty = BindableProperty.Create(
                                                         propertyName: "TitleText",
                                                         returnType: typeof(Thickness),
                                                         declaringType: typeof(RSStackLayoutTitleItem),
                                                         defaultValue: new Thickness(0, 0, 0, 0),
                                                         defaultBindingMode: BindingMode.TwoWay,
                                                         propertyChanged: TextMarginPropertyChanged);
        #endregion

        #region RowHeight
        private int rowHeight;
        public int RowHeight
        {
            get { return rowHeight; }
            set
            {
                RowHeightPropertyChanged(this, rowHeight, value);
                textMargin = value;
            }
        }

        private static void RowHeightPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (RSStackLayoutTitleItem)bindable;
            control.contentRoot.RowDefinitions[0].Height = (int)newValue;
        }
        public static readonly BindableProperty RowHeightProperty = BindableProperty.Create(
                                                         propertyName: "RowHeight",
                                                         returnType: typeof(int),
                                                         declaringType: typeof(RSStackLayoutTitleItem),
                                                         defaultValue: 73,
                                                         defaultBindingMode: BindingMode.TwoWay,
                                                         propertyChanged: RowHeightPropertyChanged);
        #endregion

        public RSStackLayoutTitleItem()
        {
            InitializeComponent();
        }

    }
}
