using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //アタッチ：移動の変数
    [Header("カメラのスクリプトを参照")]
    [SerializeField] [Tooltip("CameraControllerを参照")] private CameraController refCamera_H;
    [Header("プレイヤーの設定")]
    [SerializeField] [Range(0.0f, 20.0f), Tooltip("移動のスピード")] private float moveSpeed;

    //スクリプト内 : 移動の変数
    private Rigidbody rb;
    private Vector3 direction;
    [SerializeField]private CameraController refCamera_H;
    private float horizontal;
    private float vertical;
    private JumpManager jump;
    Vector3 Forward = new Vector3(0, 0, 2);
    Vector3 Backward = new Vector3(0, 0, -2);
    Vector3 Right = new Vector3(2, 0, 0);
    Vector3 Left = new Vector3(-2, 0, 0);
    Vector3 Gravite = new Vector3(0, -2, 0);

    // Start is called before the first frame update
    void Start()
    {
        //Rigidbodyの取得
        rb = this.GetComponent<Rigidbody>();
        jump = GetComponent<JumpManager>();
    }

    void FixedUpdate()
    {
        //コントローラー用
        horizontal = Input.GetAxis("LstickHorizontal");
        vertical = Input.GetAxis("LstickVertical");
        //キーボード用
        //horizontal = Input.GetAxis("MoveX");
        //vertical = Input.GetAxis("MoveY");

        ////Debug : 入力の値を確認する
        ////Debug.Log("horizontal : " + horizontal + "  Vertical : " + vertical);

        ////値の初期化
        //direction = Vector3.zero;

        ////キー入力 : 移動
        //if (vertical > 0.1f)
        //    direction.z += 0.1f;
        //if (vertical < -0.1f)
        //    direction.z -= 0.1f;
        //if (horizontal > 0.1f)
        //    direction.x += 0.1f;
        //if (horizontal < -0.1f)
        //    direction.x -= 0.1f;

        ////キー入力：ジャンプ
        //if (Input.GetButtonDown("Jump"))
        //    GetComponent<JumpManager>().Jump();

        ////移動のスピード
        //direction = direction * moveSpeed * Time.deltaTime;

        ////入力されていたらの処理
        //if (direction.magnitude > 0)
        //{
        //    //カメラの角度に応じて、プレイヤーをカメラの正面の向きに合わせる
        //    //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(refCamera_H.rotateH * direction), 5.0f);
        //    //プレイヤーの移動
        //    transform.position +=  direction;
        //}

        //キーボード用
        float horizontal = Input.GetAxis("MoveX");
        float vertical = Input.GetAxis("MoveY");

        //値の初期化
        direction = Vector3.zero;

        //キー入力 : 移動
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
            jump.Jump();

        //移動のスピード
        direction = direction.normalized * moveSpeed * Time.deltaTime;
        rb.velocity = new Vector3(rb.velocity.x, -2, rb.velocity.z);

        //入力されていたらの処理
        if (direction.magnitude > 0)
        {
            //カメラの角度に応じて、プレイヤーをカメラの正面の向きに合わせる
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(refCamera_H.rotateH * direction), 1.0f);
            //プレイヤーの移動
            transform.position += direction;
        }
    }
}
