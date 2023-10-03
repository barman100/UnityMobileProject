using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] SpriteRenderer Point1;
    [SerializeField] SpriteRenderer Point2;


    public float Speed;
    public int StartP;
    public Transform[] Points;

    private int i;

    void Start()
    {
        Point1.enabled = false;
        Point2.enabled = false;
        transform.position = Points[StartP].position;
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
