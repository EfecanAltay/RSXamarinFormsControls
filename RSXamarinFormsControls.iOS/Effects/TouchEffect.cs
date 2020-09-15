using System;
using System.Linq;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using RSXamarinFormsControls.iOS.Effects;

[assembly: ExportEffect(typeof(TouchEffect), "TouchEffect")]
namespace RSXamarinFormsControls.iOS.Effects
{
    public class TouchEffect : PlatformEffect
    {
        RSXamarinFormsControls.Effects.TouchEffect effect;
        Action onTouchAction;
        Action onLongPressAction;
        Action onReleaseAction;
        protected override void OnAttached()
        {
            var view = Control == null ? Container : Control;
            effect = (RSXamarinFormsControls.Effects.TouchEffect)Element.Effects.
                        FirstOrDefault(e => e is RSXamarinFormsControls.Effects.TouchEffect);
            if (effect != null && view != null)
            {
                onTouchAction = effect.OnTouchAction;
                onLongPressAction = effect.OnLongTouchAction;
                onReleaseAction = effect.OnReleasedTouchAction;

                var tapGesture = new UITapGestureRecognizer((action) =>
                {
                    onTouchAction();
                    onReleaseAction();
                });

                var longPress = new UILongPressGestureRecognizer((action) =>
                {
                    switch (action.State)
                    {
                        case UIGestureRecognizerState.Began:
                            onLongPressAction();
                            break;
                        case UIGestureRecognizerState.Ended:
                            onReleaseAction();
                            break;
                    }
                });

                view.AddGestureRecognizer(tapGesture);
                view.AddGestureRecognizer(longPress);
            }
        }

        protected override void OnDetached()
        {
        }
    }
}
