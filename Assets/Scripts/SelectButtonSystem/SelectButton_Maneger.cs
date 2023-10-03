using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;

public class SelectButton_Maneger : MonoBehaviour
{
    // �I����Ԃ̎��
    public enum ModeType
    {
        none,
        size,
        image,
        normal
    }

    public ModeType mode;

    //�{�^���̐ݒ�
    [System.Serializable]
    public struct SelectData
    {
        // Inspector�ŕ\�����閼�O
        public string buttonName;
        // Button�I�u�W�F�N�g�̕ϐ�
        public GameObject buttonObj;
        // Image�̕ϐ�
        public GameObject buttonImage;
        // �傫���̕ۑ��p�ϐ�
        [HideInInspector] public Vector3 _buttonScale;
    }
    public SelectData[] selectData;

    //�߂�{�^���̐ݒ�
    public bool ExitButton = true;

    [System.Serializable]
    public struct ExitData
    {
        // �I�u�W�F�N�g�̕ϐ�
        public GameObject exitButton;
        // �I�u�W�F�N�g��Image�̕ϐ�
        public GameObject exitImage;
        // �傫���̕ۑ��p�ϐ�
        [HideInInspector] public Vector3 _exitImage;
    }
    public ExitData exitData;

    // �I����Ԃ��T�C�Y�̕ύX���p�̕ϐ�
    // �T�C�Y���ς��X�s�[�h
    public float scallSpeed = 0.1f;
    // �傫�����ő�ɂȂ鎞��
    public float maxTime = 1f;
    // ���Ԃ̕ۑ��p�ϐ�
    private float time;
    // �ω�����傫���̒l��ۑ�����ϐ�
    private float scallSize;
    // �g��k���̔��������ϐ�
    private bool enlarge = true;

    // �I�������{�^���̕ۑ�����ϐ�
    private GameObject _button;

    // Event�̎擾
    public UnityEvent events = new UnityEvent();

    private void Start()
    {
        // �����̑I����Ԃ��X�^�[�g�{�^���ɐݒ� 
        if (ExitButton && selectData.Length == 0)
        {
            EventSystem.current.SetSelectedGameObject(exitData.exitButton);
        }
        else
        {
            EventSystem.current.SetSelectedGameObject(selectData[0].buttonObj);
        }


        // ���[�h���Ƃ̏�����
        if (mode == ModeType.size)
        {
            // �����̑傫����ۑ�
            for (int num = 0; num < selectData.Length; num++)
            {
                selectData[num]._buttonScale = selectData[num].buttonImage.transform.localScale;
            }
        }
        if (mode == ModeType.image)
        {
            // �����̕\����ݒ�
            for (int num = 0; num < selectData.Length; num++)
            {
                selectData[num].buttonImage.SetActive(false);
            }
        }
        if (ExitButton)
        {
            exitData._exitImage = exitData.exitImage.transform.localScale;
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
        //���ݑI�𒆂̃{�^����ۑ� 
        _button = EventSystem.current.currentSelectedGameObject;

        //�R���g���[���[�p�@�{�^���I����Ԃ̐ݒ�
        if (Input.GetKeyDown(KeyCode.Joystick1Button1) && ExitButton == true)
        {
            EventSystem.current.SetSelectedGameObject(exitData.exitButton); events.Invoke();
        }

        //�I������Ă���{�^�����g��k��������B�I������珉���̑傫���ɖ߂� 
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

        if (ExitButton)
        {
            if (_button == exitData.exitButton)
            {
                Scaling(exitData.exitImage);
            }
            else if (_button != exitData.exitButton)
            {
                exitData.exitImage.transform.localScale = Reset_ImageScale(exitData._exitImage);
            }
        }
    }

    //�I����ԁF�m�[�}��
    public void Select_Normal()
    {
        //���ݑI�𒆂̃{�^����ۑ� 
        _button = EventSystem.current.currentSelectedGameObject;

        //�R���g���[���[�p�@�{�^���I����Ԃ̐ݒ�
        if (Input.GetKeyDown(KeyCode.Joystick1Button1) && ExitButton == false)
        {
            EventSystem.current.SetSelectedGameObject(selectData[1].buttonObj); events.Invoke();
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button1) && ExitButton == true)
        {
            EventSystem.current.SetSelectedGameObject(exitData.exitButton); events.Invoke();
        }
    }

    //�I����ԁF�傫��
    public void Select_Size()
    {
        //���ݑI�𒆂̃{�^����ۑ�
        _button = EventSystem.current.currentSelectedGameObject;

        //�R���g���[���[�p�@�{�^���I����Ԃ̐ݒ�
        if (Input.GetKeyDown(KeyCode.Joystick1Button1) && ExitButton == true)
        {
            EventSystem.current.SetSelectedGameObject(exitData.exitButton); events.Invoke();
        }

        //�I������Ă���{�^�����g��k��������B�I������珉���̑傫���ɖ߂� 
        for (int num = 0; num < selectData.Length; num++)
        {
            if (_button == selectData[num].buttonObj)
            {
                Scaling(selectData[num].buttonImage);
            }
            else
            {
                selectData[num].buttonImage.transform.localScale = Reset_ImageScale(selectData[num]._buttonScale);
            }
        }

        if (ExitButton)
        {
            if (_button == exitData.exitButton)
            {
                Scaling(exitData.exitImage);
            }
            else if (_button != exitData.exitButton)
            {
                exitData.exitImage.transform.localScale = Reset_ImageScale(exitData._exitImage);
            }
        }
    }
    //�g��k���̉��o�̏���
    void Scaling(GameObject image)
    {
        scallSize = Time.deltaTime * scallSpeed;

        if (time < 0) { enlarge = true; }
        if (time > maxTime) { enlarge = false; }

        if (enlarge)
        {
            time += Time.deltaTime;
            image.transform.localScale += new Vector3(scallSize, scallSize, scallSize);
        }
        else
        {
            time -= Time.deltaTime;
            image.transform.localScale -= new Vector3(scallSize, scallSize, scallSize);
        }
    }

    //�傫���̏�����
    Vector3 Reset_ImageScale(Vector3 afterObj)
    {
        return afterObj;
    }
}
