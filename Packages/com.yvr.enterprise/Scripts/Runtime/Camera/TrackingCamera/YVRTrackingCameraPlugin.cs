using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using AOT;

namespace YVR.Enterprise.Camera
{
    public static class YVRTrackingCameraPlugin
    {
        [DllImport("enterprisePlugin")]
        private static extern void YVROpenTrackingCamera(TrackingCameraType type);

        [DllImport("enterprisePlugin")]
        private static extern void YVRCloseTrackingCamera(TrackingCameraType type);

        [DllImport("enterprisePlugin")]
        private static extern void YVRSubscribeFrame(TrackingCameraType type, Action<IntPtr, IntPtr> callback,
                                                     IntPtr userData);

        [DllImport("enterprisePlugin")]
        private static extern void YVRUnsubscribeFrame(TrackingCameraType type);

        [DllImport("enterprisePlugin")]
        private static extern void YVRAcquireTrackingCameraFrame(TrackingCameraType type,
                                                                 ref CameraFrameItemData frameData);

        [DllImport("enterprisePlugin")]
        private static extern void YVRSetTrackingCameraFrequency(TrackingCameraType type, int frequency);

        private static Dictionary<TrackingCameraType, IntPtr> s_TrackingType2Ptr = new();
        private static Dictionary<TrackingCameraType, Action<CameraFrameItemData>> s_TypePtrToCallback = new();

        public static void OpenTrackingCamera(TrackingCameraType type) { YVROpenTrackingCamera(type); }

        public static void CloseTrackingCamera(TrackingCameraType type) { YVRCloseTrackingCamera(type); }

        public static void SubscribeFrame(TrackingCameraType type, Action<CameraFrameItemData> callback)
        {
            if (!s_TrackingType2Ptr.ContainsKey(type))
                s_TrackingType2Ptr[type] = GCHandle.ToIntPtr(GCHandle.Alloc(type, GCHandleType.Pinned));

            s_TypePtrToCallback[type] = callback;

            YVRSubscribeFrame(type, FrameCallback, s_TrackingType2Ptr[type]);
        }

        public static void UnsubscribeFrame(TrackingCameraType type)
        {
            if (!s_TrackingType2Ptr.ContainsKey(type)) return;

            YVRUnsubscribeFrame(type);
            s_TrackingType2Ptr.Remove(type);
            s_TypePtrToCallback.Remove(type);
        }

        [MonoPInvokeCallback(typeof(Action<IntPtr, IntPtr>))]
        private static void FrameCallback(IntPtr frame, IntPtr userData)
        {
            var cameraFrameData = Marshal.PtrToStructure<CameraFrameItemData>(frame);
            var type = (TrackingCameraType) ((GCHandle) userData).Target;

            s_TypePtrToCallback[type]?.Invoke(cameraFrameData);
        }

        public static void AcquireTrackingCameraFrame(TrackingCameraType type,
                                                      ref CameraFrameItemData frameItemData)
        {
            YVRAcquireTrackingCameraFrame(type, ref frameItemData);
        }

        public static void SetTrackingCameraFrequency(TrackingCameraType type, int frequency)
        {
            YVRSetTrackingCameraFrequency(type, frequency);
        }
    }
}