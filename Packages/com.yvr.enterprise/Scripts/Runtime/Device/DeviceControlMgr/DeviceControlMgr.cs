#if USE_ANDROID_DEVICE_CORE

namespace YVR.Enterprise.Device
{
    public class DeviceControlMgr : BaseMgr<DeviceControlMgr, DeviceControlElements>
    {
        public void Shutdown() { ajcBase.CallJNI(DeviceControlElements.shutdown); }
        public void Reboot() { ajcBase.CallJNI(DeviceControlElements.reboot); }
        public void SetScreenOff() { ajcBase.CallJNI(DeviceControlElements.setScreenOff); }
        public void SetScreenOn() { ajcBase.CallJNI(DeviceControlElements.setScreenOn); }
    }
}
#endif