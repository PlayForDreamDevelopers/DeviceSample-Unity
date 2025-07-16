using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Internal;
using YVR.Core;

namespace YVR.Enterprise.LBE
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MarkerTrackingUpdateData
    {
        /// <summary>
        /// Marker ID
        /// </summary>
        public long markerId;

        [ExcludeFromDocs] public int markerType;

        /// <summary>
        /// The position of marker's four corners in world space
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = LBEPlugin.spaceUuidMaxSize)]
        public Vector3[] region;

        /// <summary>
        /// Marker's pose in world space
        /// </summary>
        public XRPose markerPose; // marker origin pose

        /// <summary>
        /// The confidence of marker tracking
        /// </summary>
        public float confidence;
    }
}