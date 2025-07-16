# Camera Data

> [!note]
>
> Refer to our open‑source project [Camera Sample][camera-sample] for more information.

Camera data is divided into Tracking Camera Data and VST Camera Data.

> [!important]
>
> When the camera is opened, please ensure to close it when not in use to avoid resource wastage.

## Tracking Camera Data

Tracking camera data can be obtained via [YVRTrackingCameraPlugin]. The main interfaces include:

| Interface                                            | Description                                                               |
| ---------------------------------------------------- | ------------------------------------------------------------------------- |
| [OpenTrackingCamera][open-tracking]                  | Opens the tracking camera                                                 |
| [CloseTrackingCamera][close-tracking]                | Closes the tracking camera                                                |
| [SubscribeFrame][subscribe-frame]                    | Subscribes to camera frame data; callback returns a [CameraFrameItemData] |
| [UnsubscribeFrame][unsubscribe-frame]                | Unsubscribes from camera frame data                                       |
| [AcquireTrackingCameraFrame][acquire-tracking-frame] | Acquires a camera frame                                                   |
| [SetTrackingCameraFrequency][set-tracking-frequency] | Sets the camera frame rate (type supports EyeTracking only)               |

## VST Camera Data

VST camera data can be retrieved via [YVRVSTCameraPlugin]. The main interfaces include:

| Interface                                           | Description                                                                                               |
| --------------------------------------------------- | --------------------------------------------------------------------------------------------------------- |
| [OpenVSTCamera][open-vst]                           | Opens the VST camera                                                                                      |
| [CloseVSTCamera][close-vst]                         | Closes the VST camera                                                                                     |
| [AcquireVSTCameraFrame][acquire-vst-frame]          | Acquires a VST camera frame; returns [VSTFrameData]                                                       |
| [SetVSTCameraFrequency][set-vst-frequency]          | Sets the VST camera frame rate                                                                            |
| [GetVSTCameraFrequency][get-vst-frequency]          | Gets the VST camera frame rate                                                                            |
| [SetVSTCameraResolution][set-vst-resolution]        | Sets the VST camera resolution                                                                            |
| [GetVSTCameraResolution][get-vst-resolution]        | Gets the VST camera resolution                                                                            |
| [SetVSTCameraFormat][set-vst-format]                | Sets the VST camera format                                                                                |
| [GetVSTCameraFormat][get-vst-format]                | Gets the VST camera format                                                                                |
| [SetVSTCameraOutputSource][set-vst-output]          | Sets the VST camera output source                                                                         |
| [GetVSTCameraOutputSource][get-vst-output]          | Gets the VST camera output source                                                                         |
| [GetVSTCameraIntrinsicExtrinsic][get-vst-intrinsic] | Gets the intrinsic and extrinsic parameters of the VST camera (returns [VSTCameraIntrinsicExtrinsicData]) |

<!-- All hyperlinks definitions remain unchanged -->

[camera-sample]: https://github.com/PlayForDreamDevelopers/CameraSample-Unity
[tracking-plugin]: xref:YVR.Enterprise.Camera.YVRTrackingCameraPlugin
[open-tracking]: xref:YVR.Enterprise.Camera.YVRTrackingCameraPlugin.OpenTrackingCamera(YVR.Enterprise.Camera.TrackingCameraType)
[close-tracking]: xref:YVR.Enterprise.Camera.YVRTrackingCameraPlugin.CloseTrackingCamera(YVR.Enterprise.Camera.TrackingCameraType)
[subscribe-frame]: xref:YVR.Enterprise.Camera.YVRTrackingCameraPlugin.SubscribeFrame(YVR.Enterprise.Camera.TrackingCameraType,System.Action{YVR.Enterprise.Camera.CameraFrameItemData})
[frame-data]: xref:YVR.Enterprise.Camera.CameraFrameItemData
[unsubscribe-frame]: xref:YVR.Enterprise.Camera.YVRTrackingCameraPlugin.UnsubscribeFrame(YVR.Enterprise.Camera.TrackingCameraType)
[acquire-tracking-frame]: xref:YVR.Enterprise.Camera.YVRTrackingCameraPlugin.AcquireTrackingCameraFrame(YVR.Enterprise.Camera.TrackingCameraType,YVR.Enterprise.Camera.CameraFrameItemData@)
[set-tracking-frequency]: xref:YVR.Enterprise.Camera.YVRTrackingCameraPlugin.SetTrackingCameraFrequency(YVR.Enterprise.Camera.TrackingCameraType,System.Int32)
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
