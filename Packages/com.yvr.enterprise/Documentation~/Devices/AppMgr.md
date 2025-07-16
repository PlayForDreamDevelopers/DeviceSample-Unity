# AppMgr

> [!note]
>
> AppMgr is used for managing application-related operations, including obtaining the application list, setting applications to auto-start on boot, launching/closing applications, etc.

## Main Interfaces

| Interface                                              | Description                               |
| ------------------------------------------------- | ---------------------------------- |
| `allPackages`                                     | Get the list of all package names on the device             |
| `appList`                                         | Get the list of currently available applications               |
| `SetStartupApp(string pkgName, bool enable)`      | Set the specified package as an auto-start application       |
| `startupApp`                                      | Get the currently set auto-start application package name   |
| `appCloseAbility`                                 | Get/Set application close ability              |
| `configurationPermission`                         | Get/Set configuration permission                  |
| `SetBootAutoStart(string packageName)`            | Set the specified package as boot auto-start           |
| `bootAutoStart`                                   | Get all package names set as boot auto-start |
| `StartActivity(string pkgName, string className)` | Start the Activity with the specified package and class name      |
| `StopApp(string packageName)`                     | Close the application with the specified package name                 |
| `StopApps(object[] pkgList)`                      | Batch close applications with the specified package names             |
| `SetAppKeepAlive(string appPackageName, bool keepAlive)` | Set application keep-alive status                  |
| `IsAppKeepAlive(string appPackageName)`                  | Get application keep-alive status                  |
| `SilentInstall(string apkPath, Action<string> callback = null)` | Silent install application                |
| `SilentUnInstall(string pkg, Action<string> callback = null)`   | Silent uninstall application                |
| `runningThirdPartyAppPackageName`                        | Get the list of running third-party application package names  |
| `topRunningAppForMainDisplay`                            | Get the top running application package name for the main display    |
| `topRunningApp`                                          | Get the current top running application package name        |
| `StartWifiUI()`                                          | Launch the WiFi settings UI                |
| `StartBtUI()`                                            | Launch the Bluetooth settings UI                  |

## Example

```csharp
// Set an application as auto-start on boot
AppMgr.Instance.SetStartupApp("com.example.app", true);

// Start Activity
AppMgr.Instance.StartActivity("com.example.app", "com.example.app.MainActivity");
// Set application keep-alive
AppMgr.Instance.SetAppKeepAlive("com.example.app", true);

// Silent install application
AppMgr.Instance.SilentInstall("/sdcard/Download/example.apk", result => Debug.Log(result));

// Launch WiFi settings UI
AppMgr.Instance.StartWifiUI();
```
