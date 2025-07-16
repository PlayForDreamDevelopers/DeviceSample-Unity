# 录屏管理

> [!note]
>
> ScreenRecordingMgr 用于屏幕录制的控制。

## 主要接口

| 接口                  | 说明         |
| --------------------- | ------------ |
| `StartRecordScreen()` | 开始录制屏幕 |
| `StopRecordScreen()`  | 停止录制屏幕 |

## 示例

```csharp
// 开始录屏
ScreenRecordingMgr.Instance.StartRecordScreen();

// 停止录屏
ScreenRecordingMgr.Instance.StopRecordScreen();
```
