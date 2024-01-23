using MauiExample.CustomRender;
using MauiExample.Platforms.Windows.CustomRender;

[assembly: Dependency(typeof(BaseUrl))]
namespace MauiExample.Platforms.Windows.CustomRender
{
    public class BaseUrl : IBaseUrl
    {
        public string Get() => "ms-appx-web:///";
    }
}
