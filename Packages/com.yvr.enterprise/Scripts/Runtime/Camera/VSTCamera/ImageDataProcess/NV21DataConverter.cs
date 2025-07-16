using Unity.Collections;
using Unity.Jobs;

namespace YVR.Enterprise.Camera
{
    public class NV21DataConverter
    {
        // These data only used for internal calculation
        private NativeArray<byte> m_RGBDataArray = default;
        private NativeArray<byte> m_UndistortedRgbDataArray = default;
        private int m_Width, m_Height;

        public NativeArray<byte> normalizedRGBDataArray = default;

        public NV21DataConverter(int width, int height)
        {
            m_Width = width;
            m_Height = height;
            m_RGBDataArray = new NativeArray<byte>(width * height * 3, Allocator.Persistent);
            m_UndistortedRgbDataArray = new NativeArray<byte>(width * height * 3, Allocator.Persistent);

            normalizedRGBDataArray = new NativeArray<byte>(width * height * 3, Allocator.Persistent);
        }

        public JobHandle GetNormalizeRGBDataJobHandle(NativeArray<byte> nv21Data, UndistortionMap undistortionMap)
        {
            var nv21ToRGBJob = new NV21ToRGBJob
            {
                nv21Data = nv21Data,
                rgbData = m_RGBDataArray,
                width = m_Width,
                height = m_Height
            };

            JobHandle nv21ToRGBJobHandle = nv21ToRGBJob.Schedule(m_Width * m_Height, 256);

            var undistortionJob = new FisheyeUndistortionJob
            {
                srcRgb = m_RGBDataArray,
                dstRgb = m_UndistortedRgbDataArray,
                mapX = undistortionMap.xDataArray,
                mapY = undistortionMap.yDataArray,
                width = m_Width,
                height = m_Height,
            };

            JobHandle undistortionJobHandle = undistortionJob.Schedule(m_Width * m_Height, 256, nv21ToRGBJobHandle);

            var rotate90CCWJob = new RotateRGB90CWJob
            {
                srcRgb = m_UndistortedRgbDataArray,
                dstRgb = normalizedRGBDataArray,
                srcWidth = m_Width,
                srcHeight = m_Height
            };

            JobHandle rgbRotateCCW90JobHandle = rotate90CCWJob.Schedule(m_Width * m_Height, 256, undistortionJobHandle);
            return rgbRotateCCW90JobHandle;
        }


        ~NV21DataConverter()
        {
            m_RGBDataArray.Dispose();
            normalizedRGBDataArray.Dispose();
            m_UndistortedRgbDataArray.Dispose();
        }
    }
}