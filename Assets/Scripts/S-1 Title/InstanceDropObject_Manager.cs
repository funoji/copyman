using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceDropObject_Manager : MonoBehaviour
{
    [Header("���o�p�̗����I�u�W�F�N�g�̏���")]
    [SerializeField, Tooltip("��������͈͎n�܂�")] private Transform rangeA;
    [SerializeField, Tooltip("��������͈͏I���")] private Transform rangeB;
    [SerializeField, Range(0, 10), Tooltip("�����������")] private float cycle;

    // �v�����鎞�Ԃ�ۑ�����ϐ�
    private float time;
    // Rigidbody��ۑ�����ϐ�
    private Rigidbody rb;
    // Quaternion��ۑ�����ϐ�
    private Quaternion rotation;
    // �I�u�W�F�N�g�̑傫����ۑ�����ϐ�
    private Vector3 scale;
    // ���������I�u�W�F�N�g�p�̕ϐ�
    private GameObject instansObj;
    // Random�̐��l��ۑ�����ϐ�
    private int instanNum;

    [Header("�����_���l�̐ݒ�")]
    [SerializeField, Range(0, 100), Tooltip("�X�P�[���̍ŏ��l")] private float scaleMin;
    [SerializeField, Range(0, 100), Tooltip("�X�P�[���̍ő�l")] private float scaleMax;
    [SerializeField, Range(-360, 360), Tooltip("��]�̍ŏ��l")] private float rotaMin;
    [SerializeField, Range(-360, 360), Tooltip("��]�̍ő�l")] private float rotaMax;
    [SerializeField, Range(0, 10), Tooltip("������X�s�[�h�̍ŏ��l")] private float dragMin;
    [SerializeField, Range(0, 10), Tooltip("������X�s�[�h�̍ő�l")] private float dragMax;
    [SerializeField, Range(0, 10), Tooltip("��]�X�s�[�h�̍ŏ��l")] private float angleDragMin;
    [SerializeField, Range(0, 10), Tooltip("��]�X�s�[�h�̍ő�l")] private float angleDragMax;
    [SerializeField, Range(0, 1000), Tooltip("�����X�s�[�h�̍ŏ��l")] private float speedMin;
    [SerializeField, Range(0, 1000), Tooltip("�����X�s�[�h�̍ő�l")] private float speedMax;

    [Header("�\������I�u�W�F�N�g")]
    [Tooltip("��������I�u�W�F�N�g")] public GameObject[] creatPrefab;

    // Update is called once per frame
    void Update()
    {
        // ���Ԃ����Z
        time = time + Time.deltaTime;

        // �����I�u�W�F�N�g�̎�ނ̃����_��
        instanNum = Random.Range(0, creatPrefab.Length);

        // �����I�u�W�F�N�g�̑傫�����擾
        scale = creatPrefab[instanNum].transform.localScale;

        // �����I�u�W�F�N�g��ribidbody���擾
        rb = creatPrefab[instanNum].GetComponent<Rigidbody>();

        // Constans�̏�����
        rb.constraints = RigidbodyConstraints.None;

        // �����I�u�W�F�N�g�̑傫���̃����_��
        float scaleRandom = Random.Range(scaleMin, scaleMax);

        // �����I�u�W�F�N�g�̉�]�p�x�̃����_��
        float rotRandom = Random.Range(-rotaMin, rotaMax);
        rotation = Quaternion.Euler(rotRandom, rotRandom, rotRandom);

        // �����I�u�W�F�N�g�̃X�s�[�h�̃����_��
        float speedRandom = Random.Range(speedMin, speedMax);

        // �ݒ肵���b�������ŏ���
        if (time > cycle)
        {
            // �����I�u�W�F�N�g�̈ʒu�̃����_��
            float x = Random.Range(rangeA.position.x, rangeB.position.x);
            float y = Random.Range(rangeA.position.y, rangeB.position.y);
            float z = Random.Range(rangeA.position.z, rangeB.position.z);

            // �����I�u�W�F�N�g�𐶐�
            instansObj = Instantiate(creatPrefab[instanNum], new Vector3(x, y, z), rotation);

            // �����I�u�W�F�N�g�̑傫����ύX
            instansObj.transform.localScale = new Vector3(scale.x * scaleRandom, scale.y * scaleRandom, scale.z * scaleRandom);

            // �����I�u�W�F�N�g�̗����X�s�[�h�Ɖ�]�X�s�[�h��ύX
            rb.drag = Random.Range(-dragMin, dragMax);
            rb.AddForce(0, -speedRandom, 0);
            //rb.angularDrag = Random.Range(angleDragMin, angleDragMax);

            // ���Ԃ�������
            time = 0f;
        }
    }
}
