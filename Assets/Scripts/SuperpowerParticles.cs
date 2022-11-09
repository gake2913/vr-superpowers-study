using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class SuperpowerParticles : MonoBehaviour
{

    public Material ControllerGlowMaterial;

    private bool lastActive = false;
    private float materialAlpha;

    // Start is called before the first frame update
    void Start()
    {
        materialAlpha = ControllerGlowMaterial.GetFloat("_Alpha");
        ControllerGlowMaterial.SetFloat("_Alpha", 0);
    }

    // Update is called once per frame
    void Update()
    {
        bool currentlyActive = PowersManager.instance.PowerActive;

        if (currentlyActive && !lastActive)
        {
            ControllerGlowMaterial.SetFloat("_Alpha", materialAlpha);
        }

        if (!currentlyActive && lastActive)
        {
            ControllerGlowMaterial.SetFloat("_Alpha", 0);
        }

        lastActive = currentlyActive;
    }
}
