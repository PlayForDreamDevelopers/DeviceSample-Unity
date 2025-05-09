using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YVR.Core;
using YVR.Enterprise.Device;
using YVR.Enterprise.Device.KioskModeSettingMgr;
using Task = System.Threading.Tasks.Task;

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
        configurationPermission.isOn = KioskModeSettingMgr.instance.configurationPermission;
        configurationPermission.onValueChanged.AddListener(ChangeConfigurationPermission);
    }

    private void GetStartUpApp()
    {
        UpdateInfo();
    }

    private  void ChangeConfigurationPermission(bool value)
    {
        KioskModeSettingMgr.instance.configurationPermission = value;
    }

    private  void ChangeAppCloseAbility(bool value)
    {
        KioskModeSettingMgr.instance.appCloseAbility = value;
    }

    private  void SetStartUpApp()
    {
        KioskModeSettingMgr.instance.SetKioskModeSettingEnable(setStartUpAppInput.text,setStartUpAppToggle.isOn);
        UpdateInfo();
    }

    public void UpdateInfo()
    {
        getStartUpAppResult.text = KioskModeSettingMgr.instance.startupApp;
        appCloseAbility.isOn = KioskModeSettingMgr.instance.appCloseAbility;
    }
}
