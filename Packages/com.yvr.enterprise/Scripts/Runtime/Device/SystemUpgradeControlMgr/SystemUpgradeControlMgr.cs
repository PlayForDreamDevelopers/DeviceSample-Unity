namespace YVR.Enterprise.Device
{
    public class SystemUpgradeControlMgr : BaseMgr<SystemUpgradeControlMgr, SystemUpgradeControlElements>
    {
        public bool isSystemUpgradeEnable
        {
            get => ajcBase.CallJNI<bool>(SystemUpgradeControlElements.isSystemUpgradeEnable);
            set => ajcBase.CallJNI(SystemUpgradeControlElements.setSystemUpgradeState, value);
        }

        public bool isSystemAutomaticUpgradeEnable
        {
            get => ajcBase.CallJNI<bool>(SystemUpgradeControlElements.isSystemAutomaticUpgradeEnable);
            set => ajcBase.CallJNI(SystemUpgradeControlElements.setSystemAutomaticUpgradeState, value);
        }
    }
}