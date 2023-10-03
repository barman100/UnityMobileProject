using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using System;

public class Impailed : MonoBehaviour
{

    public event Action HitEvent;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            HitEvent?.Invoke();
        }
    }
    
}
