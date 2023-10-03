using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CollectGem : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem _partical;
    [SerializeField]
    private GameObject _diamondChild;

    private bool NotDestroyed = false;
    public event Action CollectGemEvent; // Diamonds
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!NotDestroyed && collision.gameObject.tag == "player")
        {
            CollectGemEvent?.Invoke();
            Debug.Log("Score");
            _partical.Play();
            _diamondChild.SetActive(false);
            Destroy(this.gameObject, 1f);
        }
    }
}
