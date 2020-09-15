using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RSXamarinFormsControls.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RSExtendableView : ContentView
    {
        public Action<bool> ExtendAction;

        #region Content
        private DataTemplate contentLayout;
        public DataTemplate ContentLayout
        {
            get { return contentLayout; }
            set
            {
                ContentPropertyChanged(this, contentLayout, value);
                contentLayout = value;
            }
        }

        public static readonly BindableProperty ContentLayoutProperty = BindableProperty.Create(
                 propertyName: "ContentLayout",
                 returnType: typeof(DataTemplate),
                 declaringType: typeof(DataTemplate),
                 defaultValue: null,
                 defaultBindingMode: BindingMode.TwoWay,
                 propertyChanged: ContentPropertyChanged);

        private static void ContentPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (RSExtendableView)bindable;
            var value = (DataTemplate)newValue;
            control.contentStackLayout.Children.Add((View)value.CreateContent());
        }
        #endregion

        private bool isActive = false;
        public RSExtendableView()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            isActive = !isActive;
            contentStackLayout.IsVisible = isActive;
            lineSeparator.IsVisible = isActive;
            if (isActive)
                ebSpeciality.SetActive(RSExpandableButton.ButtonStatus.Waiting);
            else
                ebSpeciality.SetActive(RSExpandableButton.ButtonStatus.Closing);
            ExtendAction?.Invoke(isActive);
        }

        public void OnLoadComplated()
        {
            ebSpeciality.SetActive(RSExpandableButton.ButtonStatus.Opening);
        }

        public void SetContentView<T>(T view) where T : View
        {
            contentStackLayout.Children.Clear();
            contentStackLayout.Children.Add(view);
        }
    }
}