using Xamarin.Forms;

namespace RSXamarinFormsControls.Controls
{
    public class RSActivityIndicator : ContentView
    {
        private const string AnimationName = "ActivityIndicator";
        private readonly Animation animation;
        private Image image;

        public static readonly BindableProperty IsRunningProperty = BindableProperty.Create(nameof(IsRunning), typeof(bool), typeof(RSActivityIndicator), default(bool));
        public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create(nameof(Source), typeof(ImageSource), typeof(RSActivityIndicator), default(ImageSource));

        public bool IsRunning
        {
            get => (bool)GetValue(IsRunningProperty);
            set => SetValue(IsRunningProperty, value);
        }

        public ImageSource Source
        {
            get => (ImageSource)GetValue(ImageSourceProperty);
            set => SetValue(ImageSourceProperty, value);
        }

        public RSActivityIndicator()
        {
            image = new Image();
            Content = image;
            HorizontalOptions = LayoutOptions.Center;
            VerticalOptions = LayoutOptions.Center;
            WidthRequest = 44;
            HeightRequest = 44;
            Source = RSFileImageExtension.Convert("loadingdot.png");
            Scale = 0;

            animation = new Animation(v => Rotation = v, 0, 360);
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == nameof(IsRunning) && IsEnabled)
            {
                if (IsRunning)
                    StartAnimation();
                else
                    StopAnimation();
            }

            if (propertyName == nameof(IsEnabled) && !IsEnabled && IsRunning)
                StopAnimation();

            if (propertyName == nameof(Source))
                image.Source = Source;
        }

        private void StartAnimation()
        {
            this.ScaleTo(1, 500);
            animation.Commit(this, AnimationName, 16, 1200, Easing.Linear, (v, c) => Rotation = 0, () => true);
        }

        private async void StopAnimation()
        {
            await this.ScaleTo(0, 500);
            this.AbortAnimation(AnimationName);
        }
    }
}
