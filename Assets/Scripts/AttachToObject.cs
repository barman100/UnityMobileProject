using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachToObject : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _parent;
    private GameObject _prefabRefference;
    public static bool attach = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || attach)
            return;
        /*        if (collision.gameObject.tag == "platform")
                {
                    gameObject.transform.parent.SetParent(collision.transform);
                }*/
        attach = true;
        _parent.SetParent(collision.transform);
        for (int i = 0; i < _parent.childCount; i++)
        {
            _parent.GetChild(i).GetComponent<Rigidbody2D>().gravityScale = 0f;
        }
        
        _prefabRefference = Instantiate(_prefab, collision.transform);
        _prefabRefference.GetComponent<FixedJoint2D>().connectedBody = gameObject.GetComponent<Rigidbody2D>();
        _prefabRefference.GetComponent<FixedJoint2D>().autoConfigureConnectedAnchor = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {

        Destroy(_prefabRefference);
        _prefabRefference = null;
        _parent.parent = null;
       attach =false;
        for (int i = 0; i < _parent.childCount; i++)
        {
            _parent.GetChild(i).GetComponent<Rigidbody2D>().gravityScale = 1f;
        }
    }
}
