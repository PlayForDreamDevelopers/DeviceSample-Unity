using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YVR.Core;
using YVR.Enterprise.Device;

public class ScreenReCordingControl : MonoBehaviour
{ 
    public Button startRecordingButton;
    public Button stopRecordingButton;
    void Start()
    {
        YVRManager.instance.hmdManager.SetPassthrough(true);
        startRecordingButton.onClick.AddListener(() =>
        {
            ScreenRecordingMgr.instance.StartRecordScreen();
        });
        stopRecordingButton.onClick.AddListener(() =>
        {
            ScreenRecordingMgr.instance.StopRecordScreen();
        });
    }
}
