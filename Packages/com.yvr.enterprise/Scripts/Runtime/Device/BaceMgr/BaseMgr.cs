#if USE_ANDROID_DEVICE_CORE
using UnityEngine;
using YVR.AndroidDevice.Core;

namespace YVR.Enterprise.Device
{
    public class BaseMgr<T, TElement> : AJCMgrSingleton<T, AJCMocker, TElement> 
        where T : AJCMgrSingleton<T, AJCMocker, TElement>, new() 
        where TElement : Elements, new()
    {
        protected override void OnInit()
        {
            base.OnInit();
            ToBServiceHelper.Init(ajcBase);
            ajcBase = ToBServiceHelper.ajcBase;
        }
    }
}
#endif