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
    [SerializeField] private CameraController refCamera_H;
    private float horizontal;
    private float vertical;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        horizontal = Input.GetAxis("LstickHorizontal");
        vertical = Input.GetAxis("LstickVertical");
        //horizontal = Input.GetAxis("MoveX");
        //vertical = Input.GetAxis("MoveY");

        //Debug.Log("horizontal : " + horizontal + "  Vertical : " + vertical);

        direction = Vector3.zero;

        if (vertical > 0.0f)
            direction.z -= 1f;
        if (vertical < 0.0f)
            direction.z += 1f;
        if (horizontal > 0.0f)
            direction.x -= 1f;
        if (horizontal < 0.0f)
            direction.x += 1f;


        if (Input.GetButtonDown("Jump"))
            GetComponent<JumpManager>().Jump();
        direction = direction.normalized * moveSpeed * Time.deltaTime;

        if (direction.magnitude > 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(refCamera_H.rotateH * -direction), 5.0f);
            transform.position += refCamera_H.rotateH * direction;
        }
    }
}
