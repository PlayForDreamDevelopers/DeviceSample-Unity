#if USE_ANDROID_DEVICE_CORE
namespace YVR.Enterprise.Device
{
    public class AppElements : Elements
    {
        public const string getAllPackages = "getAllPackages";
        public const string getAppList = "getAppList";
        public const string setBootAutoStart = "setBootAutoStart";
        public const string getBootAutoStart = "getBootAutoStart";
        public const string startActivity = "startActivity";
        public const string stopApp = "stopApp";
        public const string stopApps = "stopApps";
        public const string setAppKeepAlive = "setAppKeepAlive";
        public const string isAppKeepAlive = "isAppKeepAlive";
        public const string silentInstall = "silentInstall";
        public const string silentUnInstall = "silentUnInstall";
        public const string getRunningThirdPartyAppPackageName = "getRunningThirdPartyAppPackageName";
        public const string getTopRunningAppForMainDisplay = "getTopRunningAppForMainDisplay";
        public const string getTopRunningApp = "getTopRunningApp";
        public const string startWifiUI = "startWifiUI";
        public const string startBtUI = "startBtUI";
       
        public const string setStartupApp = "setStartupApp";
        public const string getStartupApp = "getStartupApp";
        public const string setAppCloseAbility = "setAppCloseAbility";
        public const string getAppCloseAbility = "getAppCloseAbility";
        public const string setConfigurationPermission = "setConfigurationPermission";
        public const string getConfigurationPermission = "getConfigurationPermission";
    }
}
#endif