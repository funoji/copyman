using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// メモ：（他）がコメントに書かれているコードは山﨑晶以外が記入したもの。
// 　　　コードを修正したいときに判別を分かりやすくするために（他）を記入しておく。

public class PlayerController : MonoBehaviour
{
    //アタッチ：移動の変数
    [Header("プレイヤーの設定")]
    [SerializeField][Range(0.0f, 20.0f), Tooltip("移動のスピード")] public float moveSpeed;
    [SerializeField][Tooltip("プレイヤーカメラの参照")] private Camera playerCamera;

    [Header("animationのスクリプトへの参照変数")]
    [SerializeField][Tooltip("rigidbodyの参照")] public Rigidbody rb;

    [HideInInspector] public float horizontal;
    [HideInInspector] public float vertical;

    //カメラの向き
    private Quaternion horizontalRotaion;

    // （他）
    //private int count = 0;

    //速度
    private Vector3 velocity;

    // JumpManagerを取得（他）
    private JumpManager jump;

    // CopyInputがアタッチされているオブジェクトを取得（他）
    private GameObject CopyInput;
    // CopyInputを取得（他）
    private Copyinput copyInput;

    void Start()
    {
        //Rigidbodyの取得
        rb = this.GetComponent<Rigidbody>();

        // 変数にJumpManagerのコンポーネントを設定する（他）
        jump = GetComponent<JumpManager>();

        //値の初期化
        rb.velocity = Vector3.zero;

        // CopyInputがアタッチされているオブジェクトを探す（他）
        CopyInput = GameObject.Find("CPM");
        // 変数にCopyInputのコンポーネントを設定する（他）
        copyInput = CopyInput.GetComponent<Copyinput>();
    }

    private void Update()
    {
        // ジャンプ（他）
        if (Input.GetButtonDown("Jump"))
        {
            jump.Jump();
        }
    }

    void FixedUpdate()
    {
        // カメラの正面の向きを取得
        horizontalRotaion = Quaternion.AngleAxis(playerCamera.transform.eulerAngles.y, Vector3.up);

        // コントローラー用
        horizontal = Input.GetAxis("LstickHorizontal");
        vertical = Input.GetAxis("LstickVertical");

        // キーボード用
        //horizontal = Input.GetAxis("MoveX");
        //vertical = Input.GetAxis("MoveY");

        // アニメーション用にRbのvelocityも変える
        rb.AddForce(new Vector3(horizontal, 0, vertical));

        // 移動のスピードとカメラの正面の向きに合わせる。
        velocity = horizontalRotaion * new Vector3(horizontal, 0, vertical) * moveSpeed * Time.deltaTime;

        if (velocity.magnitude > 0.05f)
        {
            // カメラの角度に応じて、プレイヤーをカメラの正面の向きに合わせる
            transform.rotation = Quaternion.LookRotation(velocity, Vector3.up);

            // プレイヤーの移動
            rb.MovePosition(transform.position + velocity);

            //count++;
            //if (count > 10)
            //{
            //    //AudioManager.Instance.PlaySE(SESoundData.Object.walk);
            //    count = 0;
            //}
        }
    }
}
