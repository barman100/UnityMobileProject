using System;
using System.Collections.Generic;
using UnityEngine;


public class ShootUp : MonoBehaviour
{
    [SerializeField] private float _shootForce = 10.0f;
    [SerializeField] private Rigidbody2D _rb2D;
    [SerializeField] private Blob _blob;
    void Update()
    {
        // Check for the spacebar press
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_rb2D != null && _blob != null)
            {
                _blob.TrigThis();
                _rb2D.AddForce(Vector2.up * _shootForce, ForceMode2D.Impulse);
            }
        }
    }
}

