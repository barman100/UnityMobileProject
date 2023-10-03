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


    private float Speed = 1;
    private bool isShooting = false;
    private float timer = 0;
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
    void Update()
    {
        if (isLockedOn)
        { 
            Quaternion rotation = Quaternion.LookRotation
              (Player.position - transform.position, transform.TransformDirection(Vector3.up));
            transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
            if (!Rocket)
            {
                isShooting = false;
                Speed = 1;
                Rocket = Instantiate(RocketReserved, transform.position, transform.rotation);
                timer = 0;
                RocketFire = Rocket.GetComponent<RocketHit>();
            }
            else { RocketFire.FlyRocket(); isShooting = true; }
        }
        if (isShooting)
        { timer += Time.deltaTime; if (timer > 2f) { Destroy(Rocket); isShooting = false; } }


    }
       public void NutrlizeSpeed()
       {
        Speed = 0;
        }
            
    }