using RSXamarinFormsControls.Resources;
using Xamarin.Forms;

namespace RSXamarinFormsControls
{
    public class RSXamarinForms
    {
        public static void Init()
        {
            Application.Current.Resources.Add(new ColorResource());
        }
    }
}
