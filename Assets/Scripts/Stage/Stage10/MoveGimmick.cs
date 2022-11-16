using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGimmick : Gimmick
{    
    [SerializeField] private Vector3Int move;
    [SerializeField] private float speed;

    private float step;
    private bool goBack = false;
    private Vector3 origin;
    private Vector3 destination;

    protected override void Start()
    {
        origin = transform.position;
        destination = new Vector3(origin.x - move.x, origin.y - move.y, origin.z - move.z);
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
