using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;

namespace YVR.Enterprise.Camera
{
    /// <summary>
    /// 将 NV21 数据格式（[Y][VU][VU]...）转换为 YUV420P（[Y][U][V]，即 planar 格式）的 NativeArray 版本
    /// 转换后所有分量拼接成一个 NativeArray，前 width*height 字节是Y，后依次是U和V平面
    /// </summary>
    [BurstCompile]
    public struct NV21ToYUV420Job : IJob
    {
        [ReadOnly] public NativeArray<byte> nv21Data;   // NV21 input
        [WriteOnly] public NativeArray<byte> yuv420Data; // 输出，长度 = width*height*3/2
        public int width;
        public int height;

        public void Execute()
        {
            int frameSize = width * height;
            int uvWidth = width / 2;
            int uvHeight = height / 2;
            int uStart = frameSize;
            int vStart = frameSize + uvWidth * uvHeight;

            // 1. 拷贝 Y 分量
            for (int i = 0; i < frameSize; i++)
            {
                yuv420Data[i] = nv21Data[i];
            }

            // 2. 拆分 VU 到 U、V 平面
            int uvStride = width; // NV21 的 UV 行跨度
            int uvStart = frameSize;
            for (int j = 0; j < uvHeight; j++)
            {
                for (int i = 0; i < uvWidth; i++)
                {
                    int uvIndex = uvStart + j * uvStride + i * 2;
                    byte v = nv21Data[uvIndex];
                    byte u = nv21Data[uvIndex + 1];
                    int uvPlaneIndex = j * uvWidth + i;
                    yuv420Data[uStart + uvPlaneIndex] = u;
                    yuv420Data[vStart + uvPlaneIndex] = v;
                }
            }
        }
    }
}