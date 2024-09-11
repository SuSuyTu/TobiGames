using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHandOnInut : MonoBehaviour
{
    [SerializeField] protected InputActionProperty pinchAnimationAction;
    [SerializeField] protected InputActionProperty gripAnimationAction;

    [SerializeField] protected Animator handAnimator;

    private float triggerValue;
    private float gripValue;

    protected virtual void Update()
    {
        triggerValue = pinchAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Trigger", triggerValue);

        gripValue = gripAnimationAction.action.ReadValue<float>();
        handAnimator.SetFloat("Grip", gripValue);
    }
}
