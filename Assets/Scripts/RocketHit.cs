using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class RocketHit : MonoBehaviour
{
    public float Speed = 1;
    [SerializeField] ParticleSystem RocketBlowUp;
    [SerializeField] SpriteRenderer RocketBody;
    [SerializeField] ParticleSystem Trail;
    [SerializeField] public TurretDetect turretDetRef;

    private bool RocketDestroyed = false;
    public bool isFlying = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerMain" || collision.gameObject.tag == "Sticky")
        {
            RocketDestroyed = true;
            isFlying = false;
            RocketBlowUp.Play();
            RocketBody.enabled = false;
            Trail.enableEmission = false;
            Destroy(transform.parent.gameObject, 1f);
        }
    }

    void Update()
    {
        if (isFlying)
        {
            if (!RocketDestroyed)
            {
                transform.parent.transform.position += transform.right * Speed * Time.deltaTime;
            }
        }
    }

    public void IgniteThrusters()
    {
        isFlying = true;
        Trail.Play();
        Destroy(transform.parent,20f);
    }
}
