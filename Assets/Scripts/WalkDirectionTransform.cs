using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkDirectionTransform : MonoBehaviour
{

    public GameObject HandDirect, HandRay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform use = HandDirect.transform;
        if (!HandDirect.activeSelf) use = HandRay.transform;

        transform.position = use.position;
        transform.rotation = use.rotation;
    }
}
