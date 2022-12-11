using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepMove : MonoBehaviour
{
    [SerializeField] private GameObject escapeEnemy;
    [SerializeField] private float escapeSpd;
    [SerializeField] private float searchDis;

    private bool isStan;
    private bool escapeFlag;
    private Vector3 prePos;

    [SerializeField]
    private float walkSpeed = 1.0f;
 
    private Vector3 direction;
   
    private bool arrived;

  
    [SerializeField]
    private float waitTime = 5f;
    
    private float elapsedTime;
    
    private Vector3 destination;

    void Start()
    {
        prePos = transform.position;
        isStan = false;
        arrived = false;
        escapeFlag = false;
        elapsedTime = 0f;
        CreateRandomPosition();
    }

    private void FixedUpdate()
    {
        if (isStan) return;
        MoveAround();
        RotateToMove();
        EscapeToObj();

    }

    private void MoveAround()
    {
        if (escapeFlag) return;
        if (!arrived)
        {
            direction = (destination - transform.position).normalized;

            transform.Translate(direction * walkSpeed * Time.deltaTime,Space.World);

            if (Vector3.Distance(transform.position, destination) < 0.5f)
            {
                arrived = true;
            }
        }
        else
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime > waitTime)
            {
                CreateRandomPosition();
                destination = GetDestination();
                arrived = false;
                elapsedTime = 0f;
            }
        }
    }
  

    void EscapeToObj()
    {
        GameObject escapeTarget = FetchNearObjectWithTag(escapeEnemy.tag);    
        float dis = Vector3.Distance(transform.position,escapeTarget.transform.position);
        if (dis >= searchDis)
        {
            escapeFlag = false;
            return;
        }
        escapeFlag = true;
        Vector3 escapeVec = (transform.position - escapeTarget.transform.position).normalized;
        transform.Translate(escapeVec * escapeSpd * Time.deltaTime,Space.World);
    }

    void RotateToMove()
    {
        Vector3 diff = transform.position - prePos;
        prePos = transform.position;
        if (diff.magnitude <= 0.01) return;
        transform.rotation = Quaternion.LookRotation(diff,Vector3.up);
    }

    private GameObject FetchNearObjectWithTag(string tagName)
    {
        var targets = GameObject.FindGameObjectsWithTag(tagName);
        if (targets.Length == 1) return targets[0];

        GameObject result = null;
        var minTargetDistance = float.MaxValue;
        foreach (var target in targets)
        {
            var targetDistance = Vector3.Distance(transform.position, target.transform.position);
            if (!(targetDistance < minTargetDistance)) continue;
            minTargetDistance = targetDistance;
            result = target.transform.gameObject;
        }

        return result;
    }

    public void CreateRandomPosition()
    {
        var randDestination = Random.insideUnitCircle * 8;
        SetDestination(transform.position + new Vector3(randDestination.x, 0, randDestination.y));
    }

    public void SetDestination(Vector3 position)
    {
        destination = position;
    }

    public Vector3 GetDestination()
    {
        return destination;
    }
}
