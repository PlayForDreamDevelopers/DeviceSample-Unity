using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using YVR.Enterprise.Device;

public class SystemConfigControl : MonoBehaviour
{
    [Header("ScreenOffTimeOut")]
    public TMP_Text nowScreenOffTimeOutResult;
    public TMP_InputField setScreenOffTimeOut;
    public Button setScreenOffTimeOutApply;
    
    [Header("ScreenOffSleepTimeOut")]
    public TMP_Text nowScreenOffSleepTimeOutResult;
    public TMP_InputField setScreenOffSleepTimeOut;
    public Button setScreenOffSleepTimeOutApply;

    [Header("Brightness")] 
    public TMP_Text nowBrightnessResult;
    public Slider brightnessSlider;
    
    [Header("volume")] 
    public TMP_Text nowVolumeResult;
    public Slider volumeSlider;
    public TMP_Text deviceMaxVolume;
    
    [Header("EyeProtectionMode")]
    public Toggle eyeProtectionModeToggle;
    public TMP_Text nowEyeProtectionResult;
    
    [Header("HandTrackingStatus")]
    public Toggle handTrackingStatusToggle;
    public TMP_Text nowHandTrackingStatus;
    
    [Header("Recenter")]
    public Toggle recenterToggle;
    public TMP_Text nowRecenterIsOn;
    
    [Header("PassThoughtVisibility")]
    public Toggle passThoughtVisibilityToggle;
    
    [Header("ConnectWifiAp")]
    public TMP_InputField ssidInput;
    public TMP_InputField pwdInput;
    public TMP_Text whetherToCallResult;
    public TMP_Text connectionStatus;
    public Button connect; 
    
    [Header("WifiInfo")]
    public TMP_Text getWifiNameConnectedResult;
    public TMP_Text getWifiIPConnectedResult;
    
    [Header("SecurityAreaStatus")]
    public TMP_Text nowSecurityAreaStatus;
    public Button getSecurityAreaStatusButton ;
    public TMP_InputField setSecurityAreaStatusInput;
    public Button setSecurityAreaStatusButton;
    
    [Header("SecurityTracking")]
    public TMP_Text nowSecurityTrackingStatus;
    public Button getSecurityTrackingStatusButton;
    public TMP_InputField setSecurityTrackingStatusInput;
    public Button setSecurityTrackingStatusButton;
    
    [Header("UsbDebugMode")]
    public TMP_Text nowUsbDebugMode;
    public Toggle usbDebugModeToggle;
    
    [Header("SetBeEnable")]
    public Toggle setBtEnableToggle;
    
    [Header("createSecurityArea")]
    public Button createSecurityAreaButton;
    
    [Header("GestureCtrlHomeIcon")]
    public TMP_Text nowGestureCtrlHomeIcon;
    public Toggle GestureCtrlHomeIconToggle;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //part 1
        nowScreenOffTimeOutResult.text = SystemConfigurationMgr.instance.screenOffTimeOut.ToString();
        setScreenOffTimeOutApply.onClick.AddListener(ScreenOffTimeOutApply);
        
        nowScreenOffSleepTimeOutResult.text = SystemConfigurationMgr.instance.screenOffSleepTimeOut.ToString();
        setScreenOffSleepTimeOutApply.onClick.AddListener(ScreenOffSleepTimeOutApply);
        
        nowBrightnessResult.text = SystemConfigurationMgr.instance.brightness.ToString();
        brightnessSlider.value = SystemConfigurationMgr.instance.brightness;
        brightnessSlider.onValueChanged.AddListener(ChangeBrightness);

        volumeSlider.maxValue = SystemConfigurationMgr.instance.maxVolume;
        deviceMaxVolume.text = SystemConfigurationMgr.instance.maxVolume.ToString();
        volumeSlider.value = SystemConfigurationMgr.instance.volume;
        nowVolumeResult.text = SystemConfigurationMgr.instance.volume.ToString();
        volumeSlider.onValueChanged.AddListener(ChangeVolume);

        eyeProtectionModeToggle.isOn = SystemConfigurationMgr.instance.eyeProtectionMode;
        nowEyeProtectionResult.text = SystemConfigurationMgr.instance.eyeProtectionMode?"true":"false";
        eyeProtectionModeToggle.onValueChanged.AddListener(ChangeEyeProtectionMode);
        
        //part 2
        handTrackingStatusToggle.isOn = SystemConfigurationMgr.instance.handTrackingStatus;
        nowHandTrackingStatus.text = SystemConfigurationMgr.instance.handTrackingStatus?"true":"false";
        handTrackingStatusToggle.onValueChanged.AddListener(ChangeHandTrackingStatus);
        
        recenterToggle.isOn = SystemConfigurationMgr.instance.isRecenterOpen;
        nowRecenterIsOn.text = SystemConfigurationMgr.instance.isRecenterOpen?"true":"false";
        recenterToggle.onValueChanged.AddListener(SwitchRecenter);
        
        passThoughtVisibilityToggle.isOn = SystemConfigurationMgr.instance.passthroughVisibility;
        passThoughtVisibilityToggle.onValueChanged.AddListener(ChangePassThoughtVisibility);

        whetherToCallResult.text = "";
        connectionStatus.text = "";
        connect.onClick.AddListener(ConnectWifiAp);

