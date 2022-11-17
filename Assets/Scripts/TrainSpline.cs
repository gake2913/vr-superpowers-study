using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainSpline : MonoBehaviour
{

    public Spline2DComponent Spline;
    public float Speed = 0.2f;
    public float SpeedModifier = 1f;
    public float Offset = 0;
    public TrainSpline[] SyncSpeedModifierWith;

    private float splinePos = 0;
    private Vector3 lastPos;

    // Start is called before the first frame update
    void Start()
    {
        lastPos = Spline.InterpolateDistanceWorldSpace(splinePos);
        PlaceOnSpline();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (TrainSpline ts in SyncSpeedModifierWith)
        {
            ts.SpeedModifier = SpeedModifier;   
        }

        splinePos += Speed * SpeedModifier * Time.deltaTime;

        PlaceOnSpline();
    }

    private void PlaceOnSpline()
    {
        float modPos = (splinePos - Offset) % Spline.Length;
        if (modPos < 0) modPos += Spline.Length;

        transform.position = Spline.InterpolateDistanceWorldSpace(modPos);

        Vector3 travelDirection = transform.position - lastPos;
        if (travelDirection != Vector3.zero)
        {
            Quaternion rot = Quaternion.LookRotation(travelDirection, transform.up);
            transform.rotation = rot;
        }

        lastPos = transform.position;
    }

    public void SetSpeedModifier(float value)
    {
        SpeedModifier = value;
    }
}
