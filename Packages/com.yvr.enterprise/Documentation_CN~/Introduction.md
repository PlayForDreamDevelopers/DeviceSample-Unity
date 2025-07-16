# Unity 企业版 SDK 介绍

Unity 企业版 SDK 主要提供了以下功能：
- 设备信息与控制：通过 [DeviceMgr](xref:YVR.Enterprise.Device.DeviceMgr) 获取和控制设备的各种信息，如蓝牙 MAC 地址、Wi-Fi MAC 地址、设备型号、设备序列号、操作系统版本、音量、亮度等。
- 大空间(LBE) 支持：通过 [LBEPlugin](xref:YVR.Enterprise.LBE.LBEPlugin) 提供的大空间支持接口，可以获取地面距离、设置标记检测、设置重新定位等功能。
- 相机数据：通过 [YVRTrackingCameraPlugin](xref:YVR.Enterprise.Camera.YVRTrackingCameraPlugin) 和 [YVRVSTCameraPlugin](xref:YVR.Enterprise.Camera.YVRVSTCameraPlugin) 获取追踪相机和 VST 相机的数据，包括打开/关闭相机、订阅/取消订阅相机帧数据、设置相机帧率、分辨率、格式等。