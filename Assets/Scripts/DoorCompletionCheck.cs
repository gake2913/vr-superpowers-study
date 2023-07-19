using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorCompletionCheck : MonoBehaviour
{

    public ActivatableLamp[] Lamps;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateLamp(int num)
    {
        Lamps[num].Activate();

        if (checkAllActive())
        {
            anim.SetTrigger("Open");
            Logger.CreateLog("");
            Logger.CreateLog("### All Buttons are activated. ###", this);
            Logger.CreateLog("");
        }
    }

    private bool checkAllActive()
    {
        foreach (ActivatableLamp lamp in Lamps)
        {
            if (!lamp.isActive()) return false;
        }

        return true;
    }
}
