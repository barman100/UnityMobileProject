using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CrateScript : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D bc2d;
    public event Action HitEvent;
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            HitEvent?.Invoke();
        }
    }
}
