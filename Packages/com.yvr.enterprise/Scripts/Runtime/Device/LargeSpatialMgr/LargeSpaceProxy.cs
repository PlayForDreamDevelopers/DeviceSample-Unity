using System;
using UnityEngine;
using YVR.Utilities;

public class LargeSpaceProxy : AndroidJavaProxy
{
    private Action<bool> m_SwitchResult = null;

    public LargeSpaceProxy(Action<bool> action) : base("java.util.function.Consumer") { m_SwitchResult = action; }

    public void accept(bool result)
    {
        this.Info($"LargeSpatial SwitchLargeSpaceProxy result:{result}");
        m_SwitchResult?.Invoke(result);
    }
}