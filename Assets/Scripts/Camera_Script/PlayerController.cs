using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //スクリプト参照
    //[SerializeField] [Tooltip("当たり判定のスクリプト")] public WallJudg_Script playerCD;

    //移動の変数
    [SerializeField] [Tooltip("移動のスピード")] private float moveSpeed;
    //[SerializeField] [Tooltip("プレイヤーの移動スピード")] private float move_speed = 10f;
    [SerializeField] [Tooltip("プレイヤーの重力")] private Rigidbody rb;
    [SerializeField] [Tooltip("プレイヤーの移動方向")] private Vector3 direction;
    [SerializeField] [Tooltip("カメラの水平方向")] private CameraController refCamera_H;
    private float horizontal;
    private float vertical;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float MoveX = Input.GetAxis("LstickHorizontal")*moveSpeed*Time.deltaTime;
        float MoveY = Input.GetAxis("LstickVertical")*moveSpeed* Time.deltaTime;

        Debug.Log("hoeizontal : " + MoveX+"  vertical : "+MoveY);

        direction = rb.position;
        direction += new Vector3(MoveX, 0, MoveY);
        rb.position = direction;


        if (Input.GetButtonDown("Jump"))
            GetComponent<JumpManager>().Jump();

        //if (direction.magnitude > 0)
        //{
        //    //rb.rotation = Quaternion.Slerp(rb.rotation, Quaternion.LookRotation(refCamera_H.rotateH * -direction), 5.0f);
        //    //rb.position = refCamera_H.rotateH * direction;
        //    rb.position = direction;
        //}
    }
}