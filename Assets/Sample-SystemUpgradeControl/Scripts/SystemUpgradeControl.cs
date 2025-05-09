using System;
using System.Collections;
using System.Collections.Generic;
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

        private void Start()
        {
            YVRManager.instance.hmdManager.SetPassthrough(true);
            isSystemUpgradeEnableResult.text = SystemUpgradeControlMgr.instance.isSystemUpgradeEnable ? "Enabled" : "Disabled";
            setSystemUpgradeStateToggle.onValueChanged.AddListener(SetSystemUpgradeState);
        }

        private void SetSystemUpgradeState(bool value)
        {
            SystemUpgradeControlMgr.instance.isSystemUpgradeEnable = value;
            isSystemUpgradeEnableResult.text = SystemUpgradeControlMgr.instance.isSystemUpgradeEnable ? "Enabled" : "Disabled";
        }
    }
}


