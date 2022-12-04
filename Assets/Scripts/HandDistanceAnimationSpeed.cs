using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandDistanceAnimationSpeed : MonoBehaviour
{

    public Transform RightHand;
    public Transform Body;

    public float MinDistance = 0.2f;
    public float MaxDistance = 0.7f;

    private TrainSpline trainSpline;

    // Start is called before the first frame update
    void Start()
    {
        trainSpline = GetComponent<TrainSpline>();
    }

    // Update is called once per frame
    void Update()
    {
        trainSpline.SpeedModifier = ((RightHand.position - Body.position).magnitude - MinDistance) / (MaxDistance - MinDistance);
    }
}
