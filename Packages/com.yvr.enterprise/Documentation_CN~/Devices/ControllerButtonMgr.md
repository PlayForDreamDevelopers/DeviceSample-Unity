# 手柄按键管理

> [!note]
>
> ControllerButtonMgr 用于管理手柄按键的使能与禁用，以及相关事件回调。

## 主要接口

| 接口                                                              | 说明                        |
| ----------------------------------------------------------------- | --------------------------- |
| `SetControllerButtons(ControllerButtonMask mask, bool forbidden)` | 设置指定按键的使能/禁用状态 |
| `GetControllerButtonEnableState(ControllerButtonMask mask)`       | 获取指定按键当前是否可用    |
| `RemoveTrackingKeyEventCallback()`                                | 移除按键事件回调            |

## 示例

```csharp
// 禁用某个按键
ControllerButtonMgr.Instance.SetControllerButtons(ControllerButtonMask.Menu, true);

// 查询按键状态
bool isEnabled = ControllerButtonMgr.Instance.GetControllerButtonEnableState(ControllerButtonMask.Menu);
```
