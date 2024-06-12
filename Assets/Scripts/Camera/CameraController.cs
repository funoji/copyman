using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// カメラをスクリプトで動かすソースコード

public class CameraController : MonoBehaviour
{
    [Header("カメラの設定")]
    [SerializeField, Tooltip("カメラが注目して見るところ")] 
    private GameObject targetObject;
    [SerializeField, Tooltip("カメラとプレイヤーとの距離の長さ")] 
    private float length_CtoP;
    [SerializeField, Tooltip("衝突判定になってほしいオブジェクト")] 
    private LayerMask layerObj;

    [Header("PlayerContoroller用")]
    [SerializeField, Tooltip("カメラの水平方向の値")] 
    public Quaternion CameraH;
    [SerializeField, Tooltip("カメラの垂直方向の値")] 
    public Quaternion CameraV;

    // Rayに当たった位置を保存する為の構造体
    private RaycastHit _raycastHit;

    // Rayの開始地点を保存する変数
    private Ray _ray;

    // プレイヤーとカメラとの距離を保存する変数
    private float _distance;

    // カメラの水平方向の値を保存する変数
    private Position _cameraH_quatePos = new Position(0.0f, 0.0f, 0.0f);

    // カメラの垂直方向の初期値
    private Position _cameraV_quatePos = new Position(10.0f, 0.0f, 0.0f);

    // コントローラーのボタンの名前
    private readonly string _buttonName = "RsitckHorizontal";

    // Start is called before the first frame update
    void Start()
    {
        // カメラの注目する部分を設定
        transform.LookAt(targetObject.transform.position);

        // CameraH：水平方向の角度　CameraV：垂直方向の角度 の初期化
        CameraH = Quaternion.identity;
        CameraV = Quaternion.Euler(_cameraV_quatePos.x, _cameraV_quatePos.y, _cameraV_quatePos.z);

        // 回転の初期化
        this.transform.rotation = CameraH * CameraV;
        // 位置の初期化
        this.transform.position = targetObject.transform.position - this.transform.rotation * Vector3.forward * length_CtoP;
    }

    private void FixedUpdate()
    {
        // コントローラー用
        _cameraH_quatePos.y = Input.GetAxis(_buttonName);

        // ボタン操作による回転
        CameraH *= Quaternion.Euler(_cameraH_quatePos.x, _cameraH_quatePos.y, _cameraH_quatePos.z);

        // カメラとプレイヤーとの距離を測定する
        _distance = Vector3.Distance(targetObject.transform.position, this.transform.position);

        // rayの開始地点を設定する
        _ray = new Ray(targetObject.transform.position, this.transform.position - targetObject.transform.position);
    }

    private void Update()
    {
        // カメラを回転移動させる
        this.transform.rotation = CameraH * CameraV;

        // 壁に当たった時の処理
        // Physics.Raycast(rayの開始地点 , rayの方向 , rayが衝突を検知する最大距離 , 衝突判定にしたいオブジェクト , トリガーに設定しているものを対象にするかの設定)
        if (Physics.Raycast(_ray, out _raycastHit, _distance, layerObj, QueryTriggerInteraction.Ignore) && _distance < length_CtoP)
        {
            // カメラの位置をRayがぶつかった場所に移動する
            this.transform.position = _raycastHit.point;
        }
        else
        {
            // カメラの位置を初期位置に戻す
            this.transform.position = targetObject.transform.position - this.transform.rotation * Vector3.forward * length_CtoP;
        }
    }

    // 座標を管理する構造体
    struct Position
    {
        public float x;
        public float y;
        public float z;

        // 初期化する関数
        public Position(float _x, float _y, float _z)
        {
            x = _x;
            y = _y;
            z = _z;
        }
    }
}