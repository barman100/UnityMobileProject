using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakHandle : MonoBehaviour
{
    [SerializeField] GameObject Pieces;

    [SerializeField] Rigidbody2D RB;
    [SerializeField] SpriteRenderer Sprite;
    [SerializeField] BoxCollider2D Col;

    public void BreakObj(){
        
        Pieces.SetActive(true);

        Destroy(RB);
        Destroy(Sprite);
        Destroy(Col);
        Destroy(this.gameObject, 5f);
    }
}
