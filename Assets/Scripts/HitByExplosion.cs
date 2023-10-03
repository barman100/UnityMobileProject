using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HitByExplosion : MonoBehaviour
{
    public event Action HitEvent;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            HitEvent?.Invoke();
            Debug.Log("Hit By Explosedsds");
        }
    }
}
