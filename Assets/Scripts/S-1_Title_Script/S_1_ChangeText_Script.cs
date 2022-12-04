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
    [SerializeField] [Tooltip("�u�Q�[���X�^�[�g�v�̃e�L�X�g")] private GameObject startText;
    [SerializeField] [Tooltip("�u�Q�[���I���v�̃e�L�X�g")] private GameObject endgameText;
    [SerializeField] [Tooltip("�u�Q�[���X�^�[�g�v�̕ۑ��p�ϐ�")] private Vector3 _startText;
    [SerializeField] [Tooltip("�u�Q�[���I���v�̕ۑ��p�ϐ�")] private Vector3 _endgameText;

    [Header("�g��k���̉��o�p")]
    [SerializeField] [Tooltip("�ω����鑬��")] private float scallSpeed;
    [SerializeField] [Tooltip("�g��k���̎���")] private float maxTime;
    private float time;
    private bool enlarge = true;

    [Space(5)]
    [Header("�R���g���[���[�p�̕ϐ�")]
    [SerializeField] [Tooltip("�R���g���[���[��PlayerInput")] private InputAction.CallbackContext context;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.PlayBGM(BGMSoundData.BGM.Title);
        //�����̑I����Ԃ��X�^�[�g�{�^���ɐݒ� : Set initial selection status to Start button
        EventSystem.current.SetSelectedGameObject(startButton);

        _startText = startText.transform.localScale;
        _endgameText = endgameText.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        Info();
    }

    //�������܂Ƃ߂��֐� : A function that summarizes the process
    void Info()
    {
        //���ݑI�𒆂̃{�^����ۑ� : Save the currently selected button
        button = EventSystem.current.currentSelectedGameObject;

        //�L�[�{�[�h�p�@�{�^���̑I����Ԃ̐ݒ� : For keyboard Set button selection status
        //if (Input.GetKeyDown(KeyCode.DownArrow))
        //{
        //    EventSystem.current.SetSelectedGameObject(endgameButton);
        //}
        //if (Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    EventSystem.current.SetSelectedGameObject(startButton);
        //}

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

        //�I�����ꂽ��Ԃ̃e�L�X�g��_�ł����� : Blinking text in selected state
        if (button == endgameButton)
        {
            Scaling(endgameText);
            startText.transform.localScale = Reset_ImageScale(_startText);
        }
        if (button == startButton)
        {
            Scaling(startText);
            endgameText.transform.localScale = Reset_ImageScale(_endgameText);
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
