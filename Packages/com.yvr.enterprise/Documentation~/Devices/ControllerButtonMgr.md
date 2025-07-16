# ControllerButtonMgr

> [!note]
>
> ControllerButtonMgr is used to manage the enable/disable state of controller buttons and related event callbacks.

## Main Interfaces

| Interface                                                              | Description                        |
| ----------------------------------------------------------------- | --------------------------- |
| `SetControllerButtons(ControllerButtonMask mask, bool forbidden)` | Set the enable/disable state of the specified button |
| `GetControllerButtonEnableState(ControllerButtonMask mask)`       | Get whether the specified button is currently enabled    |
| `RemoveTrackingKeyEventCallback()`                                | Remove button event callback            |

## Example

```csharp
// Disable a button
ControllerButtonMgr.Instance.SetControllerButtons(ControllerButtonMask.Menu, true);

// Query button state
bool isEnabled = ControllerButtonMgr.Instance.GetControllerButtonEnableState(ControllerButtonMask.Menu);
```
