# DeviceControlMgr

> [!note]
>
> DeviceControlMgr is used for device power and screen-related control operations.

## Main Interfaces

| Interface           | Description         |
| ------------------- | ------------------ |
| `Shutdown()`        | Power off device   |
| `Reboot()`          | Reboot device      |
| `SetScreenOff()`    | Turn off screen    |
| `SetScreenOn()`     | Turn on screen     |

## Example

```csharp
// Reboot device
DeviceControlMgr.Instance.Reboot();

// Turn off screen
DeviceControlMgr.Instance.SetScreenOff();
```
