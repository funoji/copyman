using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


//https://bluebirdofoz.hatenablog.com/entry/2017/09/11/231524

//�p�l�����t�F�C�h�A�E�g����d�l
public class TransitionScene : MonoBehaviour
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

    public void Trans_Menu()
    {
        //Debug.Log("�X�^�[�g�{�^���������ꂽ�B");
        SceneManager.LoadScene("S-02_Menu_Scene");
        fadeout = true;
        fadeoutPanel.SetActive(true);
    }

    public void Trans_StageSelect()
    {
        //Debug.Log("�X�e�[�W�I���{�^���������ꂽ�B");
        SceneManager.LoadScene("Stage_01");
        fadeout = true;
        fadeoutPanel.SetActive(true);
    }

    public void Trans_Option()
    {
        //Debug.Log("�I�v�V�����{�^���������ꂽ�B");
        SceneManager.LoadScene("S-03_Option_Scene");
        fadeout = true;
        fadeoutPanel.SetActive(true);
    }

    public void Trans_Catalog()
    {
        //Debug.Log("�A�C�e���}�Ӄ{�^���������ꂽ�B");
        SceneManager.LoadScene("Stage_01");
        fadeout = true;
        fadeoutPanel.SetActive(true);
    }

    public void Trasn_Exit()
    {
        //Debug.Log("�߂�{�^���������ꂽ�B");
        SceneManager.LoadScene("S-01_Title_Scene");
        fadeout = true;
        fadeoutPanel.SetActive(true);
    }
}
