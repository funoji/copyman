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
        float HorizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");

        direction = Vector3.zero;
        if (Input.GetKey(KeyCode.W) || VerticalInput > 0.0f)
        {
            Debug.Log("Up Key");
            direction.z -= 1f;
        }
        if (Input.GetKey(KeyCode.S) || VerticalInput < 0.0f)
        {
            Debug.Log("down Key");
            direction.z += 1f;
        }
        if (Input.GetKey(KeyCode.D) || HorizontalInput > 0.0f)
        {
            direction.x -= 1f;
        }
        if (Input.GetKey(KeyCode.A) || HorizontalInput < 0.0f)
        {
            direction.x += 1f;
        }

        if (Input.GetButtonDown("Jump"))
            GetComponent<JumpManager>().Jump();
        direction = direction.normalized * move_speed * Time.deltaTime;

        if (direction.magnitude > 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(refCamera_H.rotateH * -direction), 5.0f);
            transform.position += refCamera_H.rotateH * direction;
        }
    }
}