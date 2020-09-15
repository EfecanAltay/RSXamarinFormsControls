using RSXamarinFormsControls.Resources;
using Xamarin.Forms;

namespace RSXamarinFormsControls
{
    public class RSXamarinForms
    {
        public static void Init
        (
                Color? RSPrimaryColor = null,
                Color? RSSecondColor = null,
                Color? RSTextColor = null,
                Color? RSBackground = null,
                Color? RSBackgroundDark = null
        )
        {
            var color = new ColorResource();
            if (RSPrimaryColor != null) color[nameof(RSPrimaryColor)] = RSPrimaryColor;
            if (RSSecondColor != null) color[nameof(RSSecondColor)] = RSSecondColor;
            if (RSTextColor != null) color[nameof(RSTextColor)] = RSTextColor;
            if (RSBackground != null) color[nameof(RSBackground)] = RSBackground;
            if (RSBackgroundDark != null) color[nameof(RSBackgroundDark)] = RSBackgroundDark;
            Application.Current.Resources.Add(color);
        }
    }
}
