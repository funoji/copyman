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

    public void Menu()
    {
        //Debug.Log("スタートボタンが押された。");
        fadeout = true;
        fadeoutPanel.SetActive(true);
        Transtion.instatns.Trans_Menu();
    }

    public void StageSelect()
    {
        //Debug.Log("ステージ選択ボタンが押された。");
        Transtion.instatns.Trans_StageSelect();
        fadeout = true;
        fadeoutPanel.SetActive(true);
    }

    public void Option()
    {
        //Debug.Log("オプションボタンが押された。");
        Transtion.instatns.Trans_Option();
        fadeout = true;
        fadeoutPanel.SetActive(true);
    }

    public void Catalog()
    {
        //Debug.Log("アイテム図鑑ボタンが押された。");
        Transtion.instatns.Trans_Catalog();
        fadeout = true;
        fadeoutPanel.SetActive(true);
    }

    public void Exit()
    {
        //Debug.Log("戻るボタンが押された。");
        Transtion.instatns.Trasn_Exit();
        fadeout = true;
        fadeoutPanel.SetActive(true);
    }
}
