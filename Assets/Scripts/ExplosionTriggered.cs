using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionTriggered : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            collision.gameObject.TryGetComponent(out Blob _playerBlob);
            
            if (_playerBlob != null)
                GameManager.PlayerDied = true;
            
        }
    }
}
