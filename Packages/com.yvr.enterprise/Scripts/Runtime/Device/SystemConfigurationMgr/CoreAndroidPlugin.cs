using System.Runtime.InteropServices;
using YVR.Utilities;

namespace YVR.Enterprise.Device
{
    public class CoreAndroidPlugin : CorePlugin
    {
        [DllImport("yvrplugin")]
        private static extern void YVRSetIPDEnable(bool enable);

        [DllImport("yvrplugin")]
        private static extern bool YVRGetIPDEnable();

        [DllImport("yvrplugin")]
        private static extern void YVRSetIPDValue(float value);

        [DllImport("yvrplugin")]
        private static extern float YVRGetIPDVale();

        public static CoreAndroidPlugin Create() { return new CoreAndroidPlugin(); }

        public override void SetIPDEnable(bool enable) { YVRSetIPDEnable(enable); }

        public override bool GetIPDEnable()
        {
            return YVRGetIPDEnable();
        }

        public override void SetIPDValue(float value)
        {
            YVRSetIPDValue(value);
        }
        public override float GetIPDVale() { return YVRGetIPDVale(); }
    }
}