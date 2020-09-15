using System.Linq;
using RSXamarinFormsControls.Droid.Effects;
using RSXamarinFormsControls.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("Vapolia")]
[assembly: ExportEffect(typeof(RSLabelShadowEffect), "RSLabelShadowEffect")]
namespace RSXamarinFormsControls.Droid.Effects
{
    public class RSLabelShadowEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            try
            {
                var control = Control as Android.Widget.TextView;
                var effect = (RSShadowEffect)Element.Effects.FirstOrDefault(e => e is RSShadowEffect);
                if (effect != null)
                {
                    float radius = effect.Radius;
                    float distanceX = effect.DistanceX;
                    float distanceY = effect.DistanceY;
                    Android.Graphics.Color color = effect.Color.ToAndroid();
                    control.SetShadowLayer(radius, distanceX, distanceY, color);
                }
            }
            catch
            {
                
            }
        }

        protected override void OnDetached()
        {
        }
    }
}
