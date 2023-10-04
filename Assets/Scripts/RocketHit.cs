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
    [SerializeField] private Collider2D _explosion;
       

    private bool RocketDestroyed = false;
    public bool isFlying = false;
    public bool isActive = true;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player" || collision.gameObject.tag == "Sticky")
        {
            RocketDestroyed = true;
            isFlying = false;
            RocketBlowUp.Play();
            collision.gameObject.TryGetComponent(out Blob playerBlob);
            if (playerBlob != null)
                playerBlob.TrigThis();
            _explosion.enabled = true;
            RocketBody.enabled = false;
            Trail.enableEmission = false;
            Destroy(transform.parent.gameObject, 1f);
        }
    }

    private void OnApplicationFocus(bool focus)
    {
        isActive = focus;
    }

    void Update()
    {
        if (isFlying && isActive)
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

    }
}
