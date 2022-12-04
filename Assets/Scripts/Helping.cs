using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helping
{
    public static GameObject[] FindGameObjectsInLayer(LayerMask layerMask)
    {
        GameObject[] gameObjects = GameObject.FindObjectsOfType<GameObject>();
        List<GameObject> list = new List<GameObject>();

        foreach (GameObject go in gameObjects)
        {
            //Debug.Log(go.name + ": " + go.layer);
            if (layerMask.Contains(go.layer))
            {
                list.Add(go);
            }
        }

        if (list.Count == 0)
        {
            return null;
        }

        return list.ToArray();
    }
}

public static class UnityExtensions
{

    /// <summary>
    /// Extension method to check if a layer is in a layermask
    /// </summary>
    /// <param name="mask"></param>
    /// <param name="layer"></param>
    /// <returns></returns>
    public static bool Contains(this LayerMask mask, int layer)
    {
        return mask == (mask | (1 << layer));
    }
}
