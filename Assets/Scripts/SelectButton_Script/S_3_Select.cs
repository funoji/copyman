using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class S_3_Select : MonoBehaviour
{
    [Header("Button1")]
    [SerializeField] [Tooltip("�uButton1�v�̃{�^��")] private GameObject mainButton;
    [SerializeField] [Tooltip("�uButton1�v�̃C���[�W")] private GameObject mainImage;
    [SerializeField] [Tooltip("�uButton1�v�̑I�𒆃C���[�W")] private GameObject mainImage_back;
    private Vector3 _mainScale;
    [Space(5)]
    [Header("Button2")]
    [SerializeField] [Tooltip("�uButton2�v�̃{�^��")] private GameObject sub1Button;
    [SerializeField] [Tooltip("�uButton2�v�̃C���[�W")] private GameObject sub1Image;
    [SerializeField] [Tooltip("�uButton2�v�̑I�𒆃C���[�W")] private GameObject sub1Image_back;
    private Vector3 _sub1Scale;
    [Space(5)]
    [Header("Button3")]
    [SerializeField] [Tooltip("�uButton3�v�̃{�^��")] private GameObject sub2Button;
    [SerializeField] [Tooltip("�uButton3�v�̃C���[�W")] private GameObject sub2Image;
    [SerializeField] [Tooltip("�uButton3�v�̑I�𒆃C���[�W")] private GameObject sub2Image_back;
    private Vector3 _sub2Scale;
    [Space(5)]
    [Header("Button4")]
    [SerializeField] [Tooltip("�uButton4�v�̃{�^��")] private GameObject sub3Button;
    [SerializeField] [Tooltip("�uButton4�v�̃C���[�W")] private GameObject sub3Image;
    [SerializeField] [Tooltip("�uButton4�v�̑I�𒆃C���[�W")] private GameObject sub3Image_back;
    private Vector3 _sub3Scale;
    [Space(5)]
    [Header("�߂�")]
    [SerializeField] [Tooltip("�u�߂�v�̃{�^��")] private GameObject ExitButton;
    [SerializeField] [Tooltip("�u�߂�v�̃C���[�W")] private GameObject ExitImage;
    [SerializeField] [Tooltip("�u�߂�v�̑I�𒆃C���[�W")] private GameObject ExitImage_back;
    private Vector3 _ExitScale;
    private GameObject button;

    [Space(10)]
    [Header("�g��k���̉��o�p")]
    [SerializeField] [Tooltip("�ω����鑬��")] private float scallSpeed;
    [SerializeField] [Tooltip("�g��k���̎���")] private float maxTime;
    private float time;
    private bool enlarge = true;
    // Start is called before the first frame update
    void Start()
    {
        //�����̑I����Ԃ��X�^�[�g�{�^���ɐݒ� : Set initial selection status to Start button
        EventSystem.current.SetSelectedGameObject(mainButton);

        //�����̑傫����ۑ� : Save initial size
        _mainScale = mainImage.transform.localScale;
        _sub1Scale = sub1Image.transform.localScale;
        _sub2Scale = sub2Image.transform.localScale;
        _sub3Scale = sub3Image.transform.localScale;
        _ExitScale = ExitImage.transform.localScale;

        //�����̕\����ݒ�
        mainImage_back.SetActive(false);
        sub1Image_back.SetActive(false);
        sub2Image_back.SetActive(false);
        sub3Image_back.SetActive(false);
        ExitImage_back.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //���ݑI�𒆂̃{�^����ۑ� : Save the currently selected button
        button = EventSystem.current.currentSelectedGameObject;
        Debug.Log(button.name);

        //�R���g���[���[�p�@�{�^���I����Ԃ̐ݒ� : For Controller Set button selection status
        if (Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            EventSystem.current.SetSelectedGameObject(ExitButton);
        }

        //�I������Ă���{�^�����g��k��������B�I������珉���̑傫���ɖ߂� : Scale the selected button. When done, return to initial size.
        if (button == sub1Button)
        {
            Scaling(sub1Image);
            sub1Image_back.SetActive(true);
        }
        else if (button != sub1Button)
        {
            sub1Image.transform.localScale = Reset_ImageScale(_sub1Scale);
            sub1Image_back.SetActive(false);
        }
        if (button == sub2Button)
        {
            Scaling(sub2Image);
            sub2Image_back.SetActive(true);
        }
        else if (button != sub2Button)
        {
            sub2Image.transform.localScale = Reset_ImageScale(_sub2Scale);
            sub2Image_back.SetActive(false);
        }
        if (button == sub3Button)
        {
            Scaling(sub3Image);
            sub3Image_back.SetActive(true);
        }
        else if (button != sub3Button)
        {
            sub3Image.transform.localScale = Reset_ImageScale(_sub3Scale);
            sub3Image_back.SetActive(false);
        }
        if (button == mainButton)
        {
            Scaling(mainImage);
            mainImage_back.SetActive(true);
        }
        else if (button != mainButton)
        {
            mainImage.transform.localScale = Reset_ImageScale(_mainScale);
            mainImage_back.SetActive(false);
        }
        if (button == ExitButton)
        {
            Scaling(ExitImage);
            ExitImage_back.SetActive(true);
        }
        else if (button != ExitButton)
        {
            ExitImage.transform.localScale = Reset_ImageScale(_ExitScale);
            ExitImage_back.SetActive(false);
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
            image.transform.localScale -= new Vector3(scallSpeed, scallSpeed, scallSpeed);
        }
    }

    //�傫���̏����� : Size initialization
    Vector3 Reset_ImageScale(Vector3 afterObj)
    {
        return afterObj;
    }
}
