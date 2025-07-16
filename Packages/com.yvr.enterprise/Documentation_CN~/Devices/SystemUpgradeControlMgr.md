# 系统升级管理

> [!note]
>
> SystemUpgradeControlMgr 用于系统升级相关的开关管理。

## 主要接口

| 接口/属性                        | 说明                              |
| -------------------------------- | --------------------------------- |
| `isSystemUpgradeEnable`          | 获取/设置系统升级功能是否启用     |
| `isSystemAutomaticUpgradeEnable` | 获取/设置系统自动升级功能是否启用 |

## 示例

```csharp
// 启用系统升级
SystemUpgradeControlMgr.Instance.isSystemUpgradeEnable = true;

// 禁用自动升级
SystemUpgradeControlMgr.Instance.isSystemAutomaticUpgradeEnable = false;
```
