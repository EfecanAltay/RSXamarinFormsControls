using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RSXamarinFormsControls.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RSExpandableButton : ContentView
    {
        private bool isActive;
        public bool IsActive
        {
            get { return isActive; }
        }

        private ButtonStatus buttonStatus { get; set; }

        public void SetActive(ButtonStatus buttonStatus)
        {
            this.buttonStatus = buttonStatus;
            switch (buttonStatus)
            {
                case ButtonStatus.Closing:
                    isActive = false;
                    expandableImage.Text = Common.IconFont.ArrowDropDown;
                    expandableImage.RotateTo(90);
                    break;
                case ButtonStatus.Waiting:
                    isActive = true;
                    expandableImage.Text = Common.IconFont.ArrowDropDown;
                    expandableImage.RotateTo(0);
                    break;
                case ButtonStatus.Opening:
                    isActive = true;
                    expandableImage.Text = Common.IconFont.ArrowDropDown;
                    expandableImage.RotateTo(0);
                    break;
            }
            OnPropertyChanged("IsActive");
        }

        public RSExpandableButton()
        {
            InitializeComponent();
            expandableImage.Text = Common.IconFont.ArrowDropDown;
            expandableImage.RotateTo(90);
        }

        public enum ButtonStatus
        {
            Closing, Waiting, Opening
        }
    }
}
