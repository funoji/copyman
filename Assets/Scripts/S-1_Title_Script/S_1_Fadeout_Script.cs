using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

//https://bluebirdofoz.hatenablog.com/entry/2017/09/11/231524

//パネルがフェイドアウトする仕様
public class S_1_Fadeout_Script : MonoBehaviour
{
    [Header("フェイドアウト機能")]
    public static bool fadeInstance = false; //フェイドアウトしているかの判定
    public bool fadeIn = false;
    public bool fadeOut = false;
    public float alpha = 0.0f;

    //[SerializeField] [Tooltip("メインの表示刺せるパネル")] GameObject mainPanel;  
    //[SerializeField] [Tooltip("フェイドアウト用のパネル")] GameObject fadeoutPanel; 
    [SerializeField] [Tooltip("フェイドアウトするスピード")] float fadespeed = 0.2f;　

    //CanvasGroup fadepanel;
    //public Transtion transScene;

    //public Transtion transScene;

    // Start is called before the first frame update
    void Start()
    {
        //fadepanel = fadeoutPanel.GetComponent<CanvasGroup>();　//Title_Panelに含まれてるUIをすべてまとめている
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

    //フェイドアウトの動作
    //public void Fadeout()
    //{
    //    main_panel.alpha -= 0.01f*fadespeed;　//canvasGounpの透明度を下げる
    //    if (main_panel.alpha <= 0.01f)
    //    {
            
    //    }
    //}

    //public void Trans_Menu()
    //{
    //    //Debug.Log("スタートボタンが押された。");
    //    transScene.Trans_ToMenu();
    //    fadeout = true;
    //    fadeoutPanel.SetActive(true);
    //}

    //public void Trans_StageSelect()
    //{
    //    //Debug.Log("ステージ選択ボタンが押された。");
    //    transScene.Trans_ToStage1();
    //    fadeout = true;
    //    fadeoutPanel.SetActive(true);
    //}

    //public void Trans_Option()
    //{
    //    //Debug.Log("オプションボタンが押された。");
    //    transScene.Trans_ToOption();
    //    fadeout = true;
    //    fadeoutPanel.SetActive(true);
    //}

    //public void Trans_Catalog()
    //{
    //    //Debug.Log("アイテム図鑑ボタンが押された。");
    //    transScene.Trans_ToCatalog();
    //    fadeout = true;
    //    fadeoutPanel.SetActive(true);
    //}

    //public void Trasn_Exit()
    //{
    //    //Debug.Log("戻るボタンが押された。");
    //    transScene.Trasn_ToRetuenTitle();
    //    fadeout = true;
    //    fadeoutPanel.SetActive(true);
    //}
}
