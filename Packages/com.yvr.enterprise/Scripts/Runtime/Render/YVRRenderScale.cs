using System.Runtime.InteropServices;

namespace YVR.Enterprise.Render
{
    [StructLayout(LayoutKind.Sequential)]
    public struct YVRRenderScale
    {
        [MarshalAs(UnmanagedType.I1)]
        public bool overrideResolution;
        [MarshalAs(UnmanagedType.I1)]
        public bool useQuadViews;
        public RenderScale renderScale;
        public float minRenderScale;
        public float maxRenderScale;
        public override string ToString()
        {
            return $"overrideResolution:{overrideResolution},useQuadViews:{useQuadViews},renderScale:{renderScale},minRenderScale:{minRenderScale},maxRenderScale:{maxRenderScale}";
        }
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct RenderScale
    {
        [FieldOffset(0)]
        public YVRRenderScaleNormal normal;
        [FieldOffset(0)]
        public YVRRenderScaleQuadViews quadViews;

        public override string ToString()
        {
            return $"normal:{normal},quadViews:{quadViews}";
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct YVRRenderScaleNormal
    {
        public float normalScale;
        public override string ToString()
        {
            return $"normalScale:{normalScale}";
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct YVRRenderScaleQuadViews
    {
        public float innerScale;
        public float outerScale;

        public override string ToString()
        {
            return $"innerScale:{innerScale},outerScale:{outerScale}";
        }
    }
}