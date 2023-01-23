using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.XR;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class SizeChangerContinuous : MonoBehaviour
{

    public float SmallSize = 0.5f;
    public float BigSize = 1.5f;

    public Transform Head, LeftHand, RightHand;

    [SerializeField]
    public InputActionProperty LeftGrip, RightGrip;

    private float currentSize = 1;

    private bool bothGripsPressed = false;
    private Vector3 startMiddlePosition;
    private Vector3 currentMiddlePosition;
    private float currentDistance = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool lastPressed = bothGripsPressed;
        bothGripsPressed = false;

        if (isPressed(LeftGrip.action) && isPressed(RightGrip.action))
        {
            bothGripsPressed = true;

            if (!lastPressed)
            {
                // First Frame with both pressed
                startMiddlePosition = HandMiddle();
            }

            currentMiddlePosition = HandMiddle();
            currentDistance = currentMiddlePosition.y - startMiddlePosition.y;

            float sizeChange = currentDistance * 0.5f * Time.deltaTime;
            currentSize += sizeChange;

            if (currentSize < SmallSize)
            {
                currentSize = SmallSize;
                sizeChange = 0;
            }

            if (currentSize > BigSize)
            {
                currentSize = BigSize;
                sizeChange = 0;
            }

            transform.localScale = Vector3.one * currentSize;

            Vector3 correction = (Head.position - transform.position) * (sizeChange / 2f);
            correction.y = 0;
            transform.position -= correction;
        }
    }

    private Vector3 HandMiddle()
    {
        Vector3 to = RightHand.localPosition - LeftHand.localPosition;
        return LeftHand.position + to * 0.5f;
    }

    private void OnDrawGizmos()
    {
        if (bothGripsPressed)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(startMiddlePosition, 0.02f);
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(currentMiddlePosition, 0.02f);
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(LeftHand.localPosition, RightHand.localPosition);
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(startMiddlePosition, startMiddlePosition + Vector3.up * currentDistance);
        }
    }

    // Code from ActionBasedController in XR Toolkit
    private bool isPressed(InputAction action)
    {
#if INPUT_SYSTEM_1_1_OR_NEWER || INPUT_SYSTEM_1_1_PREVIEW // 1.1.0-preview.2 or newer, including pre-release
                return action.phase == InputActionPhase.Performed;
#else
        if (action.activeControl is ButtonControl buttonControl)
            return buttonControl.isPressed;

        if (action.activeControl is AxisControl)
            return action.ReadValue<float>() >= 0.7;

        return action.triggered || action.phase == InputActionPhase.Performed;
    }
#endif
}
