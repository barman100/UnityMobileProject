using UnityEngine;


public class Impailed : MonoBehaviour
{
    [SerializeField] private string _causeOfDeath;
    [SerializeField] private GameManager _gameManager;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            
            _gameManager.CauseOfDeath = _causeOfDeath;
            GameManager.PlayerDied = true;
            Debug.Log("player dead");
        }
    }

}
