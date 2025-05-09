using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YVR.Core;

namespace YVR.Enterprise.Device.Sample
{
    public class DeviceBrightnessControl : MonoBehaviour
    {
        public TextMeshProUGUI currentBrightnessText = null;
        public TextMeshProUGUI maxBrightnessText = null;
        public Slider BrightnessControl = null;
        public Toggle BrightnessRestrictionToggle = null;
        public GameObject BrightnessRestrictionTip = null;

        private void Start()
        {
            YVRManager.instance.hmdManager.SetPassthrough(true);

            BrightnessControl.value = SystemConfigurationMgr.instance.brightness / (float) 255;
            BrightnessControl.onValueChanged.AddListener(value =>
            {
                int toSetBrightness = (int) (255 * value);
                if (toSetBrightness == SystemConfigurationMgr.instance.brightness) return;

                SystemConfigurationMgr.instance.brightness = toSetBrightness;
            });

            BrightnessRestrictionToggle.isOn = DeviceMgr.instance.brightnessAdjustmentRestricted;
            BrightnessRestrictionToggle.onValueChanged.AddListener(value =>
            {
                DeviceMgr.instance.brightnessAdjustmentRestricted = value;
            });
        }

        private void Update()
        {
            int currentBrightness = SystemConfigurationMgr.instance.brightness;
            int maxBrightnessValue = 255;
            currentBrightnessText.text = $"Current Brightness: <b> {currentBrightness} <b>";
            maxBrightnessText.text = $"Max Brightness: <b> {maxBrightnessValue} <b>";

            BrightnessControl.value = currentBrightness / (float) maxBrightnessValue;
            BrightnessRestrictionToggle.isOn = DeviceMgr.instance.brightnessAdjustmentRestricted;
            BrightnessRestrictionTip.SetActive(BrightnessRestrictionToggle.isOn);
        }
    }
}