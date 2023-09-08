using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityManager : MonoBehaviour
{
    void Start()
    {
        Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 floor = new Vector2(Input.gyro.gravity.x,Input.gyro.gravity.y);
        floor.Normalize();
        Physics2D.gravity = floor;
    }
}
