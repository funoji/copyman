using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] [Tooltip("移動のスピード")] float rotateSpeed = 0.5f;
    [SerializeField] [Tooltip("注目する所")] GameObject targetObject;
    private Vector3 targetPosition;

    private float angleH;
    private float angleV;
    public float Hrotation;

    [SerializeField] [Tooltip("上方向の角度")] float angleUp = 70f;
    [SerializeField] [Tooltip("下方向の角度")] float angleDown = -40f;
    [SerializeField] [Tooltip("右方向の角度")] float angleRight = 90f;
    [SerializeField] [Tooltip("左方向の角度")] float angleLeft = -90f;

    [SerializeField][Tooltip("カメラとプレイヤーとの距離")] float intervalM = 10f;

    // Start is called before the first frame update
    void Start()
    {
        //注目している所を設定
        transform.LookAt(targetObject.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        //カメラと注目点の距離を更新
        gameObject.transform.position = targetObject.transform.position - transform.forward * intervalM;

        //矢印キー
        //float mouseInputX = Input.GetAxis("ArrowX");
        //float mouseInputY = Input.GetAxis("ArrowY");

        //矢印キー：移動のスピード
        //float rotateH = mouseInputX * rotateSpeed;
        //float rotateV = mouseInputY * rotateSpeed;

        //Xbox
        float stickInputX = Input.GetAxis("RsitckHorizontal");
        float stickInputY = Input.GetAxis("RsitckVerticl");

        //Xbox：移動のスピード
        float rotateH = -stickInputX * rotateSpeed;
        float rotateV = -stickInputY * rotateSpeed * 0.5f;

        Hrotation = rotateH;

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
    }
}
