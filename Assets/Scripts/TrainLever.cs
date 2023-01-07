using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TrainLever : MonoBehaviour
{

    public float LowerLimit = -45f;
    public float UpperLimit = 45f;

    public float LowerValue = -1f;
    public float UpperValue = 1f;

    public TrainSpline Train;

    private Transform hand;
    private bool grabbed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        float rot = transform.localRotation.eulerAngles.x;
        if (rot > 180) rot -= 360;

        float leverTo01 = Mathf.InverseLerp(LowerLimit, UpperLimit, rot);
        float value = Mathf.Lerp(LowerValue, UpperValue, leverTo01);

        //Debug.Log(rot + "; " + leverTo01 + "; " + value);

        Train.SetSpeedModifier(value);
    }

    public void Grab()
    {
        hand = GetComponent<XRGrabInteractable>().attachTransform;
        grabbed = true;
    }

    public void Detach()
    {
        grabbed = false;
    }
}
