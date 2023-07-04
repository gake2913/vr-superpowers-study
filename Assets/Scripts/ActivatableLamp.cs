using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatableLamp : MonoBehaviour
{

    public Material greenMaterial;

    [SerializeField]
    private bool state;
    private MeshRenderer meshRenderer;
    private new Light light;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        light = GetComponentInChildren<Light>();
    }

    public void Activate()
    {
        state = true;
        meshRenderer.sharedMaterial = greenMaterial;
        light.color = Color.green;
    }

    public bool isActive()
    {
        return state;
    }

}
