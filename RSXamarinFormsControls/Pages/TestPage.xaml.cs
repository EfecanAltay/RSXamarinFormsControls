
using RSXamarinFormsControls.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RSXamarinFormsControls.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestPage : ContentPage
    {
        TestPageViewModel bindingContent;
        public TestPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            bindingContent = (TestPageViewModel)BindingContext;

            RSSelection.AddItem("A");
            RSSelection.AddItem("B");
            RSSelection.AddItem("C");
        }
    }
}