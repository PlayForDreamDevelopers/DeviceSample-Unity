using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace YVR.Enterprise.Render
{
    public class YVRRenderMgr
    {
        [DllImport("yvrplugin")]
        private static extern void YVRGetRenderScale(string packageName, ref YVRRenderScaleBuffers renderScaleBuffers);

        [DllImport("yvrplugin")]
        private static extern void YVRSetRenderScale(string packageName, YVRRenderScale renderScale);

        public static List<YVRRenderScale> GetRenderScale(string packageName)
        {
            var renderScaleBuffers = new YVRRenderScaleBuffers()
            {
                renderScaleCapacityInput = 0,
                renderScaleCountOutput = 0,
            };

            YVRGetRenderScale(packageName, ref renderScaleBuffers);
            renderScaleBuffers.renderScaleCapacityInput = renderScaleBuffers.renderScaleCountOutput;
            int size = Marshal.SizeOf<YVRRenderScale>();
            renderScaleBuffers.renderScale = Marshal.AllocHGlobal(renderScaleBuffers.renderScaleCountOutput * size);
            YVRGetRenderScale(packageName, ref renderScaleBuffers);
            List<YVRRenderScale> renderScales = ConvertIntPtr2List<YVRRenderScale>(renderScaleBuffers.renderScale,
             renderScaleBuffers.renderScaleCountOutput);
            Marshal.FreeHGlobal(renderScaleBuffers.renderScale);

            return renderScales;
        }

        public static void SetRenderScale(string packageName, YVRRenderScale scale)
        {
            YVRSetRenderScale(packageName, scale);
        }

        private static List<T> ConvertIntPtr2List<T>(IntPtr ptr, int count)
        {
            var objArray = new List<T>();
            for (int i = 0; i < count; i++)
            {
                IntPtr objPtr = IntPtr.Add(ptr, i * Marshal.SizeOf<T>());
                objArray.Add(Marshal.PtrToStructure<T>(objPtr));
            }

            return objArray;
        }
    }
}