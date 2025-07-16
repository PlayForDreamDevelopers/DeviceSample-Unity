using System;
using UnityEngine.Internal;

namespace YVR.Enterprise.LBE
{
    public abstract class LBEPlugin
    {
        private static LBEPlugin s_Instance;
        [ExcludeFromDocs] public const int spaceUuidMaxSize = 4;

        public static LBEPlugin instance
        {
            get
            {
                if (s_Instance == null)
                {
#if UNITY_EDITOR
                    s_Instance = new LBEDefaultPlugin();
#else
                    s_Instance = new LBEAndroidPlugin();
#endif
                }

                return s_Instance;
            }
        }

        public abstract float GetGroundDistance();
        public abstract void SetMarkerDetectionEnable(bool enable);
        public abstract void SetMarkerTrackingUpdateCallback(Action<MarkerTrackingUpdateData> callback);


        public abstract void SetRecenterEnable(bool enable);

        public abstract bool GetRecenterEnable();
    }
}