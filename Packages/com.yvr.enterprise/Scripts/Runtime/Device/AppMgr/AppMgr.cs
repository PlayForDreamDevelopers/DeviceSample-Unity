using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using YVR.AndroidDevice.Core.Utilities;

#if USE_ANDROID_DEVICE_CORE

namespace YVR.Enterprise.Device
{
    public class AppMgr : BaseMgr<AppMgr, AppElements>
    {
        public List<string> allPackages =>
            JavaObjectConverter.JavaListToCSharpList(ajcBase.CallJNI<AndroidJavaObject>(AppElements.getAllPackages));

        public List<string> appList =>
            JavaObjectConverter.JavaListToCSharpList(ajcBase.CallJNI<AndroidJavaObject>(AppElements.getAppList));

        public void SetStartupApp(string pkgName, bool enable)
        {
            ajcBase.CallJNI(AppElements.setStartupApp, pkgName, enable);
        }

        public string startupApp => ajcBase.CallJNI<string>(AppElements.getStartupApp);

        public bool appCloseAbility
        {
            set => ajcBase.CallJNI(AppElements.setAppCloseAbility, value);
            get => ajcBase.CallJNI<bool>(AppElements.getAppCloseAbility);
        }

        public bool configurationPermission
        {
            set => ajcBase.CallJNI(AppElements.setConfigurationPermission, value);
            get => ajcBase.CallJNI<bool>(AppElements.getConfigurationPermission);
        }

        public void SetBootAutoStart(string packageName) { ajcBase.CallJNI(AppElements.setBootAutoStart, packageName); }

        public string[] bootAutoStart => ajcBase.CallJNI<string[]>(AppElements.getBootAutoStart);

        public void StartActivity(string pkgName, string className)
        {
            ajcBase.CallJNI(AppElements.startActivity, pkgName, className);
        }

        public void StopApp(string packageName) { ajcBase.CallJNI(AppElements.stopApp, packageName); }

        public void StopApps(object[] pkgList) { ajcBase.CallJNI(AppElements.stopApps, pkgList); }

        public void SetAppKeepAlive(string appPackageName, bool keepAlive)
        {
            ajcBase.CallJNI(AppElements.setAppKeepAlive, appPackageName, keepAlive);
        }

        public bool IsAppKeepAlive(string appPackageName)
        {
            return ajcBase.CallJNI<bool>(AppElements.isAppKeepAlive, appPackageName);
        }

        public void SilentInstall(string apkPath, Action<string> callback = null)
        {
            ajcBase.CallJNI(AppElements.silentInstall, apkPath, JavaObjectConverter.CreatConsumerProxy(callback));
        }

        public void SilentUnInstall(string pkg, Action<string> callback = null)
        {
            ajcBase.CallJNI(AppElements.silentUnInstall, pkg, JavaObjectConverter.CreatConsumerProxy(callback));
        }

        public List<string> runningThirdPartyAppPackageName =>
            JavaObjectConverter.JavaListToCSharpList(ajcBase.CallJNI<AndroidJavaObject>(AppElements
                                                        .getRunningThirdPartyAppPackageName));

        public string topRunningAppForMainDisplay =>
            ajcBase.CallJNI<string>(AppElements.getTopRunningAppForMainDisplay);

        public string topRunningApp => ajcBase.CallJNI<string>(AppElements.getTopRunningApp);

        public void StartWifiUI() { ajcBase.CallJNI(AppElements.startWifiUI); }
        public void StartBtUI() { ajcBase.CallJNI(AppElements.startBtUI); }
    }
}
#endif