using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float Speed;
    public int StartingPoint;
    public Transform[] Points;

    private int i;

    void Start()
    {
        transform.position = Points[StartingPoint].position;
    }
    void Update()
    {
        if (Vector2.Distance(transform.position, Points[i].position) < 0.02f)
        {
            i++;
            if (i == Points.Length)
            {  i = 0; }
        }
        transform.position = Vector2.MoveTowards(transform.position, Points[i].position, Speed * Time.deltaTime);
    }
}
