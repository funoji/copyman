using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("カメラの設定")]
    [SerializeField] [Range(0.0f, 5.0f), Tooltip("移動のスピード")] float rotateSpeed = 0.5f;
    [Space(5)]
    [SerializeField] [Tooltip("注目する所")] GameObject targetObject;
    [SerializeField] [Tooltip("カメラお🄱ジェクト")] private Camera maincamera;
    private Vector3 targetPosition;

    private float angleH;
    private float angleV;
    [SerializeField] [Tooltip("カメラの水平")] public Quaternion rotateH;
    [SerializeField] [Tooltip("カメラの垂直")] public Quaternion rotateV;

    [Space(5)]
    [SerializeField] [Tooltip("カメラとプレイヤーとの距離")] float intervalM = 10f;

    public PlayerController horizontal;

    // Start is called before the first frame update
    void Start()
    {
        //注目している所を設定
        transform.LookAt(targetObject.transform.position);

        rotateH = Quaternion.identity;
        rotateV = Quaternion.Euler(15, 180, 0);
        maincamera.transform.rotation = rotateH * rotateV;

        maincamera.transform.position = targetObject.transform.position - transform.rotation * Vector3.forward * intervalM;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LateUpdate()
    {
        float conHorizon = Input.GetAxis("RsitckHorizontal");
        rotateH *= Quaternion.Euler(0, conHorizon * rotateSpeed, 0);
        maincamera.transform.rotation = rotateH * rotateV;

        //Debug.Log(conHorizon);

        //Debug.DrawLine(targetObject.transform.position, transform.position, Color.red, 0f, false);

        maincamera.transform.position = targetObject.transform.position - transform.rotation * Vector3.forward * intervalM;
    }
}
