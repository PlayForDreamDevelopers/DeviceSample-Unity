# 应用管理

> [!note]
>
> AppMgr 用于管理应用相关的操作，包括获取应用列表、设置开机自启动应用、启动/关闭应用等。

## 主要接口

| 接口                                                            | 说明                               |
| --------------------------------------------------------------- | ---------------------------------- |
| `allPackages`                                                   | 获取设备上所有包名列表             |
| `appList`                                                       | 获取当前可用应用列表               |
| `SetStartupApp(string pkgName, bool enable)`                    | 设置指定包名为开机自启动应用       |
| `startupApp`                                                    | 获取当前设置的开机自启动应用包名   |
| `appCloseAbility`                                               | 获取/设置应用关闭能力              |
| `configurationPermission`                                       | 获取/设置配置权限                  |
| `SetBootAutoStart(string packageName)`                          | 设置指定包名为开机自启动           |
| `bootAutoStart`                                                 | 获取所有设置为开机自启动的包名数组 |
| `StartActivity(string pkgName, string className)`               | 启动指定包名和类名的 Activity      |
| `StopApp(string packageName)`                                   | 关闭指定包名的应用                 |
| `StopApps(object[] pkgList)`                                    | 批量关闭指定包名的应用             |
| `SetAppKeepAlive(string appPackageName, bool keepAlive)`        | 设置应用保活状态                   |
| `IsAppKeepAlive(string appPackageName)`                         | 获取应用保活状态                   |
| `SilentInstall(string apkPath, Action<string> callback = null)` | 静默安装应用                       |
| `SilentUnInstall(string pkg, Action<string> callback = null)`   | 静默卸载应用                       |
| `runningThirdPartyAppPackageName`                               | 获取正在运行的第三方应用包名列表   |
| `topRunningAppForMainDisplay`                                   | 获取主显示屏顶部运行的应用包名     |
| `topRunningApp`                                                 | 获取当前顶部运行的应用包名         |
| `StartWifiUI()`                                                 | 启动 WiFi 设置界面                 |
| `StartBtUI()`                                                   | 启动蓝牙设置界面                   |

## 示例

```csharp
// 设置某应用为开机自启动
AppMgr.Instance.SetStartupApp("com.example.app", true);

// 启动 Activity
AppMgr.Instance.StartActivity("com.example.app", "com.example.app.MainActivity");
// 设置应用保活
AppMgr.Instance.SetAppKeepAlive("com.example.app", true);

// 静默安装应用
AppMgr.Instance.SilentInstall("/sdcard/Download/example.apk", result => Debug.Log(result));

// 启动 WiFi 设置界面
AppMgr.Instance.StartWifiUI();
```
