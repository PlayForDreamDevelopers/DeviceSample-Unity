# 系统配置管理

> [!note]
>
> SystemConfigurationMgr 用于系统配置相关的管理，如亮度、音量、超时、护眼模式、IPD、ETFR、4K 渲染等。

## 主要接口

| 接口/属性                                                                | 说明                            |
| ------------------------------------------------------------------------ | ------------------------------- |
| `screenOffTimeOut`                                                       | 获取/设置屏幕熄灭超时时间       |
| `screenOffSleepTimeOut`                                                  | 获取/设置休眠超时时间           |
| `brightness`                                                             | 获取/设置屏幕亮度               |
| `volume`                                                                 | 获取/设置音量                   |
| `maxVolume`                                                              | 获取最大音量                    |
| `eyeProtectionMode`                                                      | 获取/设置护眼模式               |
| `handTrackingStatus`                                                     | 获取/设置手势追踪状态           |
| `ChangeThirdHomeState(string packageName, bool isEnable)`                | 设置第三方 Home 状态            |
| `yvrLauncherState`                                                       | 获取/设置 YVR Launcher 状态     |
| `SetRecenterEnable(bool open)`                                           | 设置是否允许 Recenter           |
| `isRecenterEnable`                                                       | 获取是否允许 Recenter           |
| `SetUsingRightControllerForRecenter(bool useRightController)`            | 设置是否用右手柄 Recenter       |
| `isUsingRightControllerForRecenter`                                      | 获取是否用右手柄 Recenter       |
| `passthroughVisibility`                                                  | 获取/设置透视可见性             |
| `ConnectWifiAp(string ssid, string pwd, Action<string> callback = null)` | 连接 WiFi AP                    |
| `GetWifiNameConnected(Action<string> callback = null)`                   | 获取已连接 WiFi 名称            |
| `GetWifiIP(Action<string> callback = null)`                              | 获取 WiFi IP 地址               |
| `securityAreaStatus`                                                     | 获取/设置安全区状态             |
| `securityTracking`                                                       | 获取/设置安全追踪状态           |
| `usbDebugMode`                                                           | 获取/设置 USB 调试模式          |
| `SetBtEnabled(bool enabled)`                                             | 设置蓝牙开关                    |
| `CreateSecurityArea()`                                                   | 创建安全区                      |
| `isShowGestureCtrlHomeIcon`                                              | 获取/设置是否显示手势 Home 图标 |
| `brightnessAdjustmentRestricted`                                         | 获取/设置亮度调节限制           |
| `volumeAdjustmentRestricted`                                             | 获取/设置音量调节限制           |
| `EnableIPDAutoAdjustment(bool enable)`                                   | 启用/禁用 IPD 自动调节          |
| `GetIPDAutoAdjustmentEnable()`                                           | 获取 IPD 自动调节状态           |
| `EnableIPDManualAdjustment(bool enable)`                                 | 启用/禁用 IPD 手动调节          |
| `GetIPDManualAdjustmentEnable()`                                         | 获取 IPD 手动调节状态           |
| `SetIPDValue(float value)`                                               | 设置 IPD 数值                   |
| `GetIPDValue()`                                                          | 获取 IPD 数值                   |
| `IsETFREnable()`                                                         | 查询 ETFR 渲染聚焦是否启用      |
| `IsETFRScreenEnable()`                                                   | 查询 ETFR 屏幕是否启用          |
| `SetScreenETFRModeEnable(bool enable)`                                   | 设置 ETFR 屏幕模式              |
| `SetETFREnable(bool enable)`                                             | 设置 ETFR 渲染聚焦              |
| `Is4KRenderingMode()`                                                    | 查询 4K 渲染模式是否启用        |
| `Set4KRenderingMode(bool enable)`                                        | 设置 4K 渲染模式                |

## 示例

```csharp
// 设置亮度
SystemConfigurationMgr.Instance.brightness = 80;

// 启用护眼模式
SystemConfigurationMgr.Instance.eyeProtectionMode = true;

// 启用 4K 渲染
SystemConfigurationMgr.Instance.Set4KRenderingMode(true);

// 查询 ETFR 渲染聚焦状态
bool etfr = SystemConfigurationMgr.Instance.IsETFREnable();
```
