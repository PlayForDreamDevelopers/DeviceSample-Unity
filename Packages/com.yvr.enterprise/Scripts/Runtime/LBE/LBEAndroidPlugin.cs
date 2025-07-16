using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using AOT;
using UnityEngine;
using UnityEngine.XR;
using YVR.Core;

// ReSharper disable ClassNeverInstantiated.Global

namespace YVR.Enterprise.LBE
{
    public class LBEAndroidPlugin : LBEPlugin
    {
        [DllImport("yvrplugin")]
        private static extern float YVRSetMarkerTrackingUpdateCallback(Action<MarkerTrackingUpdateData> callback);

        [DllImport("yvrplugin")]
        private static extern float YVRSetRecenterEnable(bool enable);

        [DllImport("yvrplugin")]
        private static extern bool YVRGetRecenterEnable();

        [DllImport("yvrplugin")]
        private static extern float YVRSetMarkerDetectionEnable(bool enable);

        [DllImport("yvrplugin")]
        private static extern float YVRGetBoundaryDistance();

        public LBEAndroidPlugin() { YVRSetMarkerTrackingUpdateCallback(MarkerTrackingUpdateDataCallback); }

        public static Action<MarkerTrackingUpdateData> trackingUpdateAction;

        private static TrackingOriginModeFlags? s_TrackingOriginMode = null;

        public static TrackingOriginModeFlags trackingOriginMode
        {
            get
            {
                if (s_TrackingOriginMode != null) return s_TrackingOriginMode.Value;

                var inputSubsystems = new List<XRInputSubsystem>();
                SubsystemManager.GetInstances(inputSubsystems);
                if (inputSubsystems.Count == 0) return TrackingOriginModeFlags.Unknown;
                s_TrackingOriginMode = inputSubsystems[0].GetTrackingOriginMode();
                return s_TrackingOriginMode.Value;
            }
        }

        [MonoPInvokeCallback(typeof(Action<MarkerTrackingUpdateData>))]
        private static void MarkerTrackingUpdateDataCallback(MarkerTrackingUpdateData markerTrackingUpdateData)
        {
            Vector3 position = markerTrackingUpdateData.markerPose.position;
            position.y -= trackingOriginMode == TrackingOriginModeFlags.Floor ? YVRGetBoundaryDistance() : 0;
            
            markerTrackingUpdateData.markerPose.position = position;
            trackingUpdateAction?.Invoke(markerTrackingUpdateData);
        }

        public override void SetMarkerTrackingUpdateCallback(Action<MarkerTrackingUpdateData> callback)
        {
            trackingUpdateAction += callback;
        }

        public override float GetGroundDistance() { return YVRGetBoundaryDistance(); }

        public override void SetMarkerDetectionEnable(bool enable) { YVRSetMarkerDetectionEnable(enable); }

        public override void SetRecenterEnable(bool enable) { YVRSetRecenterEnable(enable); }

        public override bool GetRecenterEnable() { return YVRGetRecenterEnable(); }
    }
}