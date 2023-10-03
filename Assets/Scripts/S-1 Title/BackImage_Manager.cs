using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackImage_Manager : MonoBehaviour
{
    // �w�i�摜��\�����邽�߂ɃI�u�W�F�N�g�ƂƂ��Ď擾
    [SerializeField] private GameObject[] _image = new GameObject[5];

    // �摜���؂�ւ�鎞�Ԃ�ۑ�����ϐ�
    [SerializeField, Range(0, 10)] private int _imageTime = 0;

    // �R���[�`���𕡐��Ăяo���Ȃ����߂̕ϐ�
    private bool _isCortine;

    // Start is called before the first frame update
    void Start()
    {
        // ������
        for (int i = 0; i < _image.Length; i++)
        {
            _image[i].SetActive(false);
        }

        _isCortine = false;
    }

    // Update is called once per frame
    void Update()
    {
        // �R���[�`�����Ăяo�����߂̏���
        if (!_isCortine)
        {
            _isCortine = true;
            StartCoroutine("Display_Image");
        }
    }

    // �w�i�摜�̉��o�̃R���[�`��
    IEnumerator Display_Image()
    {
        for (int i = 0; i < _image.Length; i++)
        {
            // �摜��\��
            _image[i].SetActive(true);

            // ������҂�
            yield return new WaitForSeconds(_imageTime);

            // �摜���\���ɂ���
            _image[i].SetActive(false);
        }

        // ����𖳌��ɂ���
        _isCortine = false;
    }
}
