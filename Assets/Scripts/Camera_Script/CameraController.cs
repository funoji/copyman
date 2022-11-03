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
    //[SerializeField] [Tooltip("上方向の角度")] float angleUp = 70f;
    //[SerializeField] [Tooltip("下方向の角度")] float angleDown = -40f;
    //[SerializeField] [Tooltip("右方向の角度")] float angleRight = 90f;
    //[SerializeField] [Tooltip("左方向の角度")] float angleLeft = -90f;

    [SerializeField] [Tooltip("カメラとプレイヤーとの距離")] float intervalM = 10f;

    // Start is called before the first frame update
    void Start()
    {
        //注目している所を設定
        transform.LookAt(targetObject.transform.position);

        rotateH = Quaternion.identity;
        rotateV= Quaternion.Euler(30, 180, 0);
        transform.rotation = rotateH * rotateV;

        transform.position = targetObject.transform.position - transform.rotation * Vector3.forward * intervalM;
    }

    // Update is called once per frame
    void Update()
    {
        //Move();
    }

    private void LateUpdate()
    {
        //カメラと注目点の距離を更新
        //gameObject.transform.position = targetObject.transform.position - transform.forward * intervalM;

        if (!(Input.GetKey(KeyCode.W)))
            rotateH *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * rotateSpeed, 0);

        transform.rotation = rotateH * rotateV;
        transform.position = targetObject.transform.position - transform.rotation * Vector3.forward * intervalM;
    }

    public void Move()
    {
        /*
        //矢印キー
        float mouseInputX = Input.GetAxis("Mouse X");
        float mouseInputY = Input.GetAxis("Mouse Y");

        //矢印キー：移動のスピード
        rotateH = mouseInputX * rotateSpeed;
        rotateV = mouseInputY * rotateSpeed;

        //Xbox
        //float stickInputX = Input.GetAxis("RsitckHorizontal");
        //float stickInputY = Input.GetAxis("RsitckVerticl");

        //Xbox：移動のスピード
        //float rotateH = -stickInputX * rotateSpeed;
        //float rotateV = -stickInputY * rotateSpeed * 0.5f;

        //移動量を代入
        angleH += rotateH;
        angleV += rotateV;

        //角度の制限
        float angleLimitH = Mathf.Clamp(angleH, angleLeft, angleRight);
        float angleLimitV = Mathf.Clamp(angleV, angleDown, angleUp);

        //移動量と角度の距離を求める
        float overRangeH = angleH - angleLimitH;
        float overRangeV = angleV - angleLimitV;

        //��]�ʂ𒲐�
        //������̊p�x����
        rotateH -= overRangeH;
        rotateV -= overRangeV;
        angleH = angleLimitH;
        angleV = angleLimitV;

        transform.RotateAround(targetPosition, Vector3.up, rotateH); //Y軸の回転
        transform.RotateAround(targetPosition, transform.right, rotateV); //X軸の回転
        */
    }
}
