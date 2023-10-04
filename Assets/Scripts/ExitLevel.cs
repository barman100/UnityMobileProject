using UnityEngine;


public class ExitLevel : MonoBehaviour
{ 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "player")
        {
            GameManager.LevelEnded = true;
        }
    }
}
