using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// メモ：（他）がコメントに書かれているコードは山﨑晶以外が記入したもの。
// 　　　コードを修正したいときに判別を分かりやすくするために（他）を記入しておく。

public class PlayerController : MonoBehaviour
{
    //アタッチ：移動の変数
    [Header("プレイヤーの設定")]
    [SerializeField,Range(0.0f, 20.0f), Tooltip("移動のスピード")] 
    public float moveSpeed;
    [SerializeField,Tooltip("プレイヤーカメラの参照")] 
    private Camera playerCamera;
    [SerializeField, Range(0.0f, 1f), Tooltip("キャラクターが前進する際にどのくらいの力で判定するかの値")]
    private float pushStickPower = 0.01f;

    [Header("animationのスクリプトへの参照変数")]
    [SerializeField,Tooltip("rigidbodyの参照")] 
    public Rigidbody rb;

    // コントローラーの横に傾けた時の値を取得
    [HideInInspector] 
    public float contorollerH;

    // コントローラーを縦に傾けた時の値の取得
    [HideInInspector] 
    public float contorollerV;

    //カメラの向き
    private Quaternion _orientation;

    // （他）
    //private int count = 0;

    //速度
    private Vector3 _velocity;

    // JumpManagerを取得（他）
    private JumpManager jump;

    // CopyInputがアタッチされているオブジェクトを取得（他）
    private GameObject CopyInput;
    // CopyInputを取得（他）
    private Copyinput copyInput;

    // コントローラーのスティックの横方向の名前を保存する変数
    private readonly string horizontalName = "LstickHorizontal";

    // コントローラーのスティックの縦方向の名前を保存する変数
    private readonly string verticalName = "LstickVertical";

    void Start()
    {
        //Rigidbodyの取得
        rb = this.GetComponent<Rigidbody>();

        // 変数にJumpManagerのコンポーネントを設定する（他）
        jump = GetComponent<JumpManager>();

        //速度ベクトルを初期化
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
        _orientation = Quaternion.AngleAxis(playerCamera.transform.eulerAngles.y, Vector3.up);

        // コントローラー用
        contorollerH = Input.GetAxis(horizontalName);
        contorollerV = Input.GetAxis(verticalName);

        // コントローラーのスティックの値を保存しておく
        var contorollerStick = new Vector3(contorollerH, 0, contorollerV);

        // アニメーション用にRbの_velocityも変える
        rb.AddForce(contorollerStick);

        // 現在のカメラの向きとコントローラーの入力を合わせた力を保存
        _velocity = _orientation * contorollerStick * (moveSpeed * Time.deltaTime);

        // 力の大きさが指定している物以上になった場合
        if (_velocity.magnitude > pushStickPower)
        {
            // カメラの角度に応じて、プレイヤーをカメラの正面の向きに合わせる
            transform.rotation = Quaternion.LookRotation(_velocity, Vector3.up);

            // プレイヤーの移動
            rb.MovePosition(transform.position + _velocity);
        }
    }
}
