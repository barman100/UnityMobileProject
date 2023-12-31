﻿using UnityEngine;
using System.Collections;

public class AnimationScript : MonoBehaviour {

    [SerializeField] bool isAnimated = false;

    [SerializeField] bool isRotating = false;
    [SerializeField] bool isFloating = false;
    [SerializeField] bool isScaling = false;

    [SerializeField] Vector3 rotationAngle;
    [SerializeField] float rotationSpeed;

    [SerializeField] float floatSpeed;
    private bool goingUp = true;
    [SerializeField] float floatRate;
    private float floatTimer;
   
    [SerializeField] Vector3 startScale;
    [SerializeField] Vector3 endScale;

    private bool scalingUp = true;
    [SerializeField] float scaleSpeed;
    [SerializeField] float scaleRate;
    private float scaleTimer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

       
        
        if(isAnimated)
        {
            if(isRotating)
            {
                transform.Rotate(rotationAngle * rotationSpeed * Time.deltaTime);
            }

            if(isFloating)
            {
                floatTimer += Time.deltaTime;
                Vector3 moveDir = new Vector3(0.0f, 0.0f, floatSpeed);
                transform.Translate(moveDir);

                if (goingUp && floatTimer >= floatRate)
                {
                    goingUp = false;
                    floatTimer = 0;
                    floatSpeed = -floatSpeed;
                }

                else if(!goingUp && floatTimer >= floatRate)
                {
                    goingUp = true;
                    floatTimer = 0;
                    floatSpeed = +floatSpeed;
                }
            }

            if(isScaling)
            {
                scaleTimer += Time.deltaTime;

                if (scalingUp)
                {
                    transform.localScale = Vector3.Lerp(transform.localScale, endScale, scaleSpeed * Time.deltaTime);
                }
                else if (!scalingUp)
                {
                    transform.localScale = Vector3.Lerp(transform.localScale, startScale, scaleSpeed * Time.deltaTime);
                }

                if(scaleTimer >= scaleRate)
                {
                    if (scalingUp) { scalingUp = false; }
                    else if (!scalingUp) { scalingUp = true; }
                    scaleTimer = 0;
                }
            }
        }
	}
}
