using UnityEngine;

public class RocketHit : MonoBehaviour
{
    [SerializeField] private float _speed = 10;
    [SerializeField] private ParticleSystem _rocketBlowUp;
    [SerializeField] private SpriteRenderer _rocketBody;
    [SerializeField] private ParticleSystem _trail;
    [SerializeField] private TurretDetect _turretDetRef;
    [SerializeField] private Collider2D _explosion;
       
    private bool _rocketDestroyed = false;
    private bool _isFlying = false;
    public bool IsActive = true;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player" || collision.gameObject.tag == "Sticky")
        {
            _rocketDestroyed = true;
            _isFlying = false;
            _rocketBlowUp.Play();
            _explosion.enabled = true;
            _rocketBody.enabled = false;
            _trail.enableEmission = false;

            collision.gameObject.TryGetComponent(out Blob playerBlob);
            if (playerBlob != null)
                playerBlob.TrigThis();

            Destroy(transform.parent.gameObject, 1f);
        }
    }

    private void OnApplicationFocus(bool focus)
    {
        IsActive = focus;
    }

    void Update()
    {
        if (_isFlying && IsActive)
        {
            if (!_rocketDestroyed)
            {
                transform.parent.transform.position += transform.right * _speed * Time.deltaTime;
            }
        }
    }

    public void IgniteThrusters()
    {
        _isFlying = true;
        _trail.Play();

    }
}
