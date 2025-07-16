using System;

namespace YVR.Enterprise.Device
{
    public class ControllerButtonMgr:BaseMgr<ControllerButtonMgr,ControllerButtonElements>
    {
        public void SetControllerButtons(ControllerButtonMask mask,bool forbidden)
        {
            ajcBase.CallJNI(ControllerButtonElements.setControllerButtons,(int)mask,forbidden);
        }

        public bool GetControllerButtonEnableState(ControllerButtonMask mask)
        {
            return ajcBase.CallJNI<bool>(ControllerButtonElements.getControllerButtonEnableState,(int)mask);
        }
        
        public void RemoveTrackingKeyEventCallback()
        {
            ajcBase.CallJNI(ControllerButtonElements.removeTrackingKeyEventCallback);
        }
    }
}