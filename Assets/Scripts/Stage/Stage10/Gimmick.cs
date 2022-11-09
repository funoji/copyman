using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimmick : MonoBehaviour
{
    [SerializeField]
    protected float waitTime;
    protected bool stop = false;

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {

    }

    protected IEnumerator Wait()
    {
        stop = true;

        yield return new WaitForSeconds(waitTime);

        stop = false;
    }
}
