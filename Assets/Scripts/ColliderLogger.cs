using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColliderLogger : MonoBehaviour
{

    public UnityEvent OnPlayerEntered = new UnityEvent();

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

            OnPlayerEntered.Invoke();
        }
    }
}
