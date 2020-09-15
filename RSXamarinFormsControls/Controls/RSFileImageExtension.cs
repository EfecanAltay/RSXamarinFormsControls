using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

/// <summary>
/// See: https://blog.mzikmund.com/2019/02/how-to-keep-local-images-out-of-root-folder-of-xamarin-forms-uwp-project/ and
/// https://github.com/xamarin/Xamarin.Forms/pull/3420
/// </summary>
namespace RSXamarinFormsControls.Controls
{
    [ContentProperty(nameof(Path))]
    public class RSFileImageExtension : IMarkupExtension<FileImageSource>
    {
        public string Path { get; set; }

        public FileImageSource ProvideValue(IServiceProvider serviceProvider) => Convert(Path);

        public static FileImageSource Convert(string path)
        {
            if (path == null) throw new InvalidOperationException($"Cannot convert null to {typeof(ImageSource)}");

            if (Device.RuntimePlatform == Device.UWP)
            {
                path = System.IO.Path.Combine("Images/", path);
            }
            return (FileImageSource)ImageSource.FromFile(path);
        }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            return ProvideValue(serviceProvider);
        }
    }
}
