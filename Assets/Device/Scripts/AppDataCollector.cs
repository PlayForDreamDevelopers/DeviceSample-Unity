using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YVR.Core;

namespace YVR.Enterprise.Device.Sample
{
    public class AppDataCollector : MonoBehaviour
    {
        public TMP_InputField startupAppIF;
        public Toggle appCloseAbilityToggle;
        public Toggle configurationPermissionToggle;

        private void Start()
        {
            YVRManager.instance.hmdManager.SetPassthrough(true);

            startupAppIF.onValueChanged.AddListener(t => { AppMgr.instance.startupApp = t; });
            appCloseAbilityToggle.onValueChanged.AddListener(t => { AppMgr.instance.startupAppClosable = t; });
            configurationPermissionToggle.onValueChanged.AddListener(t => { AppMgr.instance.configurationPermission = t; });
        }

        private void Update()
        {
            Refresh();
        }

        private void Refresh()
        {
            var startupApp = AppMgr.instance.startupApp;
            if (!startupAppIF.isFocused)
            {
                startupAppIF.text = startupApp;
            }

            appCloseAbilityToggle.isOn = AppMgr.instance.startupAppClosable;
            configurationPermissionToggle.isOn = AppMgr.instance.configurationPermission;
        }
    }
}