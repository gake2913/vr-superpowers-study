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
                Shrink();
            }
        }
        
        if (Head.localPosition.y > GrowHeadAbove)
        {
            float handAbove = Head.localPosition.y + HandHeadDifference;
            if (LeftHand.localPosition.y > handAbove && RightHand.localPosition.y > handAbove)
            {
                Grow();
            }
        }
    }

    private void Shrink()
    {
        if (triggerLocked) return;

        if (currentSize == BigSize)
        {
            // Shrink to 1
            StartCoroutine(SizeChangeAnimation(1));
        }

        if (currentSize == 1)
        {
            // shrink to small size
            StartCoroutine(SizeChangeAnimation(SmallSize));
        }
    }

    private void Grow()
    {
        if (triggerLocked) return;

        if (currentSize == SmallSize)
        {
            // grow to 1
            StartCoroutine(SizeChangeAnimation(1));
        }

        if (currentSize == 1)
        {
            // grow to big size
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

            float scale = Mathf.Lerp(currentSize, target, AnimationCurve.Evaluate(t));
            transform.localScale = Vector3.one * scale;
        }

        transform.localScale = Vector3.one * target;
        currentSize = target;
        triggerLocked = false;
    }
}