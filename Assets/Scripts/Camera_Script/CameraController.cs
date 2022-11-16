using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("カメラの設定")]
    [SerializeField] [Range(0.0f, 5.0f), Tooltip("移動のスピード")] float rotateSpeed = 0.5f;
    [Space(5)]
    [SerializeField] [Tooltip("注目する所")] GameObject targetObject;
    [Space(5)]
    [SerializeField] [Tooltip("カメラとプレイヤーとの距離")] float intervalM = 10f;

    [Space(5)]
    [Header("PlayerContoroller用")]
    [SerializeField] [Tooltip("カメラの水平")] public Quaternion rotateH;
    [SerializeField] [Tooltip("カメラの垂直")] public Quaternion rotateV;

    // Start is called before the first frame update
    void Start()
    {
        //注目している所を設定
        transform.LookAt(targetObject.transform.position);

        rotateH = Quaternion.identity;
        rotateV = Quaternion.Euler(15, 180, 0);
        this.transform.rotation = rotateH * rotateV;
        this.transform.position = targetObject.transform.position - transform.rotation * Vector3.forward * intervalM;
    }

    private void LateUpdate()
    {
        //コントローラー用
        float conHorizon = Input.GetAxis("RsitckHorizontal");
        //キーボード用
        //float keyHorizon = Input.GetAxis("ArrowX");
        rotateH *= Quaternion.Euler(0, conHorizon, 0);
        transform.rotation = rotateH * rotateV;
        transform.position = targetObject.transform.position - transform.rotation * Vector3.forward * intervalM;
    }
}
