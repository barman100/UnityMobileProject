using UnityEngine;

public class WarningTriggered : MonoBehaviour
{
    [SerializeField] private MineAnimationsManager _animationManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "player")
        _animationManager.TriggerWarning();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
            _animationManager.ExitWarningRange();
    }
}
