using Foundation;

namespace MauiExample.CustomRender
{
    public partial class BaseUrl
    {
        public partial string Get() => NSBundle.MainBundle.BundlePath;

    }
}
