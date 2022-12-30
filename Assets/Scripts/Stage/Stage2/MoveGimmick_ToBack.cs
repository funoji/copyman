using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGimmick_ToBack : MonoBehaviour
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
        destination = new Vector3(origin.x - move.x, origin.y - move.y, origin.z - move.z);
    }

    void Update()
    {
        if (!isActive)
        {
            transform.position = Vector3.MoveTowards(transform.position, origin, step);
        }
        else
        {
            if (stop) return;
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

    IEnumerator Wait()
    {
        stop = true;

        yield return new WaitForSeconds(waitTime);

        stop = false;
    }
}
