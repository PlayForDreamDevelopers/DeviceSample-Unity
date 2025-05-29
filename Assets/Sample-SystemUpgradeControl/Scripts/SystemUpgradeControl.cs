using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YVR.Core;

namespace YVR.Enterprise.Device.Sample
{
    public class SystemUpgradeControl : MonoBehaviour
    {
        public TMP_Text isSystemUpgradeEnableResult;
        public Toggle setSystemUpgradeStateToggle;

        public TMP_Text isSystemAutoUpgradeEnableResult;
        public Toggle setSystemAutoUpgradeStateToggle;

        private void Start()
        {
            YVRManager.instance.hmdManager.SetPassthrough(true);
            isSystemUpgradeEnableResult.text
                = SystemUpgradeControlMgr.instance.isSystemUpgradeEnable ? "Enabled" : "Disabled";
            setSystemUpgradeStateToggle.onValueChanged.AddListener(SetSystemUpgradeState);

            isSystemAutoUpgradeEnableResult.text = SystemUpgradeControlMgr.instance.isSystemAutomaticUpgradeEnable
                ? "Enabled"
                : "Disabled";
            setSystemAutoUpgradeStateToggle.onValueChanged.AddListener(SetSystemAutomaticUpgradeState);
        }

        private void SetSystemUpgradeState(bool value)
        {
            SystemUpgradeControlMgr.instance.isSystemUpgradeEnable = value;
            isSystemUpgradeEnableResult.text
                = SystemUpgradeControlMgr.instance.isSystemUpgradeEnable ? "Enabled" : "Disabled";
        }

        private void SetSystemAutomaticUpgradeState(bool value)
        {
            SystemUpgradeControlMgr.instance.isSystemAutomaticUpgradeEnable = value;
            isSystemAutoUpgradeEnableResult.text = SystemUpgradeControlMgr.instance.isSystemAutomaticUpgradeEnable
                ? "Enabled"
                : "Disabled";
        }
    }
}