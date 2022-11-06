using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class S_2_Select_Sctipt : MonoBehaviour
{
    [Header("スクリプトを参照")]
    public S_1_Fadeout_Script fadebool;
    private Transtion transtion;

    [Space(5)]
    [Header("Button")]
    [SerializeField] [Tooltip("「ゲームスタート / ステージ選択」のボタン")] private GameObject mainButton;
    [SerializeField] [Tooltip("「アイテム図鑑」のボタン")] private GameObject itemButton;
    [SerializeField] [Tooltip("「オプション」のボタン")] private GameObject optionButton;
    private GameObject button;

    [SerializeField] [Tooltip("フェイドアウト用のパネル")] GameObject fadeoutPanel;

    // Start is called before the first frame update
    void Start()
    {
        //初期の選択状態をスタートボタンに設定 : Set initial selection status to Start button
        EventSystem.current.SetSelectedGameObject(mainButton);

        fadeoutPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //現在選択中のボタンを保存 : Save the currently selected button
        button = EventSystem.current.currentSelectedGameObject;
        Debug.Log(button.name);

        //キーボード用　ボタンの選択状態の設定 : For keyboard Set button selection status
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
            Debug.Log("押された。");
        }

        //if (Input.GetKeyDown(KeyCode.Joystick1Button1))
        //{

        //}
    }
}
