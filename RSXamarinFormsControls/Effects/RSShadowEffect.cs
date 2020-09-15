using Xamarin.Forms;

namespace RSXamarinFormsControls.Effects
{
    public class RSShadowEffect : RoutingEffect
    {
        public float Radius { get; set; }

        public Color Color { get; set; }

        public float DistanceX { get; set; }

        public float DistanceY { get; set; }

        public RSShadowEffect() : base("Vapolia.LabelShadowEffect")
        {
        }
    }
}
