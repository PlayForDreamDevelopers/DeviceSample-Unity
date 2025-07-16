# 设备信息管理

> [!note]
>
> DeviceInfoMgr 用于获取设备的基本信息、蓝牙/WiFi 状态、电池等信息。

## 主要接口

| 接口/属性                                         | 说明                               |
| ------------------------------------------------- | ---------------------------------- |
| `deviceSn`                                        | 获取设备序列号                     |
| `deviceModel`                                     | 获取设备型号                       |
| `osVersion`                                       | 获取操作系统版本                   |
| `IsBtOn(Action<bool> callback = null)`            | 查询蓝牙是否开启（可选回调）       |
| `btMac`                                           | 获取蓝牙 MAC 地址                  |
| `BTNameConnected(Action<string> callback = null)` | 获取已连接蓝牙设备名称（可选回调） |
| `IsWifiOn(Action<bool> callback = null)`          | 查询 WiFi 是否开启（可选回调）     |
| `wifiMac`                                         | 获取 WiFi MAC 地址                 |
| `IsDeviceWorn(Action<bool> callback = null)`      | 查询设备是否被佩戴（可选回调）     |
| `storageInfo`                                     | 获取存储信息                       |
| `GetDeviceBattery(Action<int> callback = null)`   | 获取设备电量（可选回调）           |
| `IsDeviceCharging(Action<bool> callback = null)`  | 查询设备是否正在充电（可选回调）   |

## 示例

```csharp
// 获取设备序列号
string sn = DeviceInfoMgr.Instance.deviceSn;

// 查询蓝牙状态
DeviceInfoMgr.Instance.IsBtOn(result => Debug.Log($"蓝牙状态: {result}"));
```
