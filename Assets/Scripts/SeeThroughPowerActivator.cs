using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeThroughPowerActivator : MonoBehaviour
{

    public Transform Camera;
    public Transform LeftController;

    public Material SeeThroughMaterial;
    public LayerMask SeeThroughLayerMask;

    public float MaxAngle = 15f;

    public AnimationCurve AlphaFalloff;

    [Space]
    public bool ShowDebug = false;

    private GameObject[] seeThroughObjects;
    private int seeThroughLayer;

    // Start is called before the first frame update
    void Start()
    {
        seeThroughObjects = Helping.FindGameObjectsInLayer(SeeThroughLayerMask);

        foreach(GameObject obj in seeThroughObjects)
        {
            seeThroughLayer = obj.layer;
            obj.layer = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        GameObject nearest = null;
        float bestAngle = float.MaxValue;

        foreach (GameObject obj in seeThroughObjects)
        {
            obj.layer = 0;

            Vector3 controllerDir = LeftController.position - Camera.position;
            Vector3 camToObject = obj.transform.position - Camera.position;

            float angle = Vector3.Angle(camToObject, controllerDir);

            if (angle < bestAngle)
            {
                bestAngle = angle;
                nearest = obj;
            }
        }

        if (ShowDebug)
        {
            Debug.Log(bestAngle);
            nearestSave = nearest;
        }

        PowersManager.instance.PowerActive = false;
        if (bestAngle <= MaxAngle)
        {
            PowersManager.instance.PowerActive = true;
            nearest.layer = seeThroughLayer;

            Color seeThrough = SeeThroughMaterial.color;
            seeThrough.a = AlphaFalloff.Evaluate(1f - Mathf.Min(1, bestAngle / MaxAngle));
            SeeThroughMaterial.color = seeThrough;

            Debug.Log(bestAngle + "; " + seeThrough.a + "; " + LayerMask.LayerToName(nearest.layer));
        }
    }

    private GameObject nearestSave;
    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;

        if (!ShowDebug) return;

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(Camera.position, LeftController.position - Camera.position);

        foreach(GameObject obj in seeThroughObjects)
        {
            if (obj == nearestSave) Gizmos.color = Color.green;
            else Gizmos.color = Color.red;

            Gizmos.DrawRay(Camera.position, obj.transform.position - Camera.position);
        }
    }
}
