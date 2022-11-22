using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//RayCast
//https://tech.pjin.jp/blog/2021/10/28/unity-raycast/


public class CameraController : MonoBehaviour
{
    [Header("カメラの設定")]
    [SerializeField] [Range(-5.0f, 5.0f), Tooltip("回転のスピード")] float rotateSpeed = 0.5f;
    [SerializeField] [Tooltip("注目する所")] GameObject targetObject;
    [SerializeField] [Tooltip("カメラとプレイヤーとの距離")] float intervalM;
    [SerializeField] [Tooltip("カメラが当たったら近づいてほしいオブジェクト")] private LayerMask objLayer;

    [Header("PlayerContoroller用")]
    [SerializeField] [Tooltip("カメラの水平")] public Quaternion rotateH;
    [SerializeField] [Tooltip("カメラの垂直")] public Quaternion rotateV;
    private RaycastHit hit;
    private Ray ray;
    private float distance;
    private Vector3 in_distance;
    public Vector3 hitPosition;

    // Start is called before the first frame update
    void Start()
    {
        //注目している所を設定
        transform.LookAt(targetObject.transform.position);

        //rotateH：水平方向の角度　rotateV：垂直方向の角度 の初期化
        rotateH = Quaternion.identity;
        rotateV = Quaternion.Euler(10, 0, 0);

        //回転の初期化
        this.transform.rotation = rotateH * rotateV;
        //位置の初期化
        this.transform.position = targetObject.transform.position - transform.rotation * Vector3.forward * intervalM;
        Debug.Log("transform.position : " + this.transform.position);


        in_distance = transform.position - targetObject.transform.position;
    }

    private void FixedUpdate()
    {
        //コントローラー用
        float horizon = Input.GetAxis("RsitckHorizontal");
        //キーボード用
        //float horizon = Input.GetAxis("ArrowX")* rotateSpeed;

        //ボタン操作による回転
        rotateH *= Quaternion.Euler(0, horizon, 0);

        ray = new Ray(targetObject.transform.position, this.transform.position - targetObject.transform.position);
        distance = Vector3.Distance(targetObject.transform.position, this.transform.position);
        Debug.Log(distance);
        //　レイを視覚的に確認
        Debug.DrawLine(targetObject.transform.position, this.transform.position, Color.red, 0f, true);
    }

    private void Update()
    {
        this.transform.rotation = rotateH * rotateV;
        if (Physics.Raycast(ray, out hit, distance, objLayer, QueryTriggerInteraction.Ignore) && distance < intervalM)
        {
            //hitPosition = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            Debug.Log("当たった場所：" + hitPosition);
            this.transform.position = hit.point;
        }
        else
        {
            this.transform.position = targetObject.transform.position - transform.rotation * Vector3.forward * intervalM;
        }
    }
}

