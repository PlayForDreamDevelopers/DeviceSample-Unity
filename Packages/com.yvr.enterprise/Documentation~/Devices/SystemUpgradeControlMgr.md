# SystemUpgradeControlMgr

> [!note]
>
> SystemUpgradeControlMgr is used for system upgrade related management.

## Main Interfaces

| Interface/Property                        | Description                              |
| -------------------------------- | --------------------------------- |
| `isSystemUpgradeEnable`          | Get/Set whether the system upgrade function is enabled     |
| `isSystemAutomaticUpgradeEnable` | Get/Set whether the system automatic upgrade function is enabled |

## Example

```csharp
// Enable system upgrade
SystemUpgradeControlMgr.Instance.isSystemUpgradeEnable = true;

// Disable automatic upgrade
SystemUpgradeControlMgr.Instance.isSystemAutomaticUpgradeEnable = false;
```
