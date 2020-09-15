using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportEffect(typeof(RSXamarinFormsControls.Droid.Effects.RSTouchEffect), "TouchEffect")]
namespace RSXamarinFormsControls.Droid.Effects
{
    public class RSTouchEffect : PlatformEffect
    {
        RSXamarinFormsControls.Effects.RSTouchEffect effect;
        Action onTouchAction;
        Action OnLongTouchAction;
        Action OnReleaseTouchAction;

        static Dictionary<Android.Views.View, RSTouchEffect> viewDictionary =
            new Dictionary<Android.Views.View, RSTouchEffect>();

        static Dictionary<int, RSTouchEffect> idToEffectDictionary =
                new Dictionary<int, RSTouchEffect>();

        protected override void OnAttached()
        {
            var view = Control == null ? Container : Control;

            // Get access to the TouchEffect class in the .NET Standard library
            effect = (RSXamarinFormsControls.Effects.RSTouchEffect)Element.Effects.
                        FirstOrDefault(e => e is RSXamarinFormsControls.Effects.RSTouchEffect);

            if (effect != null && view != null)
            {
                onTouchAction = effect.OnTouchAction;
                OnLongTouchAction = effect.OnLongTouchAction;
                OnReleaseTouchAction = effect.OnReleasedTouchAction;
                view.LongClick += View_LongClick;
                view.Click += View_Click;
                view.Touch += View_Touch;
            }
        }

        private void View_Touch(object sender, Android.Views.View.TouchEventArgs e)
        {
            e.Handled = false;
            if (e.Event.Action == Android.Views.MotionEventActions.Up)
                OnReleaseTouchAction?.Invoke();
        }

        private void View_LongClick(object sender, Android.Views.View.LongClickEventArgs e)
        {
            OnLongTouchAction?.Invoke();
        }

        private void View_Click(object sender, EventArgs e)
        {
            onTouchAction?.Invoke();
        }

        protected override void OnDetached()
        {
        }
    }
}
