using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

//https://bluebirdofoz.hatenablog.com/entry/2017/09/11/231524

//�p�l�����t�F�C�h�A�E�g����d�l
public class S_1_Fadeout_Script : MonoBehaviour
{
    [Header("�t�F�C�h�A�E�g�@�\")]
    public bool fadeout; //�t�F�C�h�A�E�g���Ă��邩�̔���
    [SerializeField] [Tooltip("���C���̕\���h����p�l��")] GameObject mainPanel;   //�^�C�g���p�l��
    //[SerializeField] [Tooltip("�X�e�[�W�Z���N�g�����̉摜")] Image selectImage; //���j���[��ʂɂ���X�e�[�W�I���摜
    [SerializeField] [Tooltip("�t�F�C�h�A�E�g�p�̃p�l��")] GameObject fadeoutPanel; //�t�F�C�h�A�E�g�p�̉��n�p�l��
    [SerializeField] [Tooltip("�t�F�C�h�A�E�g����X�s�[�h")] float fadespeed;�@//�t�F�C�h�A�E�g����X�s�[�h
    [Space(15)]

    CanvasGroup main_panel;

    // Start is called before the first frame update
    void Start()
    {
        main_panel = mainPanel.GetComponent<CanvasGroup>();�@//Title_Panel�Ɋ܂܂�Ă�UI�����ׂĂ܂Ƃ߂Ă���
        fadeout = false;
        fadeoutPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeout) Fadeout(); 
    }

    //�t�F�C�h�A�E�g�̓���
    void Fadeout()
    {
        main_panel.alpha -= 0.01f*fadespeed;�@//canvasGounp�̓����x��������
        if (main_panel.alpha <= 0.00f)
        {
            //Debug.Log("�����x��0�ɂȂ����B");
        }
    }

    public void Menu()
    {
        //Debug.Log("�X�^�[�g�{�^���������ꂽ�B");
        fadeout = true;
        fadeoutPanel.SetActive(true);
        Transtion.instatns.Trans_Menu();
    }

    public void StageSelect()
    {
        //Debug.Log("�X�e�[�W�I���{�^���������ꂽ�B");
        Transtion.instatns.Trans_StageSelect();
        fadeout = true;
        fadeoutPanel.SetActive(true);
    }

    public void Option()
    {
        //Debug.Log("�I�v�V�����{�^���������ꂽ�B");
        Transtion.instatns.Trans_Option();
        fadeout = true;
        fadeoutPanel.SetActive(true);
    }

    public void Catalog()
    {
        //Debug.Log("�A�C�e���}�Ӄ{�^���������ꂽ�B");
        Transtion.instatns.Trans_Catalog();
        fadeout = true;
        fadeoutPanel.SetActive(true);
    }

    public void Exit()
    {
        //Debug.Log("�߂�{�^���������ꂽ�B");
        Transtion.instatns.Trasn_Exit();
        fadeout = true;
        fadeoutPanel.SetActive(true);
    }
}
