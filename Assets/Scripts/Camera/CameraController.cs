using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �J�������X�N���v�g�œ������\�[�X�R�[�h

public class CameraController : MonoBehaviour
{
    [Header("�J�����̐ݒ�")]
    [SerializeField, Tooltip("�J���������ڂ��Č���Ƃ���")] 
    private GameObject targetObject;
    [SerializeField, Tooltip("�J�����ƃv���C���[�Ƃ̋����̒���")] 
    private float length_CtoP;
    [SerializeField, Tooltip("�Փ˔���ɂȂ��Ăق����I�u�W�F�N�g")] 
    private LayerMask layerObj;

    [Header("PlayerContoroller�p")]
    [SerializeField, Tooltip("�J�����̐��������̒l")] 
    public Quaternion CameraH;
    [SerializeField, Tooltip("�J�����̐��������̒l")] 
    public Quaternion CameraV;

    // Ray�ɓ��������ʒu��ۑ�����ׂ̍\����
    private RaycastHit _raycastHit;

    // Ray�̊J�n�n�_��ۑ�����ϐ�
    private Ray _ray;

    // �v���C���[�ƃJ�����Ƃ̋�����ۑ�����ϐ�
    private float _distance;

    // �J�����̐��������̒l��ۑ�����ϐ�
    private Position _cameraH_quatePos = new Position(0.0f, 0.0f, 0.0f);

    // �J�����̐��������̏����l
    private Position _cameraV_quatePos = new Position(10.0f, 0.0f, 0.0f);

    // �R���g���[���[�̃{�^���̖��O
    private readonly string _buttonName = "RsitckHorizontal";

    // Start is called before the first frame update
    void Start()
    {
        // �J�����̒��ڂ��镔����ݒ�
        transform.LookAt(targetObject.transform.position);

        // CameraH�F���������̊p�x�@CameraV�F���������̊p�x �̏�����
        CameraH = Quaternion.identity;
        CameraV = Quaternion.Euler(_cameraV_quatePos.x, _cameraV_quatePos.y, _cameraV_quatePos.z);

        // ��]�̏�����
        this.transform.rotation = CameraH * CameraV;
        // �ʒu�̏�����
        this.transform.position = targetObject.transform.position - this.transform.rotation * Vector3.forward * length_CtoP;
    }

    private void FixedUpdate()
    {
        // �R���g���[���[�p
        _cameraH_quatePos.y = Input.GetAxis(_buttonName);

        // �{�^������ɂ���]
        CameraH *= Quaternion.Euler(_cameraH_quatePos.x, _cameraH_quatePos.y, _cameraH_quatePos.z);

        // �J�����ƃv���C���[�Ƃ̋����𑪒肷��
        _distance = Vector3.Distance(targetObject.transform.position, this.transform.position);

        // ray�̊J�n�n�_��ݒ肷��
        _ray = new Ray(targetObject.transform.position, this.transform.position - targetObject.transform.position);
    }

    private void Update()
    {
        // �J��������]�ړ�������
        this.transform.rotation = CameraH * CameraV;

        // �ǂɓ����������̏���
        // Physics.Raycast(ray�̊J�n�n�_ , ray�̕��� , ray���Փ˂����m����ő勗�� , �Փ˔���ɂ������I�u�W�F�N�g , �g���K�[�ɐݒ肵�Ă�����̂�Ώۂɂ��邩�̐ݒ�)
        if (Physics.Raycast(_ray, out _raycastHit, _distance, layerObj, QueryTriggerInteraction.Ignore) && _distance < length_CtoP)
        {
            // �J�����̈ʒu��Ray���Ԃ������ꏊ�Ɉړ�����
            this.transform.position = _raycastHit.point;
        }
        else
        {
            // �J�����̈ʒu�������ʒu�ɖ߂�
            this.transform.position = targetObject.transform.position - this.transform.rotation * Vector3.forward * length_CtoP;
        }
    }

    // ���W���Ǘ�����\����
    struct Position
    {
        public float x;
        public float y;
        public float z;

        // ����������֐�
        public Position(float _x, float _y, float _z)
        {
            x = _x;
            y = _y;
            z = _z;
        }
    }
}