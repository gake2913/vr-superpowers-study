using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowersManager : MonoBehaviour
{
    
    public static PowersManager instance;

    public bool PowerActive = false;

    private void Start()
    {
        instance = this;
    }

    /*public void PowerActive(PowerColors color)
    {
        switch (color)
        {
            case PowerColors.Red: RedActive = true; break;
            case PowerColors.Yellow: YellowActive = true; break;
            case PowerColors.Green: GreenActive = true; break;
            case PowerColors.Blue: BlueActive = true; break;
            case PowerColors.Teal: TealActive = true; break;
        }
    }

    public void PowerInactive(PowerColors color)
    {
        switch (color)
        {
            case PowerColors.Red: RedActive = false; break;
            case PowerColors.Yellow: YellowActive = false; break;
            case PowerColors.Green: GreenActive = false; break;
            case PowerColors.Blue: BlueActive = false; break;
            case PowerColors.Teal: TealActive = false; break;
        }
    }

    public void PowerSet(PowerColors color, bool value)
    {
        switch (color)
        {
            case PowerColors.Red: RedActive = value; break;
            case PowerColors.Yellow: YellowActive = value; break;
            case PowerColors.Green: GreenActive = value; break;
            case PowerColors.Blue: BlueActive = value; break;
            case PowerColors.Teal: TealActive = value; break;
        }
    }

    public bool GetPowerActive(PowerColors color)
    {
        switch (color)
        {
            case PowerColors.Red: return RedActive;
            case PowerColors.Yellow: return YellowActive;
            case PowerColors.Green: return GreenActive;
            case PowerColors.Blue: return BlueActive;
            case PowerColors.Teal: return TealActive;
        }

        return false;
    }*/

}
