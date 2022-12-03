using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMove : MonoBehaviour
{
    [SerializeField] private Vector3 move;
    [SerializeField] private float speed;
    [SerializeField] private float waitTime;
    [SerializeField] bool isActive = true;

    public bool ActiveGimmick
    {
        get => isActive;
        set => isActive = value;
    }

    private float step;
    private bool goBack = false;
    private bool stop = false;

    private Vector3 origin;
    private Vector3 destination;

    void Start()
    {
        origin = transform.position;
    }

    void Update()
    {
        if (!isActive) return;
        if (stop) return;

        step = speed * Time.deltaTime;

        if (!goBack)
        {
            destination = new Vector3(transform.position.x - move.x, origin.y - move.y, transform.position.z - move.z);
            transform.position = Vector3.MoveTowards(transform.position, destination, step);

            if (transform.position == destination)
            {
                goBack = true;
                StartCoroutine(Wait());
            }
        }

        else
        {
            destination = new Vector3(transform.position.x - move.x, origin.y, transform.position.z - move.z);
            transform.position = Vector3.MoveTowards(transform.position, destination, step);

            if (transform.position == destination)
            {
                goBack = false;

                StartCoroutine(Wait());
            }
        }

    }

    IEnumerator Wait()
    {
        stop = true;

        yield return new WaitForSeconds(waitTime);

        stop = false;
    }
}
