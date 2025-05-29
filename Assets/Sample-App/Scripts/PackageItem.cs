using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace YVR.Enterprise.Device.Sample 
{ 
    public class PackageItem : MonoBehaviour,IPointerClickHandler
    {
        [HideInInspector]public TMP_Text PackageName;
        [SerializeField]private AppControl appControl;
        private void Awake()
        {
            PackageName = GetComponent<TMP_Text>();
            appControl = GameObject.Find("Canvas").GetComponent<AppControl>();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            appControl.HandleSearchAppInfo(PackageName.text);
        }
    }
}



