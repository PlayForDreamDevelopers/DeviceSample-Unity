using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using YVR.Core;
using YVR.Enterprise.Device;
using YVR.Interaction.Runtime;

public class ControllerButtonControl : MonoBehaviour
{
    public GameObject keyInputInfoPrefab;
    public Transform keyInputInfoContainer;
    public Toggle isDebugTriggerInfo; //Turn off DebugTriggerInfo for easy access to information
    public List<ControlKey> Keys;
    private YVRInputActions m_InputActions;
    private void Start()
    {
        YVRManager.instance.hmdManager.SetPassthrough(true);
        KeyAddListener();
        isDebugTriggerInfo.onValueChanged.AddListener((value) =>
        {
            if (value)
            {
                m_InputActions.YVRLeft.Trigger.performed += CreateKeyInputInfo; // KEY_LEFT_TRIGGER
                m_InputActions.YVRRight.Trigger.performed += CreateKeyInputInfo; // KEY_RIGHT_TRIGGER
            }
            else
            {
                m_InputActions.YVRLeft.Trigger.performed -= CreateKeyInputInfo; // KEY_LEFT_TRIGGER
                m_InputActions.YVRRight.Trigger.performed -= CreateKeyInputInfo; // KEY_RIGHT_TRIGGER
            }
        });
    }

    
    private void OnEnable()
    {
        m_InputActions = new YVRInputActions();
        m_InputActions.Enable();
        AddListenersInputInfo();
        
    }

    private void AddListenersInputInfo()
    {
        m_InputActions.YVRRight.PrimaryButton.performed += CreateKeyInputInfo;//KEY_A
        m_InputActions.YVRRight.SecondaryButton.performed += CreateKeyInputInfo;// KEY_B
        m_InputActions.YVRLeft.PrimaryButton.performed += CreateKeyInputInfo;//KEY_X
        m_InputActions.YVRLeft.SecondaryButton.performed += CreateKeyInputInfo;// KEY_Y
        m_InputActions.YVRRight.Meun.performed += CreateKeyInputInfo;// KEY_MENU
        m_InputActions.YVRLeft.Meun.performed += CreateKeyInputInfo;// KEY_HOME
        m_InputActions.YVRLeft.Trigger.performed += CreateKeyInputInfo; // KEY_LEFT_TRIGGER
        m_InputActions.YVRRight.Trigger.performed += CreateKeyInputInfo; // KEY_RIGHT_TRIGGER
        m_InputActions.YVRLeft.Grip.performed += CreateKeyInputInfo;// KEY_LEFT_SIDE_TRIGGER
        m_InputActions.YVRRight.Grip.performed += CreateKeyInputInfo;// KEY_RIGHT_SIDE_TRIGGER
        m_InputActions.YVRLeft.ThumbStickClick.performed += CreateKeyInputInfo; // KEY_LEFT_THUMBSTICK
        m_InputActions.YVRLeft.ThumbStickUp.performed += CreateKeyInputInfo;
        m_InputActions.YVRLeft.ThumbStickDown.performed += CreateKeyInputInfo;
        m_InputActions.YVRLeft.ThumbStickLeft.performed += CreateKeyInputInfo;
        m_InputActions.YVRLeft.ThumbStickRight.performed += CreateKeyInputInfo;
        m_InputActions.YVRRight.ThumbStickClick.performed += CreateKeyInputInfo;// KEY_RIGHT_THUMBSTICK
        m_InputActions.YVRRight.ThumbStickUp.performed += CreateKeyInputInfo;
        m_InputActions.YVRRight.ThumbStickDown.performed += CreateKeyInputInfo;
        m_InputActions.YVRRight.ThumbStickLeft.performed += CreateKeyInputInfo;
        m_InputActions.YVRRight.ThumbStickRight.performed += CreateKeyInputInfo;
        
    }
    public void CreateKeyInputInfo(InputAction.CallbackContext context)
    {
        TMP_Text info = Instantiate(keyInputInfoPrefab, keyInputInfoContainer,false).GetComponent<TMP_Text>();
        info.text = $"info: {context.action} has just been pressed" ;
    }
    private void OnDisable()
    {
        m_InputActions.Disable();
    }

    public void KeyAddListener()
    {
        foreach (ControlKey controlKey in Keys)
        {
            controlKey.enabled = ControllerButtonMgr.instance.GetControllerButtonEnableState(controlKey.mask);
            controlKey.ChangeColor();
            controlKey.keyControlButton.onClick.AddListener(() =>
            {
                ControllerButtonMgr.instance.SetControllerButtons(controlKey.mask, controlKey.enabled);
                controlKey.enabled = !controlKey.enabled;
                controlKey.ChangeColor();
            });
        }
    }

    
}
