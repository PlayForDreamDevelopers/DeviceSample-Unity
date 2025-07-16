using System.Runtime.InteropServices;

namespace YVR.Enterprise.Camera
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SixDofPoseData
    {
        public long timestamp;
        public double x, y, z;
        public double rw, rx, ry, rz;
        public uint confidence;
        public uint warning_flag;
        public double vx, vy, vz;
        public double ax, ay, az;
        public double wx, wy, wz;
        public double w_ax, w_ay, w_az;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
        public byte[] reserved;
        public override string ToString()
        {
            return $"Timestamp: {timestamp}\n" +
                   $"Position: (x:{x}, y:{y}, z:{z})\n" +
                   $"Rotation: (w:{rw}, x:{rx}, y:{ry}, z:{rz})\n" +
                   $"Confidence: {confidence}, Warning Flag: {warning_flag}\n" +
                   $"Velocity: (x:{vx}, y:{vy}, z:{vz})\n" +
                   $"Acceleration: (x:{ax}, y:{ay}, z:{az})\n" +
                   $"Angular Velocity: (x:{wx}, y:{wy}, z:{wz})\n" +
                   $"Angular Acceleration: (x:{w_ax}, y:{w_ay}, z:{w_az})";
        }
    }
}