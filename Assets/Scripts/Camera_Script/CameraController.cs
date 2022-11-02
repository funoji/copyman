using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("カメラの設定")]
    [SerializeField] [Range(0.0f, 5.0f), Tooltip("移動のスピード")] float rotateSpeed = 0.5f;
    [Space(5)]
    [SerializeField] [Tooltip("注目する所")] GameObject targetObject;
    private Vector3 targetPosition;

    private float angleH;
    private float angleV;
    [SerializeField] [Tooltip("カメラの水平")] public Quaternion rotateH;
    [SerializeField] [Tooltip("カメラの垂直")] public Quaternion rotateV;

    [Space(5)]
    [SerializeField] [Tooltip("上方向の角度")] float angleUp = 70f;
    [SerializeField] [Tooltip("下方向の角度")] float angleDown = -40f;
    [SerializeField] [Tooltip("右方向の角度")] float angleRight = 90f;
    [SerializeField] [Tooltip("左方向の角度")] float angleLeft = -90f;

    [SerializeField] [Tooltip("カメラとプレイヤーとの距離")] float intervalM = 10f;

    // Start is called before the first frame update
    void Start()
    {
        //注目している所を設定
        transform.LookAt(targetObject.transform.position);

        rotateH = Quaternion.identity;
        rotateV= Quaternion.Euler(30, 0, 0);
        transform.rotation = rotateH * rotateV;

        transform.position = targetObject.transform.position - transform.rotation * Vector3.forward * intervalM;
    }

    private void LateUpdate()
    {
        if (!(Input.GetKey(KeyCode.W)))
            rotateH *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * rotateSpeed, 0);
        else
            rotateH *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * rotateSpeed, 0);

        transform.rotation = rotateH * rotateV;
        transform.position = targetObject.transform.position - transform.rotation * Vector3.forward * intervalM;
    }
}
