using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RSXamarinFormsControls.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RSNumberPicker : ContentView
    {
        private bool selectionMode = false;
        public int selectedNumber = 0;
        public RSNumberPicker()
        {
            InitializeComponent();
            rspwSelectedNumber.TappedAction = () =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    ToggleControl();
                });
            };
        }

        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            ToggleControl();
        }

        private void ToggleControl()
        {
            selectionMode = !selectionMode;
            if (selectionMode)
            {
                rspwSelectedNumber.IsVisible = true;
                lblSelectedNumber.IsVisible = false;
            }
            else
            {
                lblSelectedNumber.IsVisible = true;
                rspwSelectedNumber.IsVisible = false;
                selectedNumber = rspwSelectedNumber.SelectedNumber;
                lblSelectedNumber.Text = rspwSelectedNumber.SelectedNumber.ToString();
            }
        }
    }
}