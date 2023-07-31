using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderLogger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Logger.CreateLog("### Player has entered the Ending Room. ###");
            StudyLevelManagement.stopTimer();
        }
    }
}
