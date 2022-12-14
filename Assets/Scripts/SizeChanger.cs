using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeChanger : MonoBehaviour
{

    public float SmallSize = 0.5f;
    public float BigSize = 1.5f;

    public float ShrinkHeadBelow = 0.9f;
    public float GrowHeadAbove = 1.7f;
    public float HandHeadDifference = 0.2f;

    public float AnimationSpeed = 1.0f;
    public AnimationCurve AnimationCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);

    public Transform Head, LeftHand, RightHand;

    private float currentSize = 1;
    private bool triggerLocked = false;

    private bool shrinking = false;
    private bool growing = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Head.localPosition.y < ShrinkHeadBelow)
        {
            float handBelow = Head.localPosition.y - HandHeadDifference;
            if (LeftHand.localPosition.y < handBelow && RightHand.localPosition.y < handBelow)
            {
                shrinking = true;
                Shrink();
            }
            else shrinking = false;
        }
        else shrinking = false;
        
        if (Head.localPosition.y > GrowHeadAbove)
        {
            float handAbove = Head.localPosition.y + HandHeadDifference;
            if (LeftHand.localPosition.y > handAbove && RightHand.localPosition.y > handAbove)
            {
                growing = true;
                Grow();
            }
            else growing = false;
        }
        else growing = false;
    }

    private void Shrink()
    {
        if (triggerLocked) return;

        /*if (currentSize == BigSize)
        {
            // Shrink to 1
            Logger.CreateLog("Changing size to Normal");
            StartCoroutine(SizeChangeAnimation(1));
        }*/

        if (currentSize == 1)
        {
            // shrink to small size
            Logger.CreateLog("Changing size to Small");
            StartCoroutine(SizeChangeAnimation(SmallSize));
        }
    }

    private void Grow()
    {
        if (triggerLocked) return;

        /*if (currentSize == SmallSize)
        {
            // grow to 1
            Logger.CreateLog("Changing size to Normal");
            StartCoroutine(SizeChangeAnimation(1));
        }*/

        if (currentSize == 1)
        {
            // grow to big size
            Logger.CreateLog("Changing size to Big");
            StartCoroutine(SizeChangeAnimation(BigSize));
        }
    }

    private IEnumerator SizeChangeAnimation(float target)
    {
        triggerLocked = true;

        float t = 0;
        while (t < 1)
        {
            yield return new WaitForEndOfFrame();
            t += Time.deltaTime / AnimationSpeed;

            if (!growing && !shrinking) break;

            float scale = Mathf.Lerp(currentSize, target, AnimationCurve.Evaluate(t));
            transform.localScale = Vector3.up * scale;
        }

        transform.localScale = Vector3.up * target;
        currentSize = target;
        triggerLocked = false;
    }
}
