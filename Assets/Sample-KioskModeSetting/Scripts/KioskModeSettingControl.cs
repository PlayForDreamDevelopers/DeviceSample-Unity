using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YVR.Core;

namespace YVR.Enterprise.Device.Sample
{
    public class KioskModeSettingControl : MonoBehaviour
    {
        public TMP_InputField setStartUpAppInput;
        public Toggle setStartUpAppToggle;
        public Button setStartUpAppButton;
        public Button getStartUpAppButton;
        public TMP_Text getStartUpAppResult;
        public Toggle appCloseAbility;
        public Toggle configurationPermission;
    
        public void Start()
        {
            YVRManager.instance.hmdManager.SetPassthrough(true);
            setStartUpAppButton.onClick.AddListener(SetStartUpApp);
            getStartUpAppButton.onClick.AddListener(GetStartUpApp);
            UpdateInfo();
            appCloseAbility.onValueChanged.AddListener(ChangeAppCloseAbility);
            configurationPermission.isOn = AppMgr.instance.configurationPermission;
            configurationPermission.onValueChanged.AddListener(ChangeConfigurationPermission);
        }
    
        private void GetStartUpApp()
        {
            UpdateInfo();
        }
    
        private  void ChangeConfigurationPermission(bool value)
        {
            AppMgr.instance.configurationPermission = value;
        }
    
        private  void ChangeAppCloseAbility(bool value)
        {
            AppMgr.instance.appCloseAbility = value;
        }
    
        private  void SetStartUpApp()
        {
            AppMgr.instance.SetStartupApp(setStartUpAppInput.text,setStartUpAppToggle.isOn);
            UpdateInfo();
        }
    
        public void UpdateInfo()
        {
            getStartUpAppResult.text = AppMgr.instance.startupApp;
            appCloseAbility.isOn = AppMgr.instance.appCloseAbility;
        }
    }
}