        getWifiNameConnectedResult.text = SystemConfigurationMgr.instance.GetWifiNameConnected(WifiNameChanged);
        getWifiIPConnectedResult.text = SystemConfigurationMgr.instance.GetWifiIP(WifiIPChanged);
        
        //part 3
        getSecurityAreaStatusButton.onClick.AddListener(GetSecurityAreaStatus);
        setSecurityAreaStatusButton.onClick.AddListener(SetSecurityAreaStatus);
        
        getSecurityTrackingStatusButton.onClick.AddListener(GetSecurityTrackingStatus);
        setSecurityTrackingStatusButton.onClick.AddListener(SetSecurityTrackingStatus);
        
        //part 4
        nowUsbDebugMode.text = SystemConfigurationMgr.instance.usbDebugMode.ToString();
        usbDebugModeToggle.onValueChanged.AddListener(ChangeUsbDebugMode);
        
        setBtEnableToggle.onValueChanged.AddListener(ChangeBtEnable);
        
        createSecurityAreaButton.onClick.AddListener(CreateSecurityArea);

        nowGestureCtrlHomeIcon.text = SystemConfigurationMgr.instance.isShowGestureCtrlHomeIcon?"true":"false";
        GestureCtrlHomeIconToggle.onValueChanged.AddListener(ChangeGestureCtrlHomeIcon);
    }

    private void ChangeGestureCtrlHomeIcon(bool value)
    {
        SystemConfigurationMgr.instance.isShowGestureCtrlHomeIcon = value;
        nowGestureCtrlHomeIcon.text = SystemConfigurationMgr.instance.isShowGestureCtrlHomeIcon?"true":"false";
    }

    private void CreateSecurityArea()
    {
        SystemConfigurationMgr.instance.CreateSecurityArea();
    }

    private void ChangeBtEnable(bool value)
    {
        SystemConfigurationMgr.instance.SetBtEnabled(value);
    }

    private void ChangeUsbDebugMode(bool value)
    {
        SystemConfigurationMgr.instance.usbDebugMode = value;
        nowUsbDebugMode.text = SystemConfigurationMgr.instance.usbDebugMode.ToString();
    }

    private void SetSecurityTrackingStatus()
    {
        SystemConfigurationMgr.instance.securityTracking = int.Parse(setSecurityTrackingStatusInput.text);
        GetSecurityTrackingStatus();
    }

    private void GetSecurityTrackingStatus()
    {
        nowSecurityTrackingStatus.text = SystemConfigurationMgr.instance.securityTracking.ToString();
    }

    private void SetSecurityAreaStatus()
    {
        SystemConfigurationMgr.instance.securityAreaStatus = int.Parse(setSecurityAreaStatusInput.text);
        GetSecurityAreaStatus();
    }

    private void GetSecurityAreaStatus()
    {
        nowSecurityAreaStatus.text = SystemConfigurationMgr.instance.securityAreaStatus.ToString();
    }

    private void WifiIPChanged(string result)
    {
        getWifiIPConnectedResult.text = result;
    }

    private void WifiNameChanged(string result)
    {
        getWifiNameConnectedResult.text = result;
    }

    private void ConnectWifiAp()
    {
        whetherToCallResult.text = SystemConfigurationMgr.instance.ConnectWifiAp(ssidInput.text, pwdInput.text,ConnectWifiApCallBack)?"true":"false";
    }

    private void ConnectWifiApCallBack(string result)
    {
        connectionStatus.text = result;
    }
    
    private void ChangePassThoughtVisibility(bool value)
    {
        SystemConfigurationMgr.instance.passthroughVisibility = value;
    }

    private void SwitchRecenter(bool value)
    {
        SystemConfigurationMgr.instance.SwitchRecenter(value);
        nowRecenterIsOn.text = SystemConfigurationMgr.instance.isRecenterOpen?"true":"false";
    }


    private void ChangeHandTrackingStatus(bool value)
    {
        SystemConfigurationMgr.instance.handTrackingStatus = value;
        nowHandTrackingStatus.text = SystemConfigurationMgr.instance.handTrackingStatus?"true":"false";
    }

    private void ChangeEyeProtectionMode(bool value)
    {
        SystemConfigurationMgr.instance.eyeProtectionMode = value;
        nowEyeProtectionResult.text = SystemConfigurationMgr.instance.eyeProtectionMode?"true":"false";
    }

    private void ChangeVolume(float value)
    {
        SystemConfigurationMgr.instance.volume = (int)value;
        nowVolumeResult.text = SystemConfigurationMgr.instance.volume.ToString();
    }

    public void ScreenOffTimeOutApply()
    {
        SystemConfigurationMgr.instance.screenOffTimeOut = int.Parse(setScreenOffTimeOut.text);
        nowScreenOffTimeOutResult.text = SystemConfigurationMgr.instance.screenOffTimeOut.ToString();
    }

    public void ScreenOffSleepTimeOutApply()
    {
        SystemConfigurationMgr.instance.screenOffSleepTimeOut = int.Parse(setScreenOffSleepTimeOut.text);
        nowScreenOffSleepTimeOutResult.text = SystemConfigurationMgr.instance.screenOffSleepTimeOut.ToString();
    }

    public void ChangeBrightness(float value)
    {
        SystemConfigurationMgr.instance.brightness = (int)value;
        nowBrightnessResult.text = SystemConfigurationMgr.instance.brightness.ToString();
    }
    
}
