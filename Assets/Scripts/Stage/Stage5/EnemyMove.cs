using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    private bool isStan;
    private bool isAttck;
    private bool arrived;
    private Vector3 prePos;
    private Vector3 direction;
    private Vector3 startPosition;
    private Vector3 destination;
    private float elapsedTime;

    [SerializeField] private float searchDis;
    [SerializeField] private GameObject attackObj;
    [SerializeField] private float attackSpd;
    [SerializeField] private float moveSpd;
    [SerializeField] private float maxSpd;
    [SerializeField] private float waitTime = 5f;

    public bool ActiveGimmick
    {
        get => isAttck;
        set => isAttck = value;
    }
    public bool ActiveStan
    {
        get => isStan;
        set => isStan = value;
    }

    void Start()
    {
        prePos = transform.position;
        isAttck = false;
        isStan = false;
        arrived = false;
        elapsedTime = 0f;
        startPosition = transform.position;
        SetDestination(transform.position);
    }

    private void FixedUpdate()
    {
        if (isStan) return;
        Move();
        Attack();
        RotateToMove();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody>().velocity.magnitude <= 5)
        {
            IsStan();
            Invoke("IsStan", 3.0f);
            Debug.Log("aaaa");
        }

        if(collision.gameObject.tag == "Player")
        {
            GameDirector.GameOver = true;
        }
    }

    void Move()
    {
        if (isAttck) return;
        if (!arrived)
        {
            direction = (destination - transform.position).normalized;

            transform.Translate(direction * moveSpd * Time.deltaTime,Space.World);

            //�ړI�n�ɓ����������ǂ����̔���
            if (Vector3.Distance(transform.position, destination) < 0.5f)
            {
                arrived = true;
            }
        }
        else
        {
            elapsedTime += Time.deltaTime;

            //�҂����Ԃ��z�����玟�̖ړI�n��ݒ�
            if (elapsedTime > waitTime)
            {
                CreateRandomPosition();
                destination = GetDestination();
                arrived = false;
                elapsedTime = 0f;
            }
        }
    }

    void Attack()
    {
        IsAttack();
        if (!isAttck) return;

        Vector3 posA = attackObj.transform.position;
        Vector3 posB = transform.position;
        Vector3 dif = (posA - posB).normalized * attackSpd;
        Vector3 attackVec = new Vector3(dif.x, 0, dif.z);

        transform.Translate(attackVec * Time.deltaTime,Space.World);
        
    }

    void RotateToMove()
    {
        
        Vector3 diff = transform.position - prePos;
        prePos = transform.position;
        if (diff.magnitude <= 0.01) return;
        transform.rotation = Quaternion.LookRotation(diff,Vector3.up);
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

    void IsStan()
    {
        if (isStan)
        {
            isStan = false; 
            return;
        }
        if (!isStan) isStan = true;
    }

    public void CreateRandomPosition()
    {
        var randDestination = Random.insideUnitCircle * 8;
        SetDestination(startPosition + new Vector3(randDestination.x, 0, randDestination.y));
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
