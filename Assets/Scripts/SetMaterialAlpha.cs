using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMaterialAlpha : MonoBehaviour
{

    public Material Material;
    public float Alpha = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        Color color = Material.color;
        color.a = Alpha;
        Material.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
