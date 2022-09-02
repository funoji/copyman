using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

//パネルがフェイドアウトする仕様
public class TitleController : MonoBehaviour
{
    public bool fadeout; //フェイドアウトしているかの判定

    [SerializeField] GameObject titlePanel;   //タイトルパネル
    [SerializeField] GameObject fadeoutPanel; //フェイドアウト用の下地パネル
    [SerializeField] float fadespeed;　//フェイドアウトするスピード

    CanvasGroup title_panel;

    // Start is called before the first frame update
    void Start()
    {
        title_panel=titlePanel.GetComponent<CanvasGroup>();　//Title_Panelに含まれてるUIをすべてまとめている
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
        Debug.Log("ボタンが押された。");
        fadeout = true;
        fadeoutPanel.SetActive(true);
    }

    //フェイドアウトの動作
    void Fadeout()
    {
        title_panel.alpha -= 0.01f*fadespeed;　//canvasGounpの透明度を下げる
        if (title_panel.alpha <= 0.00f)
        {
            Debug.Log("透明度が0になった。");
        }
    }
}
