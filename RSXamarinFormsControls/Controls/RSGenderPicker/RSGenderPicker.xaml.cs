using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RSXamarinFormsControls.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RSGenderPicker : ContentView
    {
        Color defaultColor ;
        Color selectionColor ;

        public bool IsSelected = false;
        public bool IsSelectedMan = false;
        public RSGenderPicker()
        {
            InitializeComponent();
            defaultColor = (Color)Application.Current.Resources["BackgroundDark"];
            selectionColor = (Color)Application.Current.Resources["PrimaryColor"];
        }

        private void TapGestureRecognizerMan_Tapped(object sender, System.EventArgs e)
        {
            lblMan.TextColor = selectionColor;
            lblMan.FontSize = 48;
            lblWoman.FontSize = 32;
            lblWoman.TextColor = defaultColor;
            IsSelected = true;
            IsSelectedMan = true;
        }

        private void TapGestureRecognizerWoman_Tapped(object sender, System.EventArgs e)
        {
            lblWoman.TextColor = selectionColor;
            lblWoman.FontSize = 48;
            lblMan.FontSize = 32;
            lblMan.TextColor = defaultColor;
            IsSelected = true;
            IsSelectedMan = false;
        }
    }
}