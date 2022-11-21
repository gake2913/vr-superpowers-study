using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerActivator : MonoBehaviour
{

    public Transform Camera;
    public Transform LeftController;

    public Material SeeThroughMaterial;

    public float MaxAngle = 45f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 controllerDir = LeftController.position - Camera.position;
        Vector3 camForward = Camera.forward;
        //camForward.y = 0;
        float angle = Vector3.Angle(camForward, controllerDir);

        PowersManager.instance.PowerActive = angle < MaxAngle;
        
        Color seeThrough = SeeThroughMaterial.color;
        seeThrough.a = 1f - Mathf.Min(1, angle / MaxAngle);
        SeeThroughMaterial.color = seeThrough;
    }
}
