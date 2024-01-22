using MauiExample.CustomRender;

[assembly: Dependency(typeof(MauiExample.Platforms.Android.CustomRender.BaseUrl))]
namespace MauiExample.Platforms.Android.CustomRender
{
    public class BaseUrl : IBaseUrl
    {
        public string Get() => "file:///android_asset/";
    }
}
