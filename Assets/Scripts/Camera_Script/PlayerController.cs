using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //移動の変数
    [SerializeField] [Tooltip("プレイヤーの移動スピード")] private float move_speed = 10f;
    [SerializeField] [Tooltip("プレイヤーの重力")] private Rigidbody rb;
    [SerializeField] [Tooltip("プレイヤーの移動方向")] private Vector3 direction;
    [SerializeField] [Tooltip("カメラの水平方向")] private CameraController refCamera_H;
    public float horizontal;
    public float vertical; 
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        horizontal = Input.GetAxis("LstickHorizontal");
        vertical = Input.GetAxis("LstickVertical");

        Debug.Log("horizontal : " + horizontal + "  Vertical : " + vertical);

        direction = Vector3.zero;
        if (Input.GetKey(KeyCode.W) || vertical > 0.0f)
        {
            //Debug.Log("Up Key");
            direction.z -= 1f;
        }
        if (Input.GetKey(KeyCode.S) || vertical < 0.0f)
        {
            //Debug.Log("down Key");
            direction.z += 1f;
        }
        if (Input.GetKey(KeyCode.D) || horizontal > 0.0f)
        {
            direction.x -= 1f;
        }
        if (Input.GetKey(KeyCode.A) || horizontal < 0.0f)
        {
            direction.x += 1f;
        }

        if (Input.GetButtonDown("Jump") && Input.GetKeyDown(KeyCode.Space))
            GetComponent<JumpManager>().Jump();
        direction = direction.normalized * move_speed * Time.deltaTime;

        if (direction.magnitude > 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(refCamera_H.rotateH * -direction), 5.0f);
            transform.position += refCamera_H.rotateH * direction;
        }
    }
}