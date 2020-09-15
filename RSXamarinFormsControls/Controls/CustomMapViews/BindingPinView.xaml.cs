using InfiniMobile.CustomControls.CustomMapViews;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InfiniMobile.CustomControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BindingPinView : Grid
    {
        public BindingPinView(PinData pindata)
        {
            InitializeComponent();
            switch (pindata.BindingPinType)
            {
                case BindingPinType.Normal:
                    SetActive(pindata.IsActive, pindata.BindingPinCardType);
                    HeightRequest = 90;
                    RootInfoFrame.IsVisible = false;
                    SetRow(frame, 0);
                    RowDefinitions.RemoveAt(0);
                    break;
                case BindingPinType.Info:
                    SetActive(pindata.IsActive, pindata.BindingPinCardType);
                    InfoText.Text = pindata.Cost.ToString();
                    break;
                default:
                    break;
            }
        }

        public void SetActive(bool isActive, BindingPinCardType bindingPinCardType)
        {
            if (isActive)
            {
                frame.Margin = new Thickness(0, 0, 0, 0);
                frame.WidthRequest = frame.HeightRequest = 90;
                frame.CornerRadius = 45;
                image.WidthRequest = 45;
                image.HeightRequest = 45;
            }
            switch (bindingPinCardType)
            {
                case BindingPinCardType.Pharmist:
                    if (isActive)
                    {
                        image.Source = FileImageExtension.Convert("pharmacist_white.png");
                        frame.BackgroundColor = (Color)Application.Current.Resources["DarkGreenColor"];
                    }
                    else
                        image.Source = FileImageExtension.Convert("pharmacist_green.png");
                    break;
                case BindingPinCardType.Doctor:
                    if (isActive)
                    {
                        image.Source = FileImageExtension.Convert("doctor_card_white.png");
                        frame.BackgroundColor = (Color)Application.Current.Resources["DarkBlueTitle"];
                    }
                    else
                        image.Source = FileImageExtension.Convert("doctor_card_info.png");
                    break;
                case BindingPinCardType.Hospital:
                    if (isActive)
                    {
                        image.Source = FileImageExtension.Convert("hospital_white.png");
                        frame.BackgroundColor = (Color)Application.Current.Resources["DarkBlueTitle"];
                    }
                    else
                        image.Source = FileImageExtension.Convert("hospital.png");
                    break;
                default:
                    break;
            }
        }

        public void SetDraging()
        {
            frame.Margin = new Thickness(0, 0, 0, 0);
            frame.WidthRequest = frame.HeightRequest = 90;
            frame.CornerRadius = 45;
            image.WidthRequest = 45;
            image.HeightRequest = 45;
            frame.BorderColor = (Color)Application.Current.Resources["DarkGreenColor"];
        }

        public void SetDropping()
        {
            frame.Margin = new Thickness(0, 0, 0, 0);
            frame.WidthRequest = frame.HeightRequest = 70;
            frame.CornerRadius = 35;
            image.WidthRequest = 36;
            image.HeightRequest = 36;
            frame.BorderColor = Color.White;
        }

        private void SetCardType(BindingPinCardType bindingPinCardType , bool isActive)
        {

        }
    }
    public enum BindingPinCardType
    {
        Pharmist, Doctor, Hospital
    }
    public enum BindingPinType
    {
        Normal, Info
    }
}
