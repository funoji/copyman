using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using TMPro;

public class S_1_ChangeText_Script : MonoBehaviour
{
    [Header("スクリプトを参照")]
    public S_1_Fadeout_Script fadebool;

    [Space(5)]
    [Header("Button")]
    [SerializeField] [Tooltip("「ゲームスタート」のボタン")] private GameObject startButton;
    [SerializeField] [Tooltip("「ゲーム終了」のボタン")] private GameObject endgameButton;
    private GameObject button;

    [Space(5)]
    [Header("テキストの点滅")]
    [SerializeField] [Tooltip("「ゲームスタート」のテキスト")] private GameObject startText;
    [SerializeField] [Tooltip("「ゲーム終了」のテキスト")] private GameObject endgameText;
    [SerializeField] [Tooltip("「ゲームスタート」の保存用変数")] private Vector3 _startText;
    [SerializeField] [Tooltip("「ゲーム終了」の保存用変数")] private Vector3 _endgameText;

    [Header("拡大縮小の演出用")]
    [SerializeField] [Tooltip("変化する速さ")] private float scallSpeed;
    [SerializeField] [Tooltip("拡大縮小の時間")] private float maxTime;
    private float time;
    private bool enlarge = true;

    [Space(5)]
    [Header("コントローラー用の変数")]
    [SerializeField] [Tooltip("コントローラーのPlayerInput")] private InputAction.CallbackContext context;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.PlayBGM(BGMSoundData.BGM.Title);
        //初期の選択状態をスタートボタンに設定 : Set initial selection status to Start button
        EventSystem.current.SetSelectedGameObject(startButton);

        _startText = startText.transform.localScale;
        _endgameText = endgameText.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        Info();
    }

    //処理をまとめた関数 : A function that summarizes the process
    void Info()
    {
        //現在選択中のボタンを保存 : Save the currently selected button
        button = EventSystem.current.currentSelectedGameObject;

        //キーボード用　ボタンの選択状態の設定 : For keyboard Set button selection status
        //if (Input.GetKeyDown(KeyCode.DownArrow))
        //{
        //    EventSystem.current.SetSelectedGameObject(endgameButton);
        //}
        //if (Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    EventSystem.current.SetSelectedGameObject(startButton);
        //}

        //コントローラー用(アナログスティック)　ボタンの選択状態の設定 : Setting the selection state of the (analog stick) buttons for the controller
        var inputAnalog = context.ReadValue<Vector2>();
        if (inputAnalog == new Vector2(0, -1)) //下 : down
        {
            EventSystem.current.SetSelectedGameObject(endgameButton);
        }
        if (inputAnalog == new Vector2(0, 1)) //上 : up
        {
            EventSystem.current.SetSelectedGameObject(startButton);
        }

        //選択された状態のテキストを点滅させる : Blinking text in selected state
        if (button == endgameButton)
        {
            Scaling(endgameText);
            startText.transform.localScale = Reset_ImageScale(_startText);
        }
        if (button == startButton)
        {
            Scaling(startText);
            endgameText.transform.localScale = Reset_ImageScale(_endgameText);
        }
    }

    //拡大縮小の演出の処理 : Processing of scaling direction
    void Scaling(GameObject image)
    {
        scallSpeed = Time.deltaTime * 0.1f;

        if (time < 0)
            enlarge = true;
        if (time > maxTime)
            enlarge = false;

        if (enlarge)
        {
            time += Time.deltaTime;
            image.transform.localScale += new Vector3(scallSpeed, scallSpeed, scallSpeed);
        }
        else
        {
            time -= Time.deltaTime;
            image.transform.localScale -= new Vector3(scallSpeed, scallSpeed, scallSpeed);
        }
    }

    //大きさの初期化 : Size initialization
    Vector3 Reset_ImageScale(Vector3 afterObj)
    {
        return afterObj;
    }

}
