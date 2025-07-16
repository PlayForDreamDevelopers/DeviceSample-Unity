# 设备管理

> [!note]
>
> DeviceControlMgr 用于设备电源与屏幕相关的控制操作。

## 主要接口

| 接口             | 说明         |
| ---------------- | ------------ |
| `Shutdown()`     | 关闭设备电源 |
| `Reboot()`       | 重启设备     |
| `SetScreenOff()` | 熄灭屏幕     |
| `SetScreenOn()`  | 点亮屏幕     |

## 示例

```csharp
// 重启设备
DeviceControlMgr.Instance.Reboot();

// 熄灭屏幕
DeviceControlMgr.Instance.SetScreenOff();
```
