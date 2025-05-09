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

            deviceModelText.text = $"Device model: <b> {DeviceInfoMgr.instance.deviceModel} <b>";
            deviceSnText.text = $"Device sn: <b> {DeviceInfoMgr.instance.deviceSn} <b>";
            osVersionText.text = $"OS version: <b> {DeviceInfoMgr.instance.osVersion} <b>";
            wifiMacText.text = $"Wifi mac: <b> {DeviceInfoMgr.instance.wifiMac} <b>";
            btMacText.text = $"BT mac: <b> {DeviceInfoMgr.instance.btMac} <b>";
        }
    }
}