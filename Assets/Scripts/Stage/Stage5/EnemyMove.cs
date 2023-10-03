using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

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

    [SerializeField] private GameObject attackObj;
    [SerializeField] private new GameObject collider;
    [SerializeField] private OnEffect explosion;
    [SerializeField] private float searchDis;
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
        attackObj = GameObject.Find("Player");
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

        if (!GameDirector.GameClear && !GameDirector.GameOver)
        {
            rb.angularVelocity = Vector3.zero;
            Move();
            Attack();
            RotateToMove();
            AnimController();
        }
        else if (GameDirector.GameClear || GameDirector.GameOver)
        {
            moveSpd = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody>().velocity.magnitude >= 5)
        {
            IsStan();
            Invoke("IsStan", 3.0f);
        }

        if((!GameDirector.GameClear && !GameDirector.GameOver)&&collision.gameObject.name == "Player")
        {
            rb.velocity = Vector3.zero;
            isExplosion = true;
            animator.SetBool("IsAttack", true);
            Invoke("Explosion", 0.5f);
            Invoke("GameOver", 1.0f);

            GameOver();
        }
    }

    void Move()
    {
        if (isAttck) return;
        if (!arrived)
        {
            direction = (destination - transform.position).normalized;

            transform.Translate(direction * moveSpd * Time.deltaTime,Space.World);

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

        if (diff.magnitude <= 0.03f) return;
        diff = new Vector3(diff.x, diff.y, diff.z);
        
        Quaternion lookRotate = Quaternion.LookRotation(diff,Vector3.up);
        transform.rotation=Quaternion.Slerp(transform.rotation,lookRotate,Time.deltaTime * 2f);
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

    void Explosion()
    {
        explosion.StartEff = true;
        rb.isKinematic = true;
        collider.SetActive(false);
    }

    void GameOver()
    {
        GameDirector.GameOver = true;
    }
}
