using System;
using UnityEngine;
using UnityEngine.UI;
using YVR.Enterprise.Device;

namespace YVR.Enterprise.Device.Sample
{
    [Serializable]
    public class ControlKey
    {
        public Color m_EnableColor = Color.white; 
        public Color m_DisableColor = Color.gray;
        public ControllerButtonMask mask;
        public Button keyControlButton;
        [HideInInspector]public bool enabled;
    
        public void ChangeColor()
        {
            keyControlButton.image.color = enabled? m_EnableColor:m_DisableColor;
        }
    }   
}
