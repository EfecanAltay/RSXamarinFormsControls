using System;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms.Xaml;

namespace InfiniMobile.CustomControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocationControlSuccessPopupView
    {
        public event EventHandler InnerButton_Clicked;

        public bool DialogResult = false;
        public object Data = null;
        public bool PopupBackIsvisible { get; } = false;
               
        public LocationControlSuccessPopupView()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (sender == Button1)
                DialogResult = true;

            else if (sender == Button2)
                DialogResult = false;
            
            IsVisible = false;

            if(InnerButton_Clicked != null)
            {
                InnerButton_Clicked(this, e);
            }
            await PopupNavigation.Instance.PopAsync();
        }

        protected override void OnDisappearing()
        {
            Utility.Utils.IsTapEnabled = true;
        }
    }
}
