using Android.Webkit;

namespace RSXamarinFormsControls.Droid.CustomRenderer
{
    public class JavascriptWebViewClient : WebViewClient
    {
        private string _JavaScript;
        private HybridWebViewRenderer _Renderer;

        public JavascriptWebViewClient(HybridWebViewRenderer renderer, string javaScript)
        {
            _Renderer = renderer;
            _JavaScript = javaScript;
        }

        public override void OnPageFinished(WebView view, string url)
        {
            base.OnPageFinished(view, url);
            view.EvaluateJavascript(_JavaScript, null);
            _Renderer.OnPageFinished(view, url);
        }
    }
}
