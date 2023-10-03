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
    private bool isFlying;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerMain" || collision.gameObject.tag == "Sticky")
        {
            RocketDestroyed = true;
            isFlying = false;
            RocketBlowUp.Play();
            RocketBody.enabled = false;
            Trail.enableEmission = false;
            Destroy(gameObject, 1f);
        }
    }

    void Update()
    {
        if (isFlying)
        { FlyRocket(); }
    }
    public void FlyRocket()
    {
        isFlying = true;
        if (!RocketDestroyed)
        {
            this.gameObject.transform.Translate(0.4f * Speed * Time.deltaTime, 0, 0, Space.Self);
        }
    }
      
}
