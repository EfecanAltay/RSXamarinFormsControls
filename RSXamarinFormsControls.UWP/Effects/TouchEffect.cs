using System;
using System.Diagnostics;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportEffect(typeof(RSXamarinFormsControls.UWP.Effects.TouchEffect), "TouchEffect")]
namespace RSXamarinFormsControls.UWP.Effects
{
    public class TouchEffect : PlatformEffect
    {
        FrameworkElement frameworkElement;
        RSXamarinFormsControls.Effects.TouchEffect effect;
        Action onTouchAction;
        Action onLongTouchAction;
        Action onReleasedTouchAction;
        bool isTouchReleased = false;
        protected override void OnAttached()
        {
            frameworkElement = Control == null ? Container : Control;

            // Get access to the TouchEffect class in the .NET Standard library
            effect = (RSXamarinFormsControls.Effects.TouchEffect)Element.Effects.
                        FirstOrDefault(e => e is RSXamarinFormsControls.Effects.TouchEffect);
            if (effect != null && frameworkElement != null)
            {
                // Save the method to call on touch events
                onTouchAction = effect.OnTouchAction;
                onLongTouchAction = effect.OnLongTouchAction;
                onReleasedTouchAction = effect.OnReleasedTouchAction;

                // Set event handlers on FrameworkElement
                frameworkElement.PointerPressed += FrameworkElement_PointerPressed;
                frameworkElement.PointerReleased += FrameworkElement_PointerReleased;
            }
        }

        private void FrameworkElement_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void FrameworkElement_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            Debug.WriteLine("Released");
            isTouchReleased = true;
            onReleasedTouchAction();
        }

        private void FrameworkElement_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            Debug.WriteLine("Pressed");
            float pressingTimer = 0f;
            isTouchReleased = false;
            Device.StartTimer(TimeSpan.FromMilliseconds(100), () =>
            {
                pressingTimer += 1;
                if (isTouchReleased)
                {
                    onTouchAction();
                    return false;
                }
                if (pressingTimer >= 10)
                {
                    onLongTouchAction();
                    return false;
                }
                return true;
            });
        }

        protected override void OnDetached()
        {

        }
    }

}
