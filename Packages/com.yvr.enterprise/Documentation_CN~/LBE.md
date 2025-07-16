# 大空间(LBE) 支持

> [!note]
>
> 可参考我们的开源项目 [LBE 示例](https://github.com/PlayForDreamDevelopers/LBESample-Unity) 获取更多信息

为使用 LBE 相关的接口，你首先需要勾选 `YVRManager` 脚本上的 `Large Space Support` 选项：

![Large Space Support](assets/LBE/2025-03-19-15-30-05.png)

LBE 相关的接口都定义在 [LBEPlugin](xref:YVR.Enterprise.LBE.LBEPlugin) 中，目前主要包含有一下接口：

| 接口                                                                   | 说明                                                                                                                      |
| ---------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------- |
| [GetGroundDistance][get-ground-distance]                               | 获取地面距离                                                                                                              |
| [SetMarkerDetectionEnable][set-marker-detection-enable]                | 设置标记检测是否启用                                                                                                      |
| [SetMarkerTrackingUpdateCallback][set-marker-tracking-update-callback] | 设置标记跟踪更新回调，回调在识别到标记时被调用，参数中包含 [MarkerTrackingUpdateData][marker-tracking-update-data] 结构体 |
| [SetRecenterEnable][set-recenter-enable]                               | 设置重新定位是否启用                                                                                                      |
| [GetRecenterEnable][get-recenter-enable]                               | 获取重新定位是否启用状态                                                                                                  |

注册 Marker 触发回调的示例为：

```csharp
// ...
LBEPlugin.instance.SetMarkerDetectionEnable(true);
LBEPlugin.instance.SetMarkerTrackingUpdateCallback(OnReceiveMarkerTrackingUpdateData);

private void OnReceiveMarkerTrackingUpdateData(MarkerTrackingUpdateData data)
{
    // ...
}
```

[get-ground-distance]: xref:YVR.Enterprise.LBE.LBEPlugin.GetGroundDistance
[set-marker-detection-enable]: xref:YVR.Enterprise.LBE.LBEPlugin.SetMarkerDetectionEnable(System.Boolean)
[set-marker-tracking-update-callback]: xref:YVR.Enterprise.LBE.LBEPlugin.SetMarkerTrackingUpdateCallback(System.Action{YVR.Enterprise.LBE.MarkerTrackingUpdateData})
[marker-tracking-update-data]: xref:YVR.Enterprise.LBE.MarkerTrackingUpdateData
[set-recenter-enable]: xref:YVR.Enterprise.LBE.LBEPlugin.SetRecenterEnable(System.Boolean)
[get-recenter-enable]: xref:YVR.Enterprise.LBE.LBEPlugin.GetRecenterEnable
