using TMPro;
using UnityEngine;
using YVR.Core;

namespace YVR.Enterprise.Device.Sample
{
    public class DeviceDataCollector : MonoBehaviour
    {
        public TextMeshProUGUI deviceModelText = null;
        public TextMeshProUGUI deviceSnText = null;
        public TextMeshProUGUI osVersionText = null;
        public TextMeshProUGUI wifiMacText = null;
        public TextMeshProUGUI btMacText = null;

        private void Start()
        {
            YVRManager.instance.hmdManager.SetPassthrough(true);

            deviceModelText.text = $"Device model: <b> {DeviceMgr.instance.deviceModel} <b>";
            deviceSnText.text = $"Device sn: <b> {DeviceMgr.instance.deviceSn} <b>";
            osVersionText.text = $"OS version: <b> {DeviceMgr.instance.osVersion} <b>";
            wifiMacText.text = $"Wifi mac: <b> {DeviceMgr.instance.wifiMac} <b>";
            btMacText.text = $"BT mac: <b> {DeviceMgr.instance.btMac} <b>";
        }
    }
}