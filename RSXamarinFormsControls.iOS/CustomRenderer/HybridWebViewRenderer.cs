using System;
using System.ComponentModel;
using Foundation;
using RSXamarinFormsControls.iOS.CustomRenderer;
using RSXamarinFormsControls.CustomControls;
using WebKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(HybridWebView), typeof(HybridWebViewRenderer))]
/// <summary>
/// See: https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/custom-renderer/hybridwebview
/// </summary>
namespace RSXamarinFormsControls.iOS.CustomRenderer
{
    public class HybridWebViewRenderer : ViewRenderer<HybridWebView, WKWebView>, IWKScriptMessageHandler, IWKNavigationDelegate
    {
        private WKUserContentController _UserController;

        protected override void OnElementChanged(ElementChangedEventArgs<HybridWebView> e)
        {
            base.OnElementChanged(e);

            // if disposing, NewElement is null. In that case just return
            if (e.NewElement == null)
                return;

            if (Control == null)
            {
                EmbedJS();
                var config = new WKWebViewConfiguration { UserContentController = _UserController };
                var webView = new WKWebView(Frame, config);
                webView.WeakNavigationDelegate = this;
                webView.TranslatesAutoresizingMaskIntoConstraints = false;
                SetNativeControl(webView);
            }

            if (e.OldElement != null)
            {
                _UserController.RemoveAllUserScripts();
                _UserController.RemoveScriptMessageHandler("invokeAction");
                Element.InvokeScript -= Element_InvokeScriptEvent;
            }

            if (e.NewElement != null)
            {
                Element.InvokeScript += Element_InvokeScriptEvent;
            }
        }

        private void EmbedJS()
        {
            const string JS_NOTIFY_SCRIPT =
                "function NotifyApp(data){window.webkit.messageHandlers.invokeAction.postMessage(data);}" +
                "window.external = { notify : function(data){NotifyApp(data);}};";

            _UserController = new WKUserContentController();
            var script = new WKUserScript(new NSString(JS_NOTIFY_SCRIPT), WKUserScriptInjectionTime.AtDocumentEnd, false);
            _UserController.AddUserScript(script);
            _UserController.AddScriptMessageHandler(this, "invokeAction");
        }

        private async void Element_InvokeScriptEvent(object sender, InvokeScriptEventArgs e)
        {
            await Control.EvaluateJavaScriptAsync(e.Script);
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
                    var url = new NSUrl(Element.Uri, false);
                    var readAccessUrl = new NSUrl(Element.BasePath, true);
                    Control.LoadFileUrl(url.StandardizedUrl, readAccessUrl.StandardizedUrl);
                }
                catch
                {
                    // ignore exceptions
                }

            }
        }

        [Export("webView:didFinishNavigation:")]
        public void DidFinishNavigation(WKWebView webView, WKNavigation navigation)
        {
            Element.WebViewPageLoaded(String.Empty);
        }

        public void DidReceiveScriptMessage(WKUserContentController userContentController, WKScriptMessage message)
        {
            Element.WebViewScriptNotify(message.Body.ToString());
        }
    }
}
