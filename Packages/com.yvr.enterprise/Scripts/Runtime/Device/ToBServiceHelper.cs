#if USE_ANDROID_DEVICE_CORE
using UnityEngine;
using YVR.AndroidDevice.Core;
namespace YVR.Enterprise.Device
{
    public class ToBServiceHelper
    {
        public static AJCBase ajcBase {set;get;}
        private static AJCBase s_ToBServiceClassInstance = null;
        
        public static void Init(AJCBase toBServiceClassInstance)
        {
            if (ajcBase == null)
            {
                s_ToBServiceClassInstance = toBServiceClassInstance;
                AndroidJavaObject playerActivity = AndroidUtils.unityPlayerActivity;
                s_ToBServiceClassInstance.CallJNIStatic(Elements.init, playerActivity);
                var helperInstance = s_ToBServiceClassInstance.CallJNIStatic<AndroidJavaObject>(Elements.getInstance);
                // The instance is the real android object for further use, so we create a new ajcBase with it.
                ajcBase = new AJCInvoker(helperInstance);
            }
        }
        
    }
}
#endif