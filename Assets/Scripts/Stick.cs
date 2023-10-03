using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Stick : MonoBehaviour
{
    [SerializeField] GameObject playerParent;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collison)
    {
        if (collison.transform.tag != "Player")
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            rb.gravityScale = 0f;
            playerParent.transform.SetParent(collison.transform);
        }
    }
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            rb.constraints = RigidbodyConstraints2D.None;
            rb.gravityScale = 1f;
            playerParent.transform.parent = null;
        }
    }
}
