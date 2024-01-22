using Android.Content;
using Android.Views;
using Android.Webkit;
using MauiExample.CustomRender;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Controls.Platform;

[assembly: ExportRenderer(typeof(IWebViewCustom), typeof(MauiExample.Platforms.Android.CustomRender.WebViewCustom))]
namespace MauiExample.Platforms.Android.CustomRender
{
    [Obsolete]
    public class WebViewCustom : WebViewRenderer
    {

        public WebViewCustom(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Microsoft.Maui.Controls.WebView> e)
        {
            base.OnElementChanged(e);
            this.Control.Settings.JavaScriptEnabled = true;
            this.Control.Settings.UseWideViewPort = true;
            this.Control.Settings.LoadWithOverviewMode = true;
            this.Control.Settings.SaveFormData = true;
            this.Control.Settings.SetRenderPriority(WebSettings.RenderPriority.High);
            this.Control.SetLayerType(LayerType.Hardware, null);
            //Control.SetLayerType(LayerType.Software, null);
            this.Control.SetWebChromeClient(new MyWebClient());
        }

        public class MyWebClient : WebChromeClient
        {

        }
    }
}
