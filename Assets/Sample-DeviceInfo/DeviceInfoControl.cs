using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using YVR.Enterprise.Device;

namespace YVR.Enterprise.Device.Sample.DeviceInfo
{
    public class StorageInfo
    {
        public float totalSize;
        public float freeSize;
        public float usedSize;
    }

    public class DeviceInfoControl : MonoBehaviour
    {
        public TMP_Text deviceSnResult;
        public TMP_Text deviceModelResult;
        public TMP_Text softwareVersionResult;
        public TMP_Text isBtOnResult;
        public TMP_Text isBtOnCallbackResult;
        public TMP_Text btMacResult;
        public TMP_Text btNameConnectedResult;
        public TMP_Text btNameConnectedCallbackResult;
        
        public TMP_Text isWifiOnResult;
        public TMP_Text isWifiOnCallbackResult;
        public TMP_Text WifiMacResult;
        public TMP_Text isDeviceWornResult;
        public TMP_Text isDeviceWornCallbackResult;
        public TMP_Text totalSizeData;
        public TMP_Text freeSizeData;
        public TMP_Text usedSizeData;
        
        public TMP_Text deviceBatteryResult;
        public TMP_Text deviceBatteryCallbackResult;
        public TMP_Text isDeviceChargingResult;
        public TMP_Text deviceChargingCallbackResult;
        public TMP_Text batteryTemperatureResult;
        public TMP_Text LeftBattery;
        public TMP_Text RightBattery;
        public TMP_Text ControllerBatteryCallbackResult;
        
        
        public TMP_Text LeftBatteryChargingStatus;
        public TMP_Text rightBatteryChargingStatus;
        public TMP_Text ControllerChargingCallbackResult;
        
        
        // Start is called before the first frame update
        void Start()
        {
            #region part1
            deviceSnResult.text = DeviceInfoMgr.instance.deviceSn;
            deviceModelResult.text = DeviceInfoMgr.instance.deviceModel;
            softwareVersionResult.text = DeviceInfoMgr.instance.osVersion;
            isBtOnResult.text = DeviceInfoMgr.instance.IsBtOn()?"true":"false";
            DeviceInfoMgr.instance.IsBtOn(BtStateDoSomething);
            btMacResult.text = DeviceInfoMgr.instance.btMac;
            btNameConnectedResult.text = DeviceInfoMgr.instance.BTNameConnected();
            DeviceInfoMgr.instance.BTNameConnected(BtNameConnectedChangedDoSomething);
            #endregion
            
            #region part2
    
            isWifiOnResult.text = DeviceInfoMgr.instance.IsWifiOn()?"true":"false";
            DeviceInfoMgr.instance.IsWifiOn(WifiStateDoSomething);
            WifiMacResult.text = DeviceInfoMgr.instance.wifiMac;
            isDeviceWornResult.text = DeviceInfoMgr.instance.IsDeviceWorn()?"true":"false";
            DeviceInfoMgr.instance.IsDeviceWorn(DeviceWornChangedDoSomething);
            string storageInfoStr = DeviceInfoMgr.instance.storageInfo;
            StorageInfo storageInfo = JsonUtility.FromJson<StorageInfo>(storageInfoStr);
            totalSizeData.text = (storageInfo.totalSize/(1024*1024)).ToString();
            freeSizeData.text = (storageInfo.freeSize/(1024*1024)).ToString();
            usedSizeData.text = (storageInfo.usedSize/(1024*1024)).ToString();
    
            #endregion
            
            #region part3
    
            deviceBatteryResult.text = DeviceInfoMgr.instance.GetDeviceBattery().ToString();
            DeviceInfoMgr.instance.GetDeviceBattery(DeviceBatteryChangedDoSomething);
            
            isDeviceChargingResult.text = DeviceInfoMgr.instance.IsDeviceCharging()?"true":"false";
            DeviceInfoMgr.instance.IsDeviceCharging(DeviceChargingStateChangedDoSomething);
    
            string[] controllerBattery = DeviceInfoMgr.instance.GetControllerBattery().Split("/");
            LeftBattery.text = controllerBattery[0];
            RightBattery.text = controllerBattery[1];
            DeviceInfoMgr.instance.GetControllerBattery(ControllerBatteryChangedDoSomething);
            #endregion
    
            #region part4
    
            string[] controllerState = DeviceInfoMgr.instance.IsControllerCharging().Split("/"); 
            LeftBatteryChargingStatus.text = controllerState[0];
            rightBatteryChargingStatus.text = controllerState[1];
            DeviceInfoMgr.instance.IsControllerCharging(ControllerChargingStateChanged);
    
            
            #endregion
    
        }
        private void Update()
        {
            #region part3
            
            batteryTemperatureResult.text = DeviceInfoMgr.instance.batteryTemperature.ToString();
            
            #endregion
        }
    
        public void BtStateDoSomething(bool value)
        {
            isBtOnCallbackResult.text = "bt state Has changed,now is ";
            isBtOnCallbackResult.text += value.ToString();
            
            isBtOnResult.text = value?"true":"false";
            btMacResult.text = DeviceInfoMgr.instance.btMac;
        }
    
        public void BtNameConnectedChangedDoSomething(string name)
        {
            btNameConnectedCallbackResult.text = "bt Has changed,Now the connected device is ";
            btNameConnectedCallbackResult.text += name;
            
            btNameConnectedResult.text = name;
        }
    
        public void WifiStateDoSomething(bool value)
        {
            isWifiOnCallbackResult.text = "Wifi State Has changed,now is ";
            isWifiOnCallbackResult.text += value.ToString();
            
            isWifiOnResult.text = value?"true":"false";
            WifiMacResult.text = DeviceInfoMgr.instance.wifiMac;
        }
    
        public void DeviceWornChangedDoSomething(bool value)
        {
            isDeviceWornCallbackResult.text = " DeviceWorn Has changed,now is ";
            isDeviceWornCallbackResult.text += value.ToString();
            
            isDeviceWornResult.text = value?"true":"false";
        }
    
        public void DeviceBatteryChangedDoSomething(int value)
        {
            deviceBatteryCallbackResult.text = "Battery Has changed,now is ";
            deviceBatteryCallbackResult.text += value.ToString();
            
            deviceBatteryResult.text = DeviceInfoMgr.instance.GetDeviceBattery().ToString();
        }
    
        public void DeviceChargingStateChangedDoSomething(bool value)
        {
            deviceChargingCallbackResult.text = "Battery Has changed,now is ";
            deviceChargingCallbackResult.text += value.ToString();
            
            isDeviceChargingResult.text = value?"true":"false";
        }
        
        private void ControllerBatteryChangedDoSomething(string value)
        {
            ControllerBatteryCallbackResult.text = "Controller Battery Has changed,now is ";
            ControllerBatteryCallbackResult.text += value;
            
            string[] controllerBattery = DeviceInfoMgr.instance.GetControllerBattery().Split("/");
            LeftBattery.text = controllerBattery[0];
            RightBattery.text = controllerBattery[1];
        }
        
        private void ControllerChargingStateChanged(string state)
        {
            ControllerChargingCallbackResult.text = "ControllerCharging State Has changed,now is ";
            ControllerChargingCallbackResult.text += state;
            
            string[] controllerState = DeviceInfoMgr.instance.IsControllerCharging().Split("/"); 
            LeftBatteryChargingStatus.text = controllerState[0];
            rightBatteryChargingStatus.text = controllerState[1];
        }
        
    }
}


