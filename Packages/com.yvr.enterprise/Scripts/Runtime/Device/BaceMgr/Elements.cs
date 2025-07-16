#if USE_ANDROID_DEVICE_CORE

using YVR.AndroidDevice.Core;
namespace YVR.Enterprise.Device
{
    public abstract class Elements: IAJCElements
    {
        public string className => "com.yvr.tobsettings.ToBServiceHelper";
        public const string init = "init";
        public const string getInstance = "getInstance";
    }
}
#endif