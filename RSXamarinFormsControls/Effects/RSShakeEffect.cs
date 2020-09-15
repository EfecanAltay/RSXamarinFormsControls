using Xamarin.Forms;

namespace RSXamarinFormsControls.Effects
{
    public class RSShakeEffect
    {
        public async void ShortShake(View name)
        {
            uint timeout = 50;
            await name.TranslateTo(15, 0, timeout);
            await name.TranslateTo(-15, 0, timeout);
            await name.TranslateTo(10, 0, timeout);
            await name.TranslateTo(-10, 0, timeout);
            await name.TranslateTo(5, 0, timeout);
            await name.TranslateTo(-5, 0, timeout);
            name.TranslationX = 0;
        }

    }
}
