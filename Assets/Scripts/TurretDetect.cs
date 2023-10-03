using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UIElements;


public class TurretDetect : MonoBehaviour
{
    [SerializeField] GameObject RocketReserved;
    [SerializeField] Transform Player;
    [SerializeField] float Range;
    [SerializeField] GameObject Rocket;
    [SerializeField] int FireRate;

    private Transform RocketScale;
    private float nextTimeToShoot;
    
    public bool isLockedOn = false;
    public bool isGunLoaded = true;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        { isLockedOn = true; }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        { isLockedOn = false;}
    }

    private void Start()
    {
        
    }
    void Update()
    {
        
        
        
        if (isLockedOn)
        { 
            Quaternion rotation = Quaternion.LookRotation
              (Player.position - transform.position, transform.TransformDirection(Vector3.up));
            transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
            if (!Rocket) 
            { 
                Debug.Log("Problom");
                Rocket = Instantiate(RocketReserved, transform.position, transform.rotation);
                
            }
            Rocket.transform.Translate(0.4f, 0, 0, Space.Self);
        }


    }

    public void FireRocket()
    {
        {
            Debug.Log("Fire");
            
              
        }
            
            
        
        
    }

}
