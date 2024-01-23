using Foundation;
using MauiExample.CustomRender;

[assembly: Dependency(typeof(MauiExample.Platforms.iOS.CustomRender.BaseUrl))]
namespace MauiExample.Platforms.iOS.CustomRender
{
    public class BaseUrl : IBaseUrl
    {
        public string Get() => NSBundle.MainBundle.BundlePath;

    }
}
