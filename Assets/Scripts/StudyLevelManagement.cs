using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StudyLevelManagement : MonoBehaviour
{

    public SizeChangerContinuous SizeChanger;

    public GameObject[] OnlyC1Objects, OnlyC23Objects;
    public GameObject PrepRoom;
    public GameObject LeftHandDirect, LeftHandRay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            // ### C1 ###

            SizeChanger.enabled = true;

            LeftHandDirect.SetActive(true);
            LeftHandRay.SetActive(false);

            // hide C2 and C3 Objects
            foreach (GameObject obj in OnlyC23Objects)
            {
                obj.SetActive(false);
            }

            // show C1 Objects
            foreach (GameObject obj in OnlyC1Objects) 
            { 
                obj.SetActive(true); 
            }

            Logger.CreateLog("### Loaded configuration C1. ###");
        }
        
        if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            // ### C2 ###

            SizeChanger.enabled = false;

            LeftHandDirect.SetActive(true);
            LeftHandRay.SetActive(false);

            // hide C1 Objects
            foreach (GameObject obj in OnlyC1Objects)
            {
                obj.SetActive(false);
            }

            // show C2 and C3 Objects
            foreach (GameObject obj in OnlyC23Objects)
            {
                obj.SetActive(true);
            }

            Logger.CreateLog("### Loaded configuration C2. ###");
        }

        if (Keyboard.current.digit3Key.wasPressedThisFrame)
        {
            // ### C3 ###

            SizeChanger.enabled = false;

            LeftHandDirect.SetActive(false);
            LeftHandRay.SetActive(true);

            // hide C1 Objects
            foreach (GameObject obj in OnlyC1Objects)
            {
                obj.SetActive(false);
            }

            // show C2 and C3 Objects
            foreach (GameObject obj in OnlyC23Objects)
            {
                obj.SetActive(true);
            }

            Logger.CreateLog("### Loaded configuration C3. ###");
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            PrepRoom.SetActive(false);
            Logger.CreateLog("### Started task. ###");
            Logger.CreateLog("");
        }

    }
}
