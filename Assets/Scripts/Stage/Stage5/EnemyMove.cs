using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    private bool isStan;
    private bool isAttck;
    private bool arrived;
    private bool isExplosion;
    private bool isRotate;

    private Vector3 prePos;
    private Vector3 direction;
    private Vector3 destination;
    private Vector3 diff;

    private float elapsedTime;
    private float animSpd;

    private Animator animator;
    private Rigidbody rb;

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

        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        prePos = transform.position;

        isRotate = true;
        isAttck = false;
        isStan = false;
        arrived = false;
        isExplosion = false;

        elapsedTime = 0f;
        
        CreateRandomPosition();
        
    }

    private void FixedUpdate()
    {
        if (isStan) return;
        if (isExplosion) return;
        rb.angularVelocity = Vector3.zero;
        Move();
        Attack();
        RotateToMove();
        AnimController();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody>().velocity.magnitude >= 5)
        {
            IsStan();
            Invoke("IsStan", 3.0f);
        }

        if(collision.gameObject.name == "Player")
        {
            rb.velocity = Vector3.zero;
            isExplosion = true;
            animator.SetBool("IsAttack", true);
            GameDirector.GameOver = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cancopy"))
        {
            isRotate = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cancopy"))
        {
            isRotate = true;
        }
    }

    void Move()
    {
        if (isAttck) return;
        if (!arrived)
        {
            direction = (destination - transform.position).normalized;

            transform.Translate(direction * moveSpd * Time.deltaTime,Space.World);

            //目的地に到着したかどうかの判定
            if (Vector3.Distance(transform.position, destination) < 0.5f)
            {
                arrived = true;
            }
        }
        else
        {
            elapsedTime += Time.deltaTime;

            //待ち時間を越えたら次の目的地を設定
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
        if (rb.velocity.magnitude > maxSpd) return;

        Vector3 posA = attackObj.transform.position;
        Vector3 posB = transform.position;
        Vector3 dif = (posA - posB).normalized * attackSpd;
        Vector3 attackVec = new Vector3(dif.x, 0, dif.z);

        transform.Translate(attackVec * Time.deltaTime,Space.World);
        //rb.AddForce(attackVec*100);
    }

    void RotateToMove()
    {
        if (!isRotate) return;
        diff = transform.position - prePos;
        prePos = transform.position;
        if (diff == Vector3.zero) return;
        if (diff.magnitude <= 0.05f) return;
        diff = new Vector3(diff.x, 0, diff.z);
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
    void AnimController()
    {
        animSpd = rb.velocity.magnitude;
        animator.SetFloat("Spd", diff.magnitude);
        animator.SetBool("IsAttack", isExplosion);
    }
}
