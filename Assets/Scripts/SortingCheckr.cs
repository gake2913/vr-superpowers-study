using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingCheckr : MonoBehaviour
{

    public static List<GameObject> SortedBalls = new List<GameObject>();
    public static int CorrectSorts = 0;
    public static int WrongSorts = 0;

    public LayerMask AllSortingLayers;
    public LayerMask CorrectLayer;

    public Animator Lightbar;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckCollision(Collider collision)
    {
        if ((CorrectLayer.value & (1 << collision.gameObject.layer)) > 0)
        {
            // correct Ball inserted
            if (!SortedBalls.Contains(collision.gameObject))
            {
                SortedBalls.Add(collision.gameObject);
                Lightbar.SetTrigger("Pulse_Green");
                CorrectSorts++;
                Logger.CreateLog("Ball sorted correctly. Correct Sorts: " + CorrectSorts + ". Wrong Sorts: " + WrongSorts);
            }
        }
        else
        {
            // wrong Ball inserted
            Lightbar.SetTrigger("Pulse_Red");
            WrongSorts++;
            Logger.CreateLog("Ball not sorted correctly. Correct Sorts: " + CorrectSorts + ". Wrong Sorts: " + WrongSorts);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        //Debug.Log("Collision");

        if ((AllSortingLayers.value & (1 << collision.gameObject.layer)) > 0)
        {
            CheckCollision(collision);
        }
    }
}
