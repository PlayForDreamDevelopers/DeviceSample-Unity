#if USE_ANDROID_DEVICE_CORE
namespace YVR.Enterprise.Device
{
    public class DeviceInfoElements : Elements
    {
        public const string getDeviceSn = "getDeviceSn";
        public const string getDeviceModel = "getDeviceModel";
        public const string getOSVersion = "getSoftwareVersion";
        public const string isBtOn = "isBtOn";
        public const string getBTMac = "getBtMac";
        public const string getBtNameConnected = "getBtNameConnected";
        public const string isWifiOn = "isWifiOn";
        public const string getWifiMac = "getWifiMac";
        public const string isDeviceWorn = "isDeviceWorn";
        public const string getStorageInfo = "getStorageInfo";
        public const string getDeviceBattery = "getDeviceBattery";
        public const string isDeviceCharging = "isDeviceCharging";
        public const string getBatteryTemperature = "getBatteryTemperature";
        public const string getControllerBattery = "getControllerBattery";
        public const string isControllerCharging = "isControllerCharging";
    }
}
#endif