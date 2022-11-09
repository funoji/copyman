using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpGround : Gimmick
{
    Gimmick gimmick;
     
    [SerializeField] private float moveX;
    [SerializeField] private float moveY;
    [SerializeField] private float moveZ;
    [SerializeField] private float speed;

    float step;
    bool goBack = false;
    Vector3 origin;
    Vector3 destination;

    protected override void Start()
    {
        origin = transform.position;
        destination = new Vector3(origin.x - moveX, origin.y - moveY, origin.z - moveZ);
    }

    protected override void Update()
    {
        if (stop)
        {
            return;
        }

        step = speed * Time.deltaTime;

        if (!goBack)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, step);

            if (transform.position == destination)
            {
                goBack = true;

                StartCoroutine(Wait());
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, origin, step);

            if (transform.position == origin)
            {
                goBack = false;

                StartCoroutine(Wait());
            }
        }
    }
}
