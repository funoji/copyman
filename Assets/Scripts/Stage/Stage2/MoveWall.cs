using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour
{
    private bool isAttck;

    [SerializeField] private float searchDis;
    [SerializeField] private GameObject attackObj;
    [SerializeField] private float attackSpd;

    public bool ActiveGimmick
    {
        get => isAttck;
        set => isAttck = value;
    }

    private void FixedUpdate()
    {
        Attack();
    }

    void Attack()
    {
        IsAttack();
        if (!isAttck) return;

        Vector3 posA = attackObj.transform.position;
        Vector3 posB = transform.position;
        Vector3 dif = (posA - posB).normalized * attackSpd;
        Vector3 attackVec = new Vector3(dif.x, 0, dif.z);

        transform.Translate(attackVec * Time.deltaTime, Space.World);
    }

    void IsAttack()
    {
        float dis = Vector3.Distance(attackObj.transform.position, transform.position);
        if (dis < searchDis)
        {
            isAttck = true;
            return;
        }
        isAttck = false;
    }
}
