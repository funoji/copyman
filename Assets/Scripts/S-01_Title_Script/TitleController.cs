using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

//�p�l�����t�F�C�h�A�E�g����d�l
public class TitleController : MonoBehaviour
{
    public bool fadeout; //�t�F�C�h�A�E�g���Ă��邩�̔���

    [SerializeField] GameObject titlePanel;   //�^�C�g���p�l��
    [SerializeField] GameObject fadeoutPanel; //�t�F�C�h�A�E�g�p�̉��n�p�l��
    [SerializeField] float fadespeed;�@//�t�F�C�h�A�E�g����X�s�[�h

    CanvasGroup title_panel;

    // Start is called before the first frame update
    void Start()
    {
        title_panel=titlePanel.GetComponent<CanvasGroup>();�@//Title_Panel�Ɋ܂܂�Ă�UI�����ׂĂ܂Ƃ߂Ă���
        fadeout = false;
        fadeoutPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeout) Fadeout(); 
    }

    public void Onclick()
    {
        Debug.Log("�{�^���������ꂽ�B");
        fadeout = true;
        fadeoutPanel.SetActive(true);
    }

    //�t�F�C�h�A�E�g�̓���
    void Fadeout()
    {
        title_panel.alpha -= 0.01f*fadespeed;�@//canvasGounp�̓����x��������
        if (title_panel.alpha <= 0.00f)
        {
            Debug.Log("�����x��0�ɂȂ����B");
        }
    }
}
