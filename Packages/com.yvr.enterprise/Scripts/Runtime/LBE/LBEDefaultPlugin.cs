using System;

namespace YVR.Enterprise.LBE
{
    public class LBEDefaultPlugin : LBEPlugin
    {
        public override float GetGroundDistance() { return 0; }
        public override void SetMarkerDetectionEnable(bool enable) { }

        public override void SetMarkerTrackingUpdateCallback(Action<MarkerTrackingUpdateData> callback) { }

        public override void SetRecenterEnable(bool enable) { }

        public override bool GetRecenterEnable() { return false; }
    }
}