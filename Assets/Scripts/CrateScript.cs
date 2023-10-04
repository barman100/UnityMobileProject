using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CrateScript : MonoBehaviour
{
    [SerializeField]
    private BoxCollider2D bc2d;
    [SerializeField] Rigidbody2D rb;

    public event Action HitEvent;


    private RigidbodyConstraints2D StoredConstraints;

    private void Start()
    {
        StoredConstraints = rb.constraints;
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            rb.constraints = StoredConstraints;
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            HitEvent?.Invoke();
        }
    }
}
