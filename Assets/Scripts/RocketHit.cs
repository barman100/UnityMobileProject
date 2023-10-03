using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketHit : MonoBehaviour
{
    [SerializeField] ParticleSystem RocketBlowUp;
    [SerializeField] SpriteRenderer RocketBody;
    [SerializeField] ParticleSystem Trail;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("What?");
        RocketBlowUp.Play();
        RocketBody.enabled = false;
        Trail.enableEmission = false;
        Destroy(gameObject, 1f);
    }
}
