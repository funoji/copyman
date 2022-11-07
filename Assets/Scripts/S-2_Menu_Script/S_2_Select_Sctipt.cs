using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class S_2_Select_Sctipt : MonoBehaviour
{
    [Header("�X�N���v�g���Q��")]
    public Transtion transtion;

    [Space(8)]
    [Header("�Q�[���X�^�[�g / �X�e�[�W�I��")]
    [SerializeField] [Tooltip("�u�Q�[���X�^�[�g / �X�e�[�W�I���v�̃{�^��")] private GameObject mainButton;
    [SerializeField] [Tooltip("�u�Q�[���X�^�[�g / �X�e�[�W�I���v�̃C���[�W")] private GameObject mainImage;
    [SerializeField] [Tooltip("�u�Q�[���X�^�[�g / �X�e�[�W�I���v�̕ۑ��p�ϐ�")] private Vector3 _mainScale;
    [Space(5)]
    [Header("�A�C�e���}��")]
    [SerializeField] [Tooltip("�u�A�C�e���}�Ӂv�̃{�^��")] private GameObject itemButton;
    [SerializeField] [Tooltip("�u�A�C�e���}�Ӂv�̃C���[�W")] private GameObject itemImage;
    [SerializeField] [Tooltip("�u�A�C�e���}�Ӂv�̕ۑ��p�ϐ�")] private Vector3 _itemScale;
    [Space(5)]
    [Header("�I�v�V����")]
    [SerializeField] [Tooltip("�u�I�v�V�����v�̃{�^��")] private GameObject optionButton;
    [SerializeField] [Tooltip("�u�I�v�V�����v�̃C���[�W")] private GameObject optionImage;
    [SerializeField] [Tooltip("�u�I�v�V�����v�̕ۑ��p�ϐ�")] private Vector3 _optionScale;
    [Space(5)]
    [Header("�߂�")]
    [SerializeField] [Tooltip("�u�߂�v�̃{�^��")] private GameObject ExitButton;
    [SerializeField] [Tooltip("�u�߂�v�̃C���[�W")] private GameObject ExitImage;
    [SerializeField] [Tooltip("�u�߂�v�̕ۑ��p�ϐ�")] private Vector3 _ExitScale;
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
        _itemScale= itemImage.transform.localScale;
        _optionScale = optionImage.transform.localScale;
        _ExitScale = ExitImage.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        //���ݑI�𒆂̃{�^����ۑ� : Save the currently selected button
        button = EventSystem.current.currentSelectedGameObject;
        //Debug.Log(button.name);

        ////�L�[�{�[�h�p�@�{�^���̑I����Ԃ̐ݒ� : For keyboard Set button selection status
        //if (Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    if(button== optionButton)
        //        EventSystem.current.SetSelectedGameObject(mainButton);
        //    if(button== itemButton)
        //        EventSystem.current.SetSelectedGameObject(mainButton);
        //}
        //if (Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    if (button == mainButton)
        //        EventSystem.current.SetSelectedGameObject(itemButton);
        //}
        //if (Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    if (button == optionButton)
        //        EventSystem.current.SetSelectedGameObject(itemButton);
        //}
        //if (Input.GetKeyDown(KeyCode.DownArrow))
        //{
        //    if (button == itemButton)
        //        EventSystem.current.SetSelectedGameObject(optionButton);
        //}
        //if (Input.GetKeyDown(KeyCode.B))
        //{
        //    Debug.Log("�����ꂽ�B");
        //}

        //�R���g���[���[�p�@�{�^���I����Ԃ̐ݒ� : For Controller Set button selection status
        if (Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            EventSystem.current.SetSelectedGameObject(ExitButton);
            Debug.Log("�����ꂽ�B");
            transtion.Trasn_ToTitle();
        }

            //�I������Ă���{�^�����g��k��������B�I������珉���̑傫���ɖ߂� : Scale the selected button. When done, return to initial size.
            if (button == optionButton)
            Scaling(optionImage);
        else if (button != optionButton)
            optionImage.transform.localScale = Reset_ImageScale(_optionScale);
        if (button == itemButton)
            Scaling(itemImage);
        else if (button != itemButton)
            itemImage.transform.localScale = Reset_ImageScale(_itemScale);
        if (button == mainButton)
            Scaling(mainImage);
        else if (button != mainButton)
            mainImage.transform.localScale = Reset_ImageScale(_mainScale);
        if (button == ExitButton)
            Scaling(ExitImage);
        else if (button != ExitButton)
            ExitImage.transform.localScale = Reset_ImageScale(_ExitScale);

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
        return  afterObj;
    }
}
