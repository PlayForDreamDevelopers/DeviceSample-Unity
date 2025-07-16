using System;

namespace YVR.Enterprise.Device
{
    public class LargeSpatialMgr : BaseMgr<LargeSpatialMgr, LargeSpatialElements>
    {
        public void DeviceReboot() => ajcBase.CallJNI(LargeSpatialElements.reboot);

        public string GetCurrentMapName() => ajcBase.CallJNI<string>(LargeSpatialElements.getMapNameInEffect);

        public bool GetLargeSpatialStatus(int ext = 0) =>
            ajcBase.CallJNI<string>(LargeSpatialElements.getLargeSpaceStatus, ext) == "1";

        public void SwitchLargeSpaceScene(bool open, Action<bool> action, int ext = 0) =>
            ajcBase.CallJNI(LargeSpatialElements.switchLargeSpaceScene, open, new LargeSpaceProxy(action), ext);
    }
}