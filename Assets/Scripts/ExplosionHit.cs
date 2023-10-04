using UnityEngine;

public class ExplosionHit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "player")
        {
            GameManager.PlayerDied = true;
        }
    }
}
