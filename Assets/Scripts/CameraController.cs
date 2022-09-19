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
        //�v���C���[�ɍ��킹�ăJ�����̈ړ�
        //transform.position += targetObject.transform.position - targetPosition;
        //targetPosition = targetObject.transform.position;

        //�}�E�X�̈ړ�
        float mouseInputX = Input.GetAxis("Mouse X");
        float mouseInputY = Input.GetAxis("Mouse Y");

        //�}�E�X�ړ��ʂɂ���]�p�x
        float rotateH = mouseInputX * rotateSpeed;
        float rotateV = mouseInputY * rotateSpeed;

        //Xbox�̈ړ�
        //float stickInputX = Input.GetAxis("RsitckHorizontal");
        //float stickInputY = Input.GetAxis("RsitckVerticl");

        //Xbox�ړ��ʂɂ���]�p�x
        //float rotateH = -stickInputX * rotateSpeed;
        //float rotateV = -stickInputY * rotateSpeed*0.5f;

        //�p�x�����߂�
        angleH += rotateH;
        angleV += rotateV;

        //�ړ��p�x����
        float angleLimitH = Mathf.Clamp(angleH, angleLeft, angleRight);
        float angleLimitV = Mathf.Clamp(angleV, angleDown, angleUp);

        //�����͈͂𒴂����������߂�
        float overRangeH = angleH - angleLimitH;
        float overRangeV = angleV - angleLimitV;

        //��]�ʂ𒲐�
        //������̊p�x����
        rotateH -= overRangeH;
        rotateV -= overRangeV;
        angleH = angleLimitH;
        angleV = angleLimitV;

        transform.RotateAround(targetPosition, Vector3.up, rotateH); //Y�����S�ɉ�]
        transform.RotateAround(targetPosition, transform.right, rotateV); //X�����S�ɉ�]
    }
}
