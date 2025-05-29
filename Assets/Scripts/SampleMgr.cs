using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using YVR.Core;

namespace YVR.Enterprise.Device.Sample
{
    public class SampleMgr : MonoBehaviour
    {
        private void Start()
        {
            YVRManager.instance.hmdManager.SetPassthrough(true);
        }

        public void ChangeScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}


