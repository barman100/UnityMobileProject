using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityManager : MonoBehaviour
{
    private bool isActive = true;
    void Start()
    {
        Input.gyro.enabled = true;
    }

    private void OnApplicationFocus(bool focus)
    {
        isActive = focus;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isActive)
        {
            Vector2 floor = new Vector2(Input.gyro.gravity.x,Input.gyro.gravity.y);
                    floor.Normalize();
                    Physics2D.gravity = floor;
        }
        
    }
}
