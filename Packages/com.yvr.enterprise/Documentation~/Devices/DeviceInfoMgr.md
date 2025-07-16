# DeviceInfoMgr

> [!note]
>
> DeviceInfoMgr is used to obtain basic device information, Bluetooth/WiFi status, battery, and other information.

## Main Interfaces

| Interface/Property                                         | Description                               |
| ------------------------------------------------- | ---------------------------------- |
| `deviceSn`                                        | Get device serial number                     |
| `deviceModel`                                     | Get device model                       |
| `osVersion`                                       | Get operating system version                   |
| `IsBtOn(Action<bool> callback = null)`            | Query whether Bluetooth is enabled (optional callback)       |
| `btMac`                                           | Get Bluetooth MAC address                  |
| `BTNameConnected(Action<string> callback = null)` | Get the name of the connected Bluetooth device (optional callback) |
| `IsWifiOn(Action<bool> callback = null)`          | Query whether WiFi is enabled (optional callback)     |
| `wifiMac`                                         | Get WiFi MAC address                 |
| `IsDeviceWorn(Action<bool> callback = null)`      | Query whether the device is being worn (optional callback)     |
| `storageInfo`                                     | Get storage information                       |
| `GetDeviceBattery(Action<int> callback = null)`   | Get device battery level (optional callback)           |
| `IsDeviceCharging(Action<bool> callback = null)`  | Query whether the device is charging (optional callback)   |

## Example

```csharp
// Get device serial number
string sn = DeviceInfoMgr.Instance.deviceSn;

// Query Bluetooth status
DeviceInfoMgr.Instance.IsBtOn(result => Debug.Log($"Bluetooth status: {result}"));
```
