using UnityEngine;

public class ExplosionTriggered : MonoBehaviour
{
    [SerializeField] private MineAnimationsManager _animationManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            collision.gameObject.TryGetComponent(out Blob playerBlob);

            if(playerBlob != null)
            {

            _animationManager.TriggerExplosion(playerBlob); 
            }
            
        }
    }
}
