using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotateSpeed = 0.1f;
    [SerializeField] GameObject targetObject;
    Vector3 targetPosition;

    private float angleH;
    private float angleV;

    [SerializeField] float angleUp;
    [SerializeField] float angleDown;
    [SerializeField] float angleRight;
    [SerializeField] float angleLeft;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = targetObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        //プレイヤーに合わせてカメラの移動
        //transform.position += targetObject.transform.position - targetPosition;
        //targetPosition = targetObject.transform.position;

        //マウスの移動
        //float mouseInputX = Input.GetAxis("Mouse X");
        //float mouseInputY = Input.GetAxis("Mouse Y");

        //マウス移動量による回転角度
        //float rotateH = mouseInputX * rotateSpeed;
        //float rotateV = mouseInputY * rotateSpeed;

        //Xboxの移動
        float stickInputX = Input.GetAxis("RsitckHorizontal");
        float stickInputY = Input.GetAxis("RsitckVerticl");

        //Xbox移動量による回転角度
        float rotateH = -stickInputX * rotateSpeed;
        float rotateV = -stickInputY * rotateSpeed*0.5f;

        //角度を求める
        angleH += rotateH;
        angleV += rotateV;

        //移動角度制限
        float angleLimitH = Mathf.Clamp(angleH, angleLeft, angleRight);
        float angleLimitV = Mathf.Clamp(angleV, angleDown, angleUp);

        //制限範囲を超えたかを求める
        float overRangeH = angleH - angleLimitH;
        float overRangeV = angleV - angleLimitV;

        //回転量を調整
        //調整後の角度を代入
        rotateH -= overRangeH;
        rotateV -= overRangeV;
        angleH = angleLimitH;
        angleV = angleLimitV;

        transform.RotateAround(targetPosition, Vector3.up, rotateH); //Y軸中心に回転
        transform.RotateAround(targetPosition, transform.right, rotateV); //X軸中心に回転
    }
}
