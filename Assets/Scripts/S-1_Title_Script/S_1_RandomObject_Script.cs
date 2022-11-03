using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_1_RandomObject_Script : MonoBehaviour
{
    [Header("���o�p�̗����I�u�W�F�N�g�̏���")]
    [SerializeField][Tooltip("��������I�u�W�F�N�g")] private GameObject creatPrefab;
    [SerializeField] [Tooltip("��������͈͎n�܂�")] private Transform rangeA;
    [SerializeField] [Tooltip("��������͈͏I���")] private Transform rangeB;

    [SerializeField][Tooltip("�����������")] public float cycle;
    private float time;
    [Space(10)]
    private Rigidbody rb;
    private Quaternion rotation;
    private Vector3 scale;

    [Header("�����_���l�̐ݒ�")]
    [SerializeField] [Tooltip("�X�P�[���̍ŏ��l")] private float scaleMin;
    [SerializeField] [Tooltip("�X�P�[���̍ő�l")] private float scaleMax;
    [SerializeField] [Tooltip("��]�̍ŏ��l")] private float rotaMin;
    [SerializeField] [Tooltip("��]�̍ő�l")] private float rotaMax;
    [SerializeField] [Tooltip("������X�s�[�h�̍ŏ��l")] private float dragMin;
    [SerializeField] [Tooltip("������X�s�[�h�̍ő�l")] private float dragMax;
    [SerializeField] [Tooltip("��]�X�s�[�h�̍ŏ��l")] private float angleMin;
    [SerializeField] [Tooltip("��]�X�s�[�h�̍ő�l")] private float angleMax;

    // Start is called before the first frame update
    void Start()
    {
        scale = creatPrefab.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        //���Ԃ����Z : Add time
        time = time + Time.deltaTime;

        //�����I�u�W�F�N�g��ribidbody���擾 : Get "ridbody" of the falling object
        rb = creatPrefab.GetComponent<Rigidbody>();

        //�����I�u�W�F�N�g�̑傫���̃����_�� : Random size of falling objects
        float scaleRandom = Random.Range(scaleMin, scaleMax);

        //�����I�u�W�F�N�g�̉�]�p�x�̃����_�� : Random angle of rotation of falling objects
        float rotRandom = Random.Range(-rotaMin, rotaMax);
        rotation = Quaternion.Euler(rotRandom, rotRandom, rotRandom);

        //�ݒ肵���b�������ŏ��� : Processed in a set number of second cycles
        if (time > cycle)
        {
            //�����I�u�W�F�N�g�̈ʒu�̃����_�� : Random position of falling objects
            float x = Random.Range(rangeA.position.x, rangeB.position.x);
            float y = Random.Range(rangeA.position.y, rangeB.position.y);
            float z = Random.Range(rangeA.position.z, rangeB.position.z);

            //�����I�u�W�F�N�g�𐶐� : Generate falling objects
            Instantiate(creatPrefab, new Vector3(x, y, z), rotation);

            //�����I�u�W�F�N�g�̑傫����ύX : Change size of falling objects
            creatPrefab.transform.localScale = new Vector3(scale.x * scaleRandom, scale.y * scaleRandom, scale.z * scaleRandom);

            //�����I�u�W�F�N�g�̗����X�s�[�h�Ɖ�]�X�s�[�h��ύX : Change falling speed and rotation speed of falling objects
            rb.drag = Random.Range(-dragMin, dragMax);
            rb.angularDrag = Random.Range(angleMin, angleMax);

            //���ԏ����� : time initialization
            time = 0f;
        }
    }
}
