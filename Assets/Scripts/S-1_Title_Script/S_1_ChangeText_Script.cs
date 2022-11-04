using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using TMPro;

public class S_1_ChangeText_Script : MonoBehaviour
{
    [Header("�X�N���v�g���Q��")]
    public S_1_Fadeout_Script fadebool; 

    [Space(5)]
    [Header("Button")]
    [SerializeField] [Tooltip("�u�Q�[���X�^�[�g�v�̃{�^��")] private GameObject startButton;
    [SerializeField] [Tooltip("�u�Q�[���I���v�̃{�^��")] private GameObject endgameButton;
    private GameObject button;

    [Space(5)]
    [Header("�e�L�X�g�̓_��")]
    [SerializeField] [Tooltip("�u�Q�[���X�^�[�g�v�̃e�L�X�g")] private TextMeshProUGUI startText;
    [SerializeField] [Tooltip("�u�Q�[���I���v�̃e�L�X�g")] private TextMeshProUGUI endgameText;
    [Space(2)]
    [SerializeField] [Tooltip("���[�v�J�n���̐F")] private Color32 startColor= new Color32(255, 255, 255, 255);
    [SerializeField] [Tooltip("���[�v�I�����̐F")] private Color32 endColor= new Color32(255, 255, 255, 40);
    [Space(2)]
    [SerializeField] [Tooltip("�����x")] private float thinColor;

    [Space(5)]
    [Header("�_�ł̎���")]
    [SerializeField] [Tooltip("�_�ł���������̃X�s�[�h")] public float speed = 1.0f; 
    [SerializeField] [Tooltip("�_�ł�������̎���")] public float length;

    [Space(5)]
    [Header("�R���g���[���[�p�̕ϐ�")]
    [SerializeField] [Tooltip("�R���g���[���[��PlayerInput")] private InputAction.CallbackContext context;

    // Start is called before the first frame update
    void Start()
    {
        //�����̑I����Ԃ��X�^�[�g�{�^���ɐݒ� : Set initial selection status to Start button
        EventSystem.current.SetSelectedGameObject(startButton);

        //�����̓_�ł��X�^�[�g�̃e�L�X�g�ɐݒ� : Set initial blinking to start text
        startText.color = Change_Color(startColor, endColor);

        //�e�L�X�g�̃R���|�[�l���g�擾 : Text component acquisition
        if (startText == null|| endgameText == null)
        {
            startText = GetComponent<TextMeshProUGUI>();
            endgameText = GetComponent<TextMeshProUGUI>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //�t�F�[�h�A�E�g������Ƃ��ɕ������ڂ�Ȃ��悤�ɂ��鏈�� : Process to prevent text from shifting when fading out
        if (!fadebool.fadeout)
        {
            Info();
        }
    }

    //�������܂Ƃ߂��֐� : A function that summarizes the process
    void Info()
    {
        //���ݑI�𒆂̃{�^����ۑ� : Save the currently selected button
        button = EventSystem.current.currentSelectedGameObject;
        //Debug.Log(button.name);

        //�L�[�{�[�h�p�@�{�^���̑I����Ԃ̐ݒ� : For keyboard Set button selection status
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            EventSystem.current.SetSelectedGameObject(endgameButton);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            EventSystem.current.SetSelectedGameObject(startButton);
        }

        //�R���g���[���[�p(�A�i���O�X�e�B�b�N)�@�{�^���̑I����Ԃ̐ݒ� : Setting the selection state of the (analog stick) buttons for the controller
        var inputAnalog = context.ReadValue<Vector2>();
        if (inputAnalog == new Vector2(0, -1)) //�� : down
        {
            EventSystem.current.SetSelectedGameObject(endgameButton);
        }
        if (inputAnalog == new Vector2(0, 1)) //�� : up
        {
            EventSystem.current.SetSelectedGameObject(startButton);
        }

        //�R���g���[���[�p�i�\���L�[�j�@�{�^���̑I����Ԃ̐ݒ� : For controllers (cross key) Set button selection status
        var inputCross = context.ReadValue<Vector2>();
        if (inputCross == new Vector2(0, -1)) //�� : down
        {
            EventSystem.current.SetSelectedGameObject(endgameButton);
        }
        if (inputCross == new Vector2(0, 1)) //�� : up
        {
            EventSystem.current.SetSelectedGameObject(startButton);
        }

        //�I�����ꂽ��Ԃ̃e�L�X�g��_�ł����� : Blinking text in selected state
        if (button == endgameButton)
        {
            endgameText.color = Change_Color(startColor, endColor);
            startText.color = Thin_Color();
        }
        if (button == startButton)
        {
            startText.color = Change_Color(startColor, endColor);
            endgameText.color = Thin_Color();
        }
    }

    //�F��ω������� : Change color
    Color Change_Color(Color startcolor, Color endcolor)
    {
        return Color.Lerp(startcolor, endcolor, Mathf.PingPong(Time.time / length, speed)); 
    }

    //�F�𔖂����� : lighten a color
    Color Thin_Color()
    {
        return new Color(0, 0, 0, thinColor);
    }
}
