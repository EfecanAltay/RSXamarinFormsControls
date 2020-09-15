using System;
using Android.Webkit;
using RSXamarinFormsControls.Droid.CustomRenderer;
using Java.Interop;

public class JSBridge : Java.Lang.Object
{
    private readonly WeakReference<HybridWebViewRenderer> weakHybridWebViewRenderer;

    public JSBridge(HybridWebViewRenderer hybridWebViewRenderer)
    {
        weakHybridWebViewRenderer = new WeakReference<HybridWebViewRenderer>(hybridWebViewRenderer);
    }

    [JavascriptInterface]
    [Export("invokeAction")]
    public void InvokeAction(string data)
    {
        if (weakHybridWebViewRenderer != null && weakHybridWebViewRenderer.TryGetTarget(out var hybridWebViewRenderer))
        {
            hybridWebViewRenderer.InvokeAction(data);
        }
    }
}
