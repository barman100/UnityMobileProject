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
    [SerializeField] GameObject Rocket;
    [SerializeField] public RocketHit RocketFire;
    [SerializeField] float FireDelay = 3;
    [SerializeField] public float ReloadDelay = 3;

    private float ReloadTimer = 0;
    private float FireTimer = 0;
    private bool isFired = false;
    public bool isLockedOn = false;
    public bool isGunLoaded = true;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerMain")
        { isLockedOn = true; }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerMain")
        { isLockedOn = false; }
    }

    private void Start()
    {
        Rocket = Instantiate(RocketReserved, transform.position, transform.rotation);
        RocketFire = Rocket.transform.GetChild(1).GetComponent<RocketHit>();
        Rocket.transform.parent = transform;
        isFired = false;
        Rocket.transform.localPosition = new Vector3(3, 0, 1);
    }


    void Update()
    {
        if (isLockedOn)
        { 
            Quaternion rotation = Quaternion.LookRotation
              (Player.position - transform.position, transform.TransformDirection(Vector3.up));
            transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
            if (isFired == false)
            {
                if (FireTimer > FireDelay)
                {
                    Debug.Log("Fired");
                    Rocket.transform.parent = transform.parent;
                    ReloadTimer = 0;
                    isFired = true;
                    RocketFire.IgniteThrusters();
                    Rocket = Instantiate(RocketReserved, transform.position, transform.rotation);
                    RocketFire = Rocket.transform.GetChild(1).GetComponent<RocketHit>();
                    Rocket.transform.parent = transform;
                    Rocket.transform.localPosition = new Vector3(0, 0, 1);
                }
                else
                {
                    FireTimer += Time.deltaTime;
                    Debug.Log("Aiming");
                }
            }
        }
        else
        {
            FireTimer = 0;
        }
        if (isFired && ReloadTimer > ReloadDelay)
        {
            Debug.Log("Reloading Finished");
            FireTimer = 0;
            isFired = false;
            
            Rocket.transform.localPosition = new Vector3(3,0,1);
        }
        else if (isFired)
        {
            Debug.Log("Reloading");
            ReloadTimer += Time.deltaTime;
        }



    }
       
            
    }