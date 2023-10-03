using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("�J�����̐ݒ�")]
    [SerializeField, Range(-5.0f, 5.0f), Tooltip("��]�̃X�s�[�h")] private float rotateSpeed = 0.5f;
    [SerializeField, Tooltip("���ڂ��鏊")] private GameObject targetObject;
    [SerializeField, Tooltip("�J�����ƃv���C���[�Ƃ̋���")] private float intervalM;
    [SerializeField, Tooltip("�J����������������߂Â��Ăق����I�u�W�F�N�g")] private LayerMask objLayer;

    [Header("PlayerContoroller�p")]
    [SerializeField, Tooltip("�J�����̐���")] public Quaternion rotateH;
    [SerializeField, Tooltip("�J�����̐���")] public Quaternion rotateV;

    private RaycastHit hit;
    private Ray ray;

    private float distance;

    private Vector3 in_distance;
    public Vector3 hitPosition;

    // Start is called before the first frame update
    void Start()
    {
        // ���ڂ��Ă��鏊��ݒ�
        transform.LookAt(targetObject.transform.position);

        // rotateH�F���������̊p�x�@rotateV�F���������̊p�x �̏�����
        rotateH = Quaternion.identity;
        rotateV = Quaternion.Euler(10, 0, 0);

        // ��]�̏�����
        this.transform.rotation = rotateH * rotateV;
        // �ʒu�̏�����
        this.transform.position = targetObject.transform.position - transform.rotation * Vector3.forward * intervalM;

        // �J�����ƃv���C���[�Ƃ̋�����ۑ�����
        in_distance = transform.position - targetObject.transform.position;
    }

    private void FixedUpdate()
    {
        // �R���g���[���[�p
        float horizon = Input.GetAxis("RsitckHorizontal");

        // �L�[�{�[�h�p
        //float horizon = Input.GetAxis("ArrowX")* rotateSpeed;

        // �{�^������ɂ���]
        rotateH *= Quaternion.Euler(0, horizon, 0);

        // �J��������v���C���[�Ƀ��C�𐶐�����
        ray = new Ray(targetObject.transform.position, this.transform.position - targetObject.transform.position);

        // �J�����ƃv���C���[�Ƃ̋����𑪒肷��
        distance = Vector3.Distance(targetObject.transform.position, this.transform.position);
    }

    private void Update()
    {
        // �J��������]�ړ�������
        this.transform.rotation = rotateH * rotateV;

        // �ǂɓ����������̏���
        if (Physics.Raycast(ray, out hit, distance, objLayer, QueryTriggerInteraction.Ignore) && distance < intervalM)
        {
            //hitPosition = new Vector3(hit.point.x, hit.point.y, hit.point.z);

            this.transform.position = hit.point;
        }
        else
        {
            this.transform.position = targetObject.transform.position - transform.rotation * Vector3.forward * intervalM;
        }
    }
}