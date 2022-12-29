using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class S_3_Select : MonoBehaviour
{
    //�I����Ԃ̎��
    public enum ModeType
    {
        size,
        image,
        normal
    }

    public ModeType mode;

    //�{�^���̒��g
    [System.Serializable]
    public struct SelectData
    {
        public string buttonName;
        public GameObject buttonObj;
        public GameObject buttonImage;
        public Vector3 _buttonScale;
    }
    [SerializeField]
    public SelectData[] selectData;

    //�I����Ԃ��T�C�Y�̕ύX���p�̕ϐ�
    public float scallSpeed;
    public  float maxTime;
    private float time;
    private bool enlarge = true;

    //�I�������{�^���̕ۑ�����ϐ�
    private GameObject _button;

    private void Start()
    {
        //�����̑I����Ԃ��X�^�[�g�{�^���ɐݒ� : Set initial selection status to Start button
        EventSystem.current.SetSelectedGameObject(selectData[0].buttonObj);
        Debug.Log(selectData[0].buttonObj);

        //���[�h���Ƃ̏�����
        if (mode == ModeType.size)
        {
            //�����̑傫����ۑ�
            for (int num = 0; num < selectData.Length; num++)
            {
                selectData[num]._buttonScale = selectData[num].buttonImage.transform.localScale;
            }
        }
        if (mode == ModeType.image)
        {
            //�����̕\����ݒ�
            for (int num = 0; num < selectData.Length; num++)
            {
                selectData[num].buttonImage.SetActive(false);
            }
        }
    }

    //�e���[�h�̎��̏���
    private void Update()
    {
        if (mode == ModeType.size)
        {
            Select_Size();
        }
        if (mode == ModeType.image)
        {
            Select_Image();
        }
        if (mode == ModeType.normal)
        {
            Select_Normal();
        }
    }

    //�I����ԁF�摜
    public void Select_Image()
    {
        //���ݑI�𒆂̃{�^����ۑ� : Save the currently selected button
        _button = EventSystem.current.currentSelectedGameObject;
        Debug.Log(_button.name);

        //�R���g���[���[�p�@�{�^���I����Ԃ̐ݒ� : For Controller Set button selection status
        if (Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            EventSystem.current.SetSelectedGameObject(selectData[1].buttonObj);
        }

        //�I������Ă���{�^�����g��k��������B�I������珉���̑傫���ɖ߂� : Scale the selected button. When done, return to initial size.
        for (int num = 0; num < selectData.Length; num++)
        {
            if (_button == selectData[num].buttonObj)
            {
                selectData[num].buttonImage.SetActive(true);
            }
            else if (_button != selectData[num].buttonObj)
            {
                selectData[num].buttonImage.SetActive(false);
            }
        }
    }

    //�I����ԁF�m�[�}��
    public void Select_Normal()
    {
        //���ݑI�𒆂̃{�^����ۑ� : Save the currently selected button
        _button = EventSystem.current.currentSelectedGameObject;
        //Debug.Log(_button.name);

        //�R���g���[���[�p�@�{�^���I����Ԃ̐ݒ� : For Controller Set button selection status
        if (Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            EventSystem.current.SetSelectedGameObject(selectData[1].buttonObj);
        }
    }

    //�I����ԁF�傫��
    public void Select_Size()
    {
        //���ݑI�𒆂̃{�^����ۑ� : Save the currently selected button
        _button = EventSystem.current.currentSelectedGameObject;
        //Debug.Log(_button.name);

        //�R���g���[���[�p�@�{�^���I����Ԃ̐ݒ� : For Controller Set button selection status
        if (Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            EventSystem.current.SetSelectedGameObject(selectData[1].buttonObj);
        }

        //�I������Ă���{�^�����g��k��������B�I������珉���̑傫���ɖ߂� : Scale the selected button. When done, return to initial size.
        for (int num = 0; num < selectData.Length; num++)
        {
            if (_button == selectData[num].buttonObj)
            {
                Scaling(selectData[num].buttonImage);
            }
            else if (_button != selectData[num].buttonObj)
            {
                selectData[num].buttonImage.transform.localScale = Reset_ImageScale(selectData[num]._buttonScale);
            }
        }
    }
    //�g��k���̉��o�̏��� : Processing of scaling direction
    void Scaling(GameObject image)
    {
        scallSpeed = Time.deltaTime * 0.1f;

        if (time < 0)
            enlarge = true;
        if (time > maxTime)
            enlarge = false;

        if (enlarge)
        {
            time += Time.deltaTime;
            image.transform.localScale += new Vector3(scallSpeed, scallSpeed, scallSpeed);
        }
        else
        {
            time -= Time.deltaTime;
            image.transform.localScale -= new Vector3(scallSpeed,scallSpeed, scallSpeed);
        }
    }

    //�傫���̏����� : Size initialization
    Vector3 Reset_ImageScale(Vector3 afterObj)
    {
        return afterObj;
    }
}
