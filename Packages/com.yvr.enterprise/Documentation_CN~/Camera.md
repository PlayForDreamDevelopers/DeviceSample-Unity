# 相机数据

> [!note]
>
> 可参考我们的开源项目 [相机 示例][camera-sample] 获取更多信息

相机数据可以再进一步分为追踪相机数据和 VST 相机数据。

> [!important]
>
> 当打开相机后，请确保在不使用时关闭相机，以避免资源浪费。

## 追踪相机数据

追踪相机的数据，可以通过 [YVRTrackingCameraPlugin][tracking-plugin] 获取，目前主要包含有以下接口：

| 接口                                                 | 说明                                                                   |
| ---------------------------------------------------- | ---------------------------------------------------------------------- |
| [OpenTrackingCamera][open-tracking]                  | 打开追踪相机                                                           |
| [CloseTrackingCamera][close-tracking]                | 关闭追踪相机                                                           |
| [SubscribeFrame][subscribe-frame]                    | 订阅相机帧数据，当回调触发时返回参数 [CameraFrameItemData][frame-data] |
| [UnsubscribeFrame][unsubscribe-frame]                | 取消订阅相机帧数据                                                     |
| [AcquireTrackingCameraFrame][acquire-tracking-frame] | 获取相机帧数据                                                         |
| [SetTrackingCameraFrequency][set-tracking-frequency] | 设置相机帧率                                                           |
## VST 相机数据

VST 相机的数据，可以通过 [YVRVSTCameraPlugin][vst-plugin] 获取，目前主要包含有以下接口：

| 接口                                                | 说明                                                                                        |
| --------------------------------------------------- | ------------------------------------------------------------------------------------------- |
| [OpenVSTCamera][open-vst]                           | 打开 VST 相机                                                                               |
| [CloseVSTCamera][close-vst]                         | 关闭 VST 相机                                                                               |
| [AcquireVSTCameraFrame][acquire-vst-frame]          | 获取 VST 相机帧数据，返回 [VSTFrameData][vst-frame-data]                                    |
| [SetVSTCameraFrequency][set-vst-frequency]          | 设置 VST 相机帧率                                                                           |
| [GetVSTCameraFrequency][get-vst-frequency]          | 获取 VST 相机帧率                                                                           |
| [SetVSTCameraResolution][set-vst-resolution]        | 设置 VST 相机分辨率                                                                         |
| [GetVSTCameraResolution][get-vst-resolution]        | 获取 VST 相机分辨                                                                           |
| [SetVSTCameraFormat][set-vst-format]                | 设置 VST 相机格式                                                                           |
| [GetVSTCameraFormat][get-vst-format]                | 获取 VST 相机格式                                                                           |
| [SetVSTCameraOutputSource][set-vst-output]          | 设置 VST 相机输出源                                                                         |
| [GetVSTCameraOutputSource][get-vst-output]          | 获取 VST 相机输出源                                                                         |
| [GetVSTCameraIntrinsicExtrinsic][get-vst-intrinsic] | 获取 VST 相机内外参数，返回 [VSTCameraIntrinsicExtrinsicData][vst-intrinsic-extrinsic-data] |

<!-- 所有超链接定义 -->

[camera-sample]: https://github.com/PlayForDreamDevelopers/CameraSample-Unity

<!-- 追踪相机链接 -->

[tracking-plugin]: xref:YVR.Enterprise.Camera.YVRTrackingCameraPlugin
[open-tracking]: xref:YVR.Enterprise.Camera.YVRTrackingCameraPlugin.OpenTrackingCamera(YVR.Enterprise.Camera.TrackingCameraType)
[close-tracking]: xref:YVR.Enterprise.Camera.YVRTrackingCameraPlugin.CloseTrackingCamera(YVR.Enterprise.Camera.TrackingCameraType)
[subscribe-frame]: xref:YVR.Enterprise.Camera.YVRTrackingCameraPlugin.SubscribeFrame(YVR.Enterprise.Camera.TrackingCameraType,System.Action{YVR.Enterprise.Camera.CameraFrameItemData})
[frame-data]: xref:YVR.Enterprise.Camera.CameraFrameItemData
[unsubscribe-frame]: xref:YVR.Enterprise.Camera.YVRTrackingCameraPlugin.UnsubscribeFrame(YVR.Enterprise.Camera.TrackingCameraType)
[acquire-tracking-frame]: xref:YVR.Enterprise.Camera.YVRTrackingCameraPlugin.AcquireTrackingCameraFrame(YVR.Enterprise.Camera.TrackingCameraType,YVR.Enterprise.Camera.CameraFrameItemData@)
[set-tracking-frequency]: xref:YVR.Enterprise.Camera.YVRTrackingCameraPlugin.SetTrackingCameraFrequency(YVR.Enterprise.Camera.TrackingCameraType,System.Int32)

<!-- VST相机链接 -->

[vst-plugin]: xref:YVR.Enterprise.Camera.YVRVSTCameraPlugin
[open-vst]: xref:YVR.Enterprise.Camera.YVRVSTCameraPlugin.OpenVSTCamera
[close-vst]: xref:YVR.Enterprise.Camera.YVRVSTCameraPlugin.CloseVSTCamera
[acquire-vst-frame]: xref:YVR.Enterprise.Camera.YVRVSTCameraPlugin.AcquireVSTCameraFrame(YVR.Enterprise.Camera.VSTCameraFrameData@)
[set-vst-frequency]: xref:YVR.Enterprise.Camera.YVRVSTCameraPlugin.SetVSTCameraFrequency(YVR.Enterprise.Camera.VSTCameraFrequencyType)
[get-vst-frequency]: xref:YVR.Enterprise.Camera.YVRVSTCameraPlugin.GetVSTCameraFrequency(YVR.Enterprise.Camera.VSTCameraFrequencyType@)
[set-vst-resolution]: xref:YVR.Enterprise.Camera.YVRVSTCameraPlugin.SetVSTCameraResolution(YVR.Enterprise.Camera.VSTCameraResolutionType)
[get-vst-resolution]: xref:YVR.Enterprise.Camera.YVRVSTCameraPlugin.GetVSTCameraResolution(YVR.Enterprise.Camera.VSTCameraResolutionType@)
[set-vst-format]: xref:YVR.Enterprise.Camera.YVRVSTCameraPlugin.SetVSTCameraFormat(YVR.Enterprise.Camera.VSTCameraFormatType)
[get-vst-format]: xref:YVR.Enterprise.Camera.YVRVSTCameraPlugin.GetVSTCameraFormat(YVR.Enterprise.Camera.VSTCameraFormatType@)
[set-vst-output]: xref:YVR.Enterprise.Camera.YVRVSTCameraPlugin.SetVSTCameraOutputSource(YVR.Enterprise.Camera.VSTCameraSourceType)
[get-vst-output]: xref:YVR.Enterprise.Camera.YVRVSTCameraPlugin.GetVSTCameraOutputSource(YVR.Enterprise.Camera.VSTCameraSourceType@)
[get-vst-intrinsic]: xref:YVR.Enterprise.Camera.YVRVSTCameraPlugin.GetVSTCameraIntrinsicExtrinsic(YVR.Enterprise.Camera.YVREyeNumberType,YVR.Enterprise.Camera.VSTCameraIntrinsicExtrinsicData@)
[vst-frame-data]: xref:YVR.Enterprise.Camera.VSTCameraFrameData
[vst-intrinsic-extrinsic-data]: xref:YVR.Enterprise.Camera.VSTCameraIntrinsicExtrinsicData
