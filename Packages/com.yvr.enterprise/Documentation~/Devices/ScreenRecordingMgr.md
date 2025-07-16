# ScreenRecordingMgr

> [!note]
>
> ScreenRecordingMgr is used for screen recording control.

## Main Interfaces

| Interface                  | Description         |
| --------------------- | ------------ |
| `StartRecordScreen()` | Start screen recording |
| `StopRecordScreen()`  | Stop screen recording |

## Example

```csharp
// Start screen recording
ScreenRecordingMgr.Instance.StartRecordScreen();

// Stop screen recording
ScreenRecordingMgr.Instance.StopRecordScreen();
```
