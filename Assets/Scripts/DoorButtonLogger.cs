using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorButtonLogger : MonoBehaviour
{

    public int RoomNumber;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<XRSimpleInteractable>().firstHoverEntered.AddListener((args) =>
        {
            Logger.CreateLog("Button in Room " + RoomNumber + " was pressed by " + args.interactorObject.transform.name + ".", this);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
