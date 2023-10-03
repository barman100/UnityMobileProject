using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventScript : MonoBehaviour
{
    public event Action NotStuck; // non stickble surface
    public event Action Hit; // Box, Spikes, Axe, Mines, Missile
    public event Action Slowed; // Slowed Surface

    public static void StartDeathEvent()
    {
     //Hit?.Invoke();
     Debug.Log("hit");
    }
    public static void StartNotStuckEvent()
    {
        //NotStuck?.Invoke();
        Debug.Log("Player Can't Stick");
    }
    public static void StartSlowedEvent()
    {
        //Slowed?.Invoke();
        Debug.Log("Plauer Is Slowed");
    }
}

