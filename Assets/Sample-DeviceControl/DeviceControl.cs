using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YVR.Core;
using YVR.Enterprise.Device;

public class DeviceControl : MonoBehaviour
{
    public Button shutdown;
    public Button reboot;
    public Button setScreenOff;
    public Button setScreenOn;
    // Start is called before the first frame update
    void Start()
    {
        YVRManager.instance.hmdManager.SetPassthrough(true);
        shutdown.onClick.AddListener(() =>
        {
            DeviceControlMgr.instance.Shutdown();
        });
        reboot.onClick.AddListener(() =>
        {
            DeviceControlMgr.instance.Reboot();
        });
        setScreenOff.onClick.AddListener(() =>
        {
            DeviceControlMgr.instance.SetScreenOff();
        });
        setScreenOn.onClick.AddListener(() =>
        {
            DeviceControlMgr.instance.SetScreenOn();
        });
    }
}
