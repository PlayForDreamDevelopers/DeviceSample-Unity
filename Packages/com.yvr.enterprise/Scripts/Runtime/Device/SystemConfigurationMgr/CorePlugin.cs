using UnityEngine;

namespace YVR.Enterprise.Device
{
    public abstract class CorePlugin
    {
        private static CorePlugin s_Instance;

        public static CorePlugin Instance
        {
            get
            {
                if (s_Instance == null)
                {
                    if (!Application.isEditor && Application.platform == RuntimePlatform.Android)
                        s_Instance = CoreAndroidPlugin.Create();
                    else
                        s_Instance = CoreEditorPlugin.Create();
                }

                return s_Instance;
            }
        }
        public virtual void SetIPDEnable(bool enable){}
        public virtual bool GetIPDEnable() { return false;}
        public virtual void SetIPDValue(float value){}
        public virtual float GetIPDVale() { return -1; }

    }
}