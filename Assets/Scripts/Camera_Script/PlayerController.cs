using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //アタッチ：移動の変数
    [Header("プレイヤーの設定")]
    [SerializeField] [Range(0.0f, 20.0f), Tooltip("移動のスピード")] public float moveSpeed;
    [SerializeField] [Tooltip("プレイヤーカメラの参照")] private Camera playerCamera;
    [Header("animationのスクリプトへの参照変数")]
    [SerializeField] [Tooltip("rigidbodyの参照")] public Rigidbody rb;
    [SerializeField] [Tooltip("horizontal")] public float horizontal;
    [SerializeField] [Tooltip("vertical")] public float vertical;    // Start is called before the first frame update

    private JumpManager jump;
    private Quaternion targetRotion;
    private Quaternion horizontalRotaion;

    private Vector3 velocity;

    void Start()
    {
        //Rigidbodyの取得
        rb = this.GetComponent<Rigidbody>();
        jump = GetComponent<JumpManager>();

        //値の初期化
        rb.velocity = Vector3.zero;

        //ターゲットとの角度
        targetRotion = transform.rotation;
    }

    void FixedUpdate()
    {
        var rotationSpeed = 600 * Time.deltaTime;
        //カメラの正面の向きを取得
        horizontalRotaion = Quaternion.AngleAxis(playerCamera.transform.eulerAngles.y, Vector3.up);

        //コントローラー用
        //horizontal = Input.GetAxis("LstickHorizontal");
        //vertical = Input.GetAxis("LstickVertical");

        //キーボード用
        horizontal = Input.GetAxis("MoveX");
        vertical = Input.GetAxis("MoveY");

        //ジャンプ
        if (Input.GetButtonDown("Jump"))
        {
            jump.Jump();
        }

        //アニメーション用にRbのvelocityも変える
        rb.AddForce(new Vector3(horizontal, 0, vertical));

        //移動のスピードとカメラの正面の向きに合わせる。
        velocity = horizontalRotaion * new Vector3(horizontal, 0, vertical) * moveSpeed * Time.deltaTime;
        if (velocity.magnitude > 0.05f)
        {
            //カメラの角度に応じて、プレイヤーをカメラの正面の向きに合わせる
            transform.rotation = Quaternion.LookRotation(new Vector3(velocity.x,0,velocity.z), Vector3.up);
            //プレイヤーの移動
            rb.MovePosition(transform.position + velocity);
        }
        //滑らかに回転させる
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotion, rotationSpeed);
    }
}
