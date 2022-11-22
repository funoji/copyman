using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //移動の変数
    [Header("プレイヤーの設定")]
    [SerializeField] [Range(0.0f, 10.0f), Tooltip("移動のスピード")] private float moveSpeed;

    private Rigidbody rb;
    private Vector3 direction;
    [SerializeField]private CameraController refCamera_H;
    private float horizontal;
    private float vertical;
    Vector3 Forward = new Vector3(0, 0, 2);
    Vector3 Backward = new Vector3(0, 0, -2);
    Vector3 Right = new Vector3(2, 0, 0);
    Vector3 Left = new Vector3(-2, 0, 0);
    Vector3 Gravite = new Vector3(0, -2, 0);

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //horizontal = Input.GetAxis("LstickHorizontal");
        //vertical = Input.GetAxis("LstickVertical");
        horizontal = Input.GetAxis("MoveX");
        vertical = Input.GetAxis("MoveY");

        //Debug.Log("horizontal : " + horizontal + "  Vertical : " + vertical);

        direction = Vector3.zero;

        if (vertical > 0.0f)
        {
            direction.z += 1f;
            rb.velocity = Forward;
        }

        if (vertical < 0.0f)
        {
            direction.z -= 1f;
            rb.velocity = Backward;

        }
        if (horizontal > 0.0f)
        {
            direction.x += 1f;
            rb.velocity = Right;
        }
        if (horizontal < 0.0f)
        {
            direction.x -= 1f;
            rb.velocity = Left;
        }

        //if(horizontal == 0.0f)
        //{
        //    rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0.0f);
        //}
        //if (vertical == 0.0f)
        //{
        //    rb.velocity = new Vector3(0.0f, rb.velocity.y, rb.velocity.z);
        //}
        if (Input.GetButtonDown("Jump"))
            GetComponent<JumpManager>().Jump();
        direction = direction.normalized * moveSpeed * Time.deltaTime;
        rb.velocity = new Vector3(rb.velocity.x, -2, rb.velocity.z);

        if (direction.magnitude > 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(refCamera_H.rotateH * direction), 5.0f);
            transform.position += refCamera_H.rotateH * direction;
        }
    }
}
