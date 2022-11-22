using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("カメラの設定")]
    [SerializeField] [Range(-5.0f, 5.0f), Tooltip("回転のスピード")] float rotateSpeed = 0.5f;
    [Space(5)]
    [SerializeField] [Tooltip("注目する所")] GameObject targetObject;
    [Space(5)]
    [SerializeField] [Tooltip("カメラとプレイヤーとの距離")] float intervalM = 10f;

    [Space(5)]
    [Header("PlayerContoroller用")]
    [SerializeField] [Tooltip("カメラの水平")] public Quaternion rotateH;
    [SerializeField] [Tooltip("カメラの垂直")] public Quaternion rotateV;
    private RaycastHit hit;
    private LayerMask objLayer;

    // Start is called before the first frame update
    void Start()
    {
        //注目している所を設定
        transform.LookAt(targetObject.transform.position);

        //rotateH：水平方向の角度　rotateV：垂直方向の角度 の初期化
        rotateH = Quaternion.identity;
        rotateV = Quaternion.Euler(15, 0, 0);
        this.transform.rotation = rotateH * rotateV;
        //位置の初期化
        this.transform.position = targetObject.transform.position - transform.rotation * Vector3.forward * intervalM;
    }

    private void LateUpdate()
    {
        //コントローラー用
        float horizon = Input.GetAxis("RsitckHorizontal");
        //キーボード用
        //float horizon = Input.GetAxis("ArrowX")* rotateSpeed;

        //ボタン操作による回転
        rotateH *= Quaternion.Euler(0, horizon, 0);
        //カメラの角度を回転させる。位置を移動させる。
        this.transform.rotation = rotateH * rotateV;

        //　キャラクターとカメラの間に障害物があったら障害物の位置にカメラを移動させる
        if (Physics.Raycast(targetObject.transform.position, this.transform.position - targetObject.transform.position, out hit, Vector3.Distance(targetObject.transform.position, this.transform.position), objLayer, QueryTriggerInteraction.Ignore))
        {
            this.transform.position = hit.point;
        }
        else
            this.transform.position = targetObject.transform.position - this.transform.rotation * Vector3.forward * intervalM;

        //if (Physics.Linecast(targetObject.transform.position, this.transform.position, out hit, objLayer))
        //{
        //    Debug.Log("当たった。");
        //    this.transform.position = hit.point;
        //}
        //else
        //    this.transform.position = targetObject.transform.position - this.transform.rotation * Vector3.forward * intervalM;

        //　レイを視覚的に確認
        Debug.DrawLine(targetObject.transform.position, this.transform.position, Color.red, 0f, false);
    }
}
