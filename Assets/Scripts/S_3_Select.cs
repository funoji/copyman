using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class S_3_Select : MonoBehaviour
{
    [Header("Master")]
    [SerializeField] [Tooltip("�uMaster�v�X�����_�[")] private GameObject select_Master;
    [SerializeField] [Tooltip("�uMaster�v�̃C���[�W")] private GameObject masterImage;
    [SerializeField] TextMeshProUGUI masterText;
    //[SerializeField] [Tooltip("�uMaster�v�̕ۑ��p�ϐ�")] private Vector3 _masterImage;

    [Space(10)]
    [Header("BGM")]
    [SerializeField] [Tooltip("�uBGM�v�X�����_�[")] private GameObject select_BGM;
    [SerializeField] [Tooltip("�uBGM�v�̃C���[�W")] private GameObject bgmImage;
    [SerializeField] TextMeshProUGUI bgmText;
    //[SerializeField] [Tooltip("�uBGM�v�̕ۑ��p�ϐ�")] private Vector3 _bgmImage;

    [Space(10)]
    [Header("SE")]
    [SerializeField] [Tooltip("�uSE�v�X�����_�[")] private GameObject select_SE;
    [SerializeField] [Tooltip("�uSE�v�̃C���[�W")] private GameObject seImage;
    [SerializeField] TextMeshProUGUI seText;
    //[SerializeField] [Tooltip("�uSE�v�̕ۑ��p�ϐ�")] private Vector3 _seImage;

    [Space(10)]
    [Header("�Q�[���I��")]
    [SerializeField] [Tooltip("�u�Q�[���I���v�{�^��")] private GameObject endgame_Button;
    [SerializeField] [Tooltip("�u�Q�[���I���v�̃C���[�W")] private GameObject endgameImage;
    [SerializeField] [Tooltip("�u�Q�[���I���v�̕ۑ��p�ϐ�")] private Vector3 _endgameImage;

    [Space(10)]
    [Header("�߂�")]
    [SerializeField] [Tooltip("�u�߂�v�{�^��")] private GameObject toMenuButton;
    [SerializeField] [Tooltip("�u�߂�v�̃C���[�W")] private GameObject menuImage;
    [SerializeField] [Tooltip("�u�߂�v�̕ۑ��p�ϐ�")] private Vector3 _menuImage;
    private GameObject button;

    [Space(20)]
    [Header("�g��k���̉��o�p")]
    [SerializeField] [Tooltip("�ω����鑬��")] private float scallSpeed;
    [SerializeField] [Tooltip("�g��k���̎���")] private float maxTime;
    private float time;
    private bool enlarge = true;

    private void Start()
    {
        //�����̑I����Ԃ��X�^�[�g�{�^���ɐݒ� : Set initial selection status to Start button
        EventSystem.current.SetSelectedGameObject(select_Master);

        _endgameImage= endgameImage.transform.localScale;
        _menuImage = menuImage.transform.localScale;
    }

    private void Update()
    {
        button = EventSystem.current.currentSelectedGameObject;
        Debug.Log(button);
        //if (button != null) Debug.Log("NUll");

        if (button == select_Master)
        {
            Select_Active(masterImage);
            masterText.color = Cheng_Select();
        }
        else if (button != select_Master)
        {
            Select_AnActive(masterImage);
            masterText.color = Cheng_Alway();
        }
        if (button == select_BGM)
        {
            Select_Active(bgmImage);
            bgmText.color = Cheng_Select();
        }
        else if (button != select_BGM)
        {
            Select_AnActive(bgmImage);
            bgmText.color = Cheng_Alway();
        }
        if (button == select_SE)
        {
            Select_Active(seImage);
            seText.color = Cheng_Select();
            
        }
        else if (button != select_SE)
        {
            Select_AnActive(seImage);
            seText.color = Cheng_Alway();
        }

        if (button == endgame_Button)
        {
            Scaling(endgameImage);
            if (Input.GetKeyDown(KeyCode.Joystick1Button1)) EventSystem.current.SetSelectedGameObject(endgame_Button);
        }
        else if (button != endgame_Button) endgameImage.transform.localScale = Reset_ImageScale(_endgameImage);
        if (button == toMenuButton)
        {
            Scaling(menuImage);
            if (Input.GetKeyDown(KeyCode.Joystick1Button1)) EventSystem.current.SetSelectedGameObject(toMenuButton);
        }
        else if (button != toMenuButton) menuImage.transform.localScale = Reset_ImageScale(_menuImage);
    }

    Color Cheng_Select()
    {
        return Color.white;
    }
    Color Cheng_Alway()
    {
        return Color.black;
    }

    void Select_Active(GameObject image)
    {
        image.SetActive(true);
    }

    void Select_AnActive(GameObject image)
    {
        image.SetActive(false);
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
