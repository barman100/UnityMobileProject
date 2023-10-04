using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using System;

public class Impailed : MonoBehaviour
{
    [SerializeField] AudioSource ImpailedSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            ImpailedSound.Play();
        }
    }

}
