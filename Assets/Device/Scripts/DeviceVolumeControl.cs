using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YVR.Core;

namespace YVR.Enterprise.Device.Sample
{
    public class DeviceVolumeControl : MonoBehaviour
    {
        public TextMeshProUGUI currentVolumeText = null;
        public TextMeshProUGUI maxVolumeText = null;
        public Slider volumeControl = null;
        public Toggle volumeRestrictionToggle = null;
        public GameObject volumeRestrictionTip = null;

        private void Start()
        {
            YVRManager.instance.hmdManager.SetPassthrough(true);

            volumeControl.value = DeviceMgr.instance.volume / (float) DeviceMgr.instance.maxVolume;
            volumeControl.onValueChanged.AddListener(value =>
            {
                int toSetVolume = (int) (DeviceMgr.instance.maxVolume * value);
                if (toSetVolume == DeviceMgr.instance.volume) return;

                DeviceMgr.instance.volume = toSetVolume;
            });

            volumeRestrictionToggle.isOn = DeviceMgr.instance.volumeAdjustmentRestricted;
            volumeRestrictionToggle.onValueChanged.AddListener(value =>
            {
                DeviceMgr.instance.volumeAdjustmentRestricted = value;
            });
        }

        private void Update()
        {
            int currentVolume = DeviceMgr.instance.volume;
            int maxVolumeValue = DeviceMgr.instance.maxVolume;
            currentVolumeText.text = $"Current volume: <b> {currentVolume} <b>";
            maxVolumeText.text = $"Max volume: <b> {maxVolumeValue} <b>";

            volumeControl.value = currentVolume / (float) maxVolumeValue;
            volumeRestrictionToggle.isOn = DeviceMgr.instance.volumeAdjustmentRestricted;
            volumeRestrictionTip.SetActive(volumeRestrictionToggle.isOn);
        }
    }
}