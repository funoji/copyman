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
    public static bool fadeInstance = false; //�t�F�C�h�A�E�g���Ă��邩�̔���
    public bool fadeIn = false;
    public bool fadeOut = false;
    public float alpha = 0.0f;

    //[SerializeField] [Tooltip("���C���̕\���h����p�l��")] GameObject mainPanel;  
    //[SerializeField] [Tooltip("�t�F�C�h�A�E�g�p�̃p�l��")] GameObject fadeoutPanel; 
    [SerializeField] [Tooltip("�t�F�C�h�A�E�g����X�s�[�h")] float fadespeed = 0.2f;�@

    //CanvasGroup fadepanel;
    //public Transtion transScene;

    //public Transtion transScene;

    // Start is called before the first frame update
    void Start()
    {
        //fadepanel = fadeoutPanel.GetComponent<CanvasGroup>();�@//Title_Panel�Ɋ܂܂�Ă�UI�����ׂĂ܂Ƃ߂Ă���
        //fadeout = false;
        //fadeoutPanel.SetActive(false);

        if (!fadeInstance)
        {
            DontDestroyOnLoad(this);
            fadeInstance = true;
        }
        else
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (fadeout) Fadeout(); 

        if (fadeIn)
        {
            alpha -= 0.01f * fadespeed;
            if (alpha < 0.0f)
            {
                fadeIn = false;
                alpha = 0.0f;
            }
            this.GetComponentInChildren<Image>().color = new Color(0.0f, 0.0f, 0.0f, alpha);
        }
        else if (fadeOut)
        {
            alpha+= 0.01f * fadespeed;
            if (alpha >= 1.0f)
            {
                fadeOut = false;
                alpha = 1.0f;
            }
            this.GetComponentInChildren<Image>().color = new Color(0.0f, 0.0f, 0.0f, alpha);
        }
    }
    public void FadeIn()
    {
        fadeIn = true;
        fadeOut = false;
    }

    public void FadeOut()
    {
        fadeOut = true;
        fadeIn = false;
    }

    //�t�F�C�h�A�E�g�̓���
    //public void Fadeout()
    //{
    //    main_panel.alpha -= 0.01f*fadespeed;�@//canvasGounp�̓����x��������
    //    if (main_panel.alpha <= 0.01f)
    //    {
            
    //    }
    //}

    //public void Trans_Menu()
    //{
    //    //Debug.Log("�X�^�[�g�{�^���������ꂽ�B");
    //    transScene.Trans_ToMenu();
    //    fadeout = true;
    //    fadeoutPanel.SetActive(true);
    //}

    //public void Trans_StageSelect()
    //{
    //    //Debug.Log("�X�e�[�W�I���{�^���������ꂽ�B");
    //    transScene.Trans_ToStage1();
    //    fadeout = true;
    //    fadeoutPanel.SetActive(true);
    //}

    //public void Trans_Option()
    //{
    //    //Debug.Log("�I�v�V�����{�^���������ꂽ�B");
    //    transScene.Trans_ToOption();
    //    fadeout = true;
    //    fadeoutPanel.SetActive(true);
    //}

    //public void Trans_Catalog()
    //{
    //    //Debug.Log("�A�C�e���}�Ӄ{�^���������ꂽ�B");
    //    transScene.Trans_ToCatalog();
    //    fadeout = true;
    //    fadeoutPanel.SetActive(true);
    //}

    //public void Trasn_Exit()
    //{
    //    //Debug.Log("�߂�{�^���������ꂽ�B");
    //    transScene.Trasn_ToRetuenTitle();
    //    fadeout = true;
    //    fadeoutPanel.SetActive(true);
    //}
}
