using System.ComponentModel;
using Android.Content;
using RSXamarinFormsControls.Droid.CustomRenderer;
using RSXamarinFormsControls.CustomControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(HybridWebView), typeof(HybridWebViewRenderer))]
/// <summary>
/// See: https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/custom-renderer/hybridwebview
/// </summary>
namespace RSXamarinFormsControls.Droid.CustomRenderer
{
    public class HybridWebViewRenderer : ViewRenderer<HybridWebView, Android.Webkit.WebView>
    {
        private Context _Context;

        public HybridWebViewRenderer(Context context) : base(context)
        {
            _Context = context;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<HybridWebView> e)
        {
            base.OnElementChanged(e);

            // if disposing, NewElement is null. In that case just return
            if (e.NewElement == null)
                return;

            if (Control == null)
            {
                var webView = new Android.Webkit.WebView(_Context);
                webView.Settings.JavaScriptEnabled = true;
                webView.Settings.DomStorageEnabled = true;
                webView.Settings.AllowFileAccess = true;
                webView.Settings.AllowContentAccess = true;
                webView.Settings.DatabaseEnabled = true;
                webView.Settings.JavaScriptCanOpenWindowsAutomatically = true;
                webView.Settings.LoadsImagesAutomatically = true;
                webView.SetBackgroundColor(Android.Graphics.Color.LightGray);
                EmbedJS(webView);

                SetNativeControl(webView);
            }

            if (e.OldElement != null)
            {
                Control.RemoveJavascriptInterface("jsBridge");
                Element.InvokeScript -= Element_InvokeScriptEvent;
            }

            if (e.NewElement != null)
            {
                Control.AddJavascriptInterface(new JSBridge(this), "jsBridge");
                Element.InvokeScript += Element_InvokeScriptEvent;
            }
        }

        private void EmbedJS(Android.Webkit.WebView webView)
        {
            const string JS_NOTIFY_SCRIPT =
                "function NotifyApp(data){jsBridge.invokeAction(data);}" +
                "window.external = { notify : function(data){NotifyApp(data);}};";

            webView.SetWebViewClient(new JavascriptWebViewClient(this, $"javascript: {JS_NOTIFY_SCRIPT}"));
        }

        private void Element_InvokeScriptEvent(object sender, InvokeScriptEventArgs e)
        {
            Control.EvaluateJavascript(e.Script, null);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == nameof(Element.Uri))
                UriChanged();
        }

        private void UriChanged()
        {
            Control.Layout(0, 0, 0, 0);
            Control.LayoutParameters.Width = 300;
            Control.LayoutParameters.Height = 300;
            Control.Invalidate();
            Control.RequestLayout();
            if (Element.Uri != null)
            {
                try
                {
                    Control.LoadUrl("file:///" + Element.Uri);
                }
                catch
                {
                    // ignore exceptions
                }
            }
        }

        public void OnPageFinished(Android.Webkit.WebView view, string url)
        {
            Element.WebViewPageLoaded(url);
        }

        public void InvokeAction(string data)
        {
            Element.WebViewScriptNotify(data);
        }
    }
}
