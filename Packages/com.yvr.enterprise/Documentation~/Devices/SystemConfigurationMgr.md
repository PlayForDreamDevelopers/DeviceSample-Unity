# SystemConfigurationMgr

> [!note]
>
> SystemConfigurationMgr is used for system configuration management, such as brightness, volume, timeout, eye protection mode, IPD, ETFR, 4K rendering, etc.

## Main Interfaces

| Interface/Property                                                                | Description                            |
| ------------------------------------------------------------------------ | ------------------------------- |
| `screenOffTimeOut`                                                       | Get/Set screen off timeout       |
| `screenOffSleepTimeOut`                                                  | Get/Set sleep timeout           |
| `brightness`                                                             | Get/Set screen brightness               |
| `volume`                                                                 | Get/Set volume                   |
| `maxVolume`                                                              | Get max volume                    |
| `eyeProtectionMode`                                                      | Get/Set eye protection mode               |
| `handTrackingStatus`                                                     | Get/Set hand tracking status           |
| `ChangeThirdHomeState(string packageName, bool isEnable)`                | Set third-party Home state            |
| `yvrLauncherState`                                                       | Get/Set YVR Launcher state     |
| `SetRecenterEnable(bool open)`                                           | Set whether to allow Recenter           |
| `isRecenterEnable`                                                       | Get whether Recenter is allowed           |
| `SetUsingRightControllerForRecenter(bool useRightController)`            | Set whether to use right controller for Recenter       |
| `isUsingRightControllerForRecenter`                                      | Get whether right controller is used for Recenter       |
| `passthroughVisibility`                                                  | Get/Set passthrough visibility             |
| `ConnectWifiAp(string ssid, string pwd, Action<string> callback = null)` | Connect to WiFi AP                    |
| `GetWifiNameConnected(Action<string> callback = null)`                   | Get the name of the connected WiFi            |
| `GetWifiIP(Action<string> callback = null)`                              | Get WiFi IP address               |
| `securityAreaStatus`                                                     | Get/Set security area status             |
| `securityTracking`                                                       | Get/Set security tracking status           |
| `usbDebugMode`                                                           | Get/Set USB debug mode          |
| `SetBtEnabled(bool enabled)`                                             | Set Bluetooth switch                    |
| `CreateSecurityArea()`                                                   | Create security area                      |
| `isShowGestureCtrlHomeIcon`                                              | Get/Set whether to show gesture Home icon |
| `brightnessAdjustmentRestricted`                                         | Get/Set brightness adjustment restriction           |
| `volumeAdjustmentRestricted`                                             | Get/Set volume adjustment restriction           |
| `EnableIPDAutoAdjustment(bool enable)`                                   | Enable/Disable IPD auto adjustment          |
| `GetIPDAutoAdjustmentEnable()`                                           | Get IPD auto adjustment status           |
| `EnableIPDManualAdjustment(bool enable)`                                 | Enable/Disable IPD manual adjustment          |
| `GetIPDManualAdjustmentEnable()`                                         | Get IPD manual adjustment status           |
| `SetIPDValue(float value)`                                               | Set IPD value                   |
| `GetIPDValue()`                                                          | Get IPD value                   |
| `IsETFREnable()`                                                         | Query whether ETFR rendering focus is enabled      |
| `IsETFRScreenEnable()`                                                   | Query whether ETFR screen is enabled          |
| `SetScreenETFRModeEnable(bool enable)`                                   | Set ETFR screen mode              |
| `SetETFREnable(bool enable)`                                             | Set ETFR rendering focus              |
| `Is4KRenderingMode()`                                                    | Query whether 4K rendering mode is enabled        |
| `Set4KRenderingMode(bool enable)`                                        | Set 4K rendering mode                |

## Example
