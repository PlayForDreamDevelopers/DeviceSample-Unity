using System.Runtime.InteropServices;

namespace YVR.Enterprise.Camera
{
    [StructLayout(LayoutKind.Sequential)]
    public struct VSTCameraFrameData
    {
        public CameraFrameItemData cameraFrameItem;
        public SixDofPoseData sixDofPose;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] reserved;

        public override string ToString()
        {
            return $"Camera Frame Item:\n{cameraFrameItem}\n" +
                   $"Six Dof Pose:\n{sixDofPose}";
        }
    }
}