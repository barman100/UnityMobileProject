using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SlowDownSurface : MonoBehaviour
{
    public event Action SlowedDown;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            SlowedDown?.Invoke();
        }
    }
}
