using System;
using UnityEngine;
using YVR.AndroidDevice.Core;
using YVR.AndroidDevice.Core.Utilities;

#if USE_ANDROID_DEVICE_CORE

namespace YVR.Enterprise.Device
{
    public class DeviceInfoMgr : BaseMgr<DeviceInfoMgr,DeviceInfoElements>
    {
        
        public string deviceSn => ajcBase.CallJNI<string>(DeviceInfoElements.getDeviceSn);

        public string deviceModel => ajcBase.CallJNI<string>(DeviceInfoElements.getDeviceModel);

        public string osVersion => ajcBase.CallJNI<string>(DeviceInfoElements.getOSVersion);

        public bool IsBtOn(Action<bool> callback = null)
        {
            return ajcBase.CallJNI<bool>(DeviceInfoElements.isBtOn,JavaObjectConverter.CreatConsumerProxy(callback));
        }

        public string btMac => ajcBase.CallJNI<string>(DeviceInfoElements.getBTMac);

        public string BTNameConnected(Action<string> callback = null)
        {
            return ajcBase.CallJNI<string>(DeviceInfoElements.getBtNameConnected,JavaObjectConverter.CreatConsumerProxy(callback));
        }

        public bool IsWifiOn(Action<bool> callback = null)
        {
            return ajcBase.CallJNI<bool>(DeviceInfoElements.isWifiOn,JavaObjectConverter.CreatConsumerProxy(callback));
        }
        
        public string wifiMac => ajcBase.CallJNI<string>(DeviceInfoElements.getWifiMac);

        public bool IsDeviceWorn(Action<bool> callback = null)
        {
            return ajcBase.CallJNI<bool>(DeviceInfoElements.isDeviceWorn,JavaObjectConverter.CreatConsumerProxy(callback));
        }
        
        public string storageInfo => ajcBase.CallJNI<string>(DeviceInfoElements.getStorageInfo);

        public int GetDeviceBattery(Action<int> callback = null)
        {
            return ajcBase.CallJNI<int>(DeviceInfoElements.getDeviceBattery,JavaObjectConverter.CreatConsumerProxy(callback));
        }

        public bool IsDeviceCharging(Action<bool> callback = null)
        {
            return ajcBase.CallJNI<bool>(DeviceInfoElements.isDeviceCharging,JavaObjectConverter.CreatConsumerProxy(callback));
        }
        
        public int batteryTemperature => ajcBase.CallJNI<int>(DeviceInfoElements.getBatteryTemperature);

        public string GetControllerBattery(Action<string> callback = null)
        {
            return ajcBase.CallJNI<string>(DeviceInfoElements.getControllerBattery,JavaObjectConverter.CreatConsumerProxy(callback));
        }
        

        public string IsControllerCharging(Action<string> callback = null)
        {
            return ajcBase.CallJNI<string>(DeviceInfoElements.isControllerCharging,JavaObjectConverter.CreatConsumerProxy(callback));
        }
    }
}
#endif