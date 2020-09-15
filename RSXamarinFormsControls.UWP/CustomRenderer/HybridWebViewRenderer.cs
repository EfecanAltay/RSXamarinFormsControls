using System;
using System.ComponentModel;
using System.Threading.Tasks;
using RSXamarinFormsControls.CustomControls;
using RSXamarinFormsControls.UWP.CustomRenderers;
using Windows.Foundation;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls;
using Windows.Web;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(HybridWebView), typeof(HybridWebViewRenderer))]
/// <summary>
/// See: https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/custom-renderer/hybridwebview
/// </summary>
namespace RSXamarinFormsControls.UWP.CustomRenderers
{
    public class HybridWebViewRenderer : ViewRenderer<HybridWebView, Windows.UI.Xaml.Controls.WebView>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<HybridWebView> e)
        {
            base.OnElementChanged(e);

            // if disposing, NewElement is null. In that case just return
            if (e.NewElement == null)
                return;

            if (Control == null)
            {
                SetNativeControl(new Windows.UI.Xaml.Controls.WebView());
            }

            if (e.OldElement != null)
            {

                Element.InvokeScript -= Element_InvokeScriptEvent;
                Control.NavigationCompleted -= OnWebViewNavigationCompleted;
                Control.ScriptNotify -= OnWebViewScriptNotify;
            }

            if (e.NewElement != null)
            {
                Element.InvokeScript += Element_InvokeScriptEvent;
                Control.NavigationCompleted += OnWebViewNavigationCompleted;
                Control.ScriptNotify += OnWebViewScriptNotify;
            }
        }

        private async void EmbedJS()
        {
            const string JS_NOTIFY_SCRIPT = "function NotifyApp(data){window.external.notify(data);}";
            await Control.InvokeScriptAsync("eval", new[] { JS_NOTIFY_SCRIPT });
        }

        private async void Element_InvokeScriptEvent(object sender, InvokeScriptEventArgs e)
        {
            try
            {
                await Control.InvokeScriptAsync(e.ScriptName, new[] { e.Script });
            }
            catch (Exception ex)
            {
                // if javascript returned error 
                System.Diagnostics.Debug.Fail(ex.Message);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == nameof(Element.Uri))
                UriChanged();
        }

        private void UriChanged()
        {
            if (Element.Uri != null)
            {
                try
                {
                    // remove everything about the path of the LocalCache
                    var localCacheFolder = Xamarin.Essentials.FileSystem.CacheDirectory;
                    var path = Element.Uri.Substring(localCacheFolder.Length);
                    Uri url = Control.BuildLocalStreamUri("Presentation", "localcache\\" + path);
                    StreamUriWinRTResolver resolver = new StreamUriWinRTResolver();
                    Control.NavigateToLocalStreamUri(url, resolver);
                }
                catch
                {
                    // ignore exceptions
                }
            }
        }

        private void OnWebViewNavigationCompleted(WebView sender, WebViewNavigationCompletedEventArgs args)
        {
            if (args.IsSuccess)
            {
                EmbedJS();
                Element.WebViewPageLoaded(args.Uri.AbsoluteUri);
            }
        }

        public void OnWebViewScriptNotify(object sender, NotifyEventArgs e)
        {
            Element.WebViewScriptNotify(e.Value);
        }
    }

    /// <summary>
    /// https://stackoverflow.com/questions/18872269/script-notify-for-ms-appdata/18979635#18979635
    /// </summary>
    public sealed class StreamUriWinRTResolver : IUriToStreamResolver
    {
        public IAsyncOperation<IInputStream> UriToStreamAsync(Uri uri)
        {
            if (uri == null)
            {
                throw new Exception();
            }
            string path = uri.AbsolutePath;
            return GetContent(path).AsAsyncOperation();
        }

        private async Task<IInputStream> GetContent(string path)
        {
            Uri localUri = new Uri("ms-appdata://" + path);
            StorageFile f = await StorageFile.GetFileFromApplicationUriAsync(localUri);
            IRandomAccessStream stream = await f.OpenAsync(FileAccessMode.Read);
            return stream.GetInputStreamAt(0);
        }
    }
}
