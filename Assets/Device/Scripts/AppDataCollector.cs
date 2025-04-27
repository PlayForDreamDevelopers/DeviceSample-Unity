using UnityEngine;
using UnityEngine.UI;
using YVR.Core;

namespace YVR.Enterprise.Device.Sample
{
    public class AppDataCollector : MonoBehaviour
    {
        public Toggle startupAppToggle;
        public Toggle appCloseAbilityToggle;
        public Toggle configurationPermissionToggle;

        private void Start()
        {
            YVRManager.instance.hmdManager.SetPassthrough(true);

            startupAppToggle.onValueChanged.AddListener(t =>
            {
                Debug.Log($"AppDataCollector: startupAppToggle: {t}");
                AppMgr.instance.SetStartupApp("com.PFDM.DeviceSample", t);
            });

            appCloseAbilityToggle.onValueChanged.AddListener(t =>
            {
                if (t != AppMgr.instance.startupAppClosable)
                {
                    Debug.Log($"AppDataCollector: appCloseAbilityToggle: {t}");

                    AppMgr.instance.startupAppClosable = t;
                }
            });

            configurationPermissionToggle.onValueChanged.AddListener(t =>
            {
                if (t != AppMgr.instance.configurationPermission)
                {
                    Debug.Log($"AppDataCollector: configurationPermissionToggle: {t}");

                    AppMgr.instance.configurationPermission = t;
                }
            });
        }

        private void Update()
        {
            Refresh();
        }

        private void Refresh()
        {
            var startupApp = AppMgr.instance.startupApp;
            var appClosable = AppMgr.instance.startupAppClosable;
            var configurationPermission = AppMgr.instance.configurationPermission;

            var startupNotNull = !string.IsNullOrWhiteSpace(startupApp);
            appCloseAbilityToggle.interactable = startupNotNull;
            configurationPermissionToggle.interactable = startupNotNull;

            startupAppToggle.SetIsOnWithoutNotify(startupNotNull);
            appCloseAbilityToggle.SetIsOnWithoutNotify(appClosable);
            configurationPermissionToggle.SetIsOnWithoutNotify(configurationPermission);

            Debug.Log($"AppDataCollector: Refresh, startupApp: {startupApp}, appClosable: {appClosable}, configurationPermission: {configurationPermission}");
        }
    }
}