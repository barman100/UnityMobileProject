using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveypdown : MonoBehaviour
{
    public float moveDistance = 2.0f;     // Total distance the platform will move
    public float moveSpeed = 2.0f;        // Speed of the platform's movement
    public float delayBetweenMovements = 2.0f; // Delay between movements

    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private bool isMoving = false;

    private void Start()
    {
        initialPosition = transform.position;
        targetPosition = initialPosition + new Vector3(0, moveDistance, 0);
        // Start moving the platform
        StartMoving();
    }

    private void Update()
    {
        if (isMoving)
        {
            // Move the platform towards the target position
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Check if the platform has reached the target position
            if (transform.position == targetPosition)
            {
                // Swap the target position
                Vector3 temp = targetPosition;
                targetPosition = initialPosition;
                initialPosition = temp;

                // Stop moving briefly before changing direction
                isMoving = false;
                Invoke("StartMoving", delayBetweenMovements);
            }
        }
    }

    private void StartMoving()
    {
        isMoving = true;
    }
}


