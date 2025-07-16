using YVR.AndroidDevice.Core.Utilities;

namespace YVR.Enterprise.Device
{
    public class ScreenRecordingMgr:BaseMgr<ScreenRecordingMgr,ScreenRecordingElements>
    {
        public void StartRecordScreen()
        {
            ajcBase.CallJNI(ScreenRecordingElements.startRecordScreen);
        }

        public void StopRecordScreen()
        {
            ajcBase.CallJNI(ScreenRecordingElements.stopRecordScreen);
        }
    }
}