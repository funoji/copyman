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
    public bool fadeout; //フェイドアウトしているかの判定
    [SerializeField] [Tooltip("メインの表示刺せるパネル")] GameObject mainPanel;   //タイトルパネル
    //[SerializeField] [Tooltip("ステージセレクト部分の画像")] Image selectImage; //メニュー画面にあるステージ選択画像
    [SerializeField] [Tooltip("フェイドアウト用のパネル")] GameObject fadeoutPanel; //フェイドアウト用の下地パネル
    [SerializeField] [Tooltip("フェイドアウトするスピード")] float fadespeed;　//フェイドアウトするスピード
    [Space(15)]

    CanvasGroup main_panel;
    //public Transtion transScene;

    // Start is called before the first frame update
    void Start()
    {
        main_panel = mainPanel.GetComponent<CanvasGroup>();　//Title_Panelに含まれてるUIをすべてまとめている
        fadeout = false;
        fadeoutPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeout) Fadeout(); 
    }

    //フェイドアウトの動作
    void Fadeout()
    {
        main_panel.alpha -= 0.01f*fadespeed;　//canvasGounpの透明度を下げる
        if (main_panel.alpha <= 0.00f)
        {
            //Debug.Log("透明度が0になった。");
        }
    }

    public void Trans_Menu()
    {
        //Debug.Log("スタートボタンが押された。");
        //transScene.Trans_Menu();
        fadeout = true;
        fadeoutPanel.SetActive(true);
    }

    public void Trans_StageSelect()
    {
        //Debug.Log("ステージ選択ボタンが押された。");
       // transScene.Trans_StageSelect();
        fadeout = true;
        fadeoutPanel.SetActive(true);
    }

    public void Trans_Option()
    {
        //Debug.Log("オプションボタンが押された。");
        //transScene.Trans_Option();
        fadeout = true;
        fadeoutPanel.SetActive(true);
    }

    public void Trans_Catalog()
    {
        //Debug.Log("アイテム図鑑ボタンが押された。");
        //transScene.Trans_Catalog();
        fadeout = true;
        fadeoutPanel.SetActive(true);
    }

    public void Trasn_Exit()
    {
        //Debug.Log("戻るボタンが押された。");
        //transScene.Trasn_Exit();
        fadeout = true;
        fadeoutPanel.SetActive(true);
    }
}
