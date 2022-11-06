using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class S_2_Select_Sctipt : MonoBehaviour
{
    [Header("�X�N���v�g���Q��")]
    public S_1_Fadeout_Script fadebool;
    private Transtion transtion;

    [Space(5)]
    [Header("Button")]
    [SerializeField] [Tooltip("�u�Q�[���X�^�[�g / �X�e�[�W�I���v�̃{�^��")] private GameObject mainButton;
    [SerializeField] [Tooltip("�u�A�C�e���}�Ӂv�̃{�^��")] private GameObject itemButton;
    [SerializeField] [Tooltip("�u�I�v�V�����v�̃{�^��")] private GameObject optionButton;
    private GameObject button;

    [SerializeField] [Tooltip("�t�F�C�h�A�E�g�p�̃p�l��")] GameObject fadeoutPanel;

    // Start is called before the first frame update
    void Start()
    {
        //�����̑I����Ԃ��X�^�[�g�{�^���ɐݒ� : Set initial selection status to Start button
        EventSystem.current.SetSelectedGameObject(mainButton);

        fadeoutPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //���ݑI�𒆂̃{�^����ۑ� : Save the currently selected button
        button = EventSystem.current.currentSelectedGameObject;
        Debug.Log(button.name);

        //�L�[�{�[�h�p�@�{�^���̑I����Ԃ̐ݒ� : For keyboard Set button selection status
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(button== optionButton)
                EventSystem.current.SetSelectedGameObject(mainButton);
            if(button== itemButton)
                EventSystem.current.SetSelectedGameObject(mainButton);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (button == mainButton)
                EventSystem.current.SetSelectedGameObject(itemButton);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (button == optionButton)
                EventSystem.current.SetSelectedGameObject(itemButton);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (button == itemButton)
                EventSystem.current.SetSelectedGameObject(optionButton);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            //fadeoutPanel.SetActive(true);
            //fadebool.Fadeout();
            Debug.Log("�����ꂽ�B");
        }

        //if (Input.GetKeyDown(KeyCode.Joystick1Button1))
        //{

        //}
    }
}
