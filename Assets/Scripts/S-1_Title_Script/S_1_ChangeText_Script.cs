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
    [SerializeField] [Tooltip("「ゲームスタート」のテキスト")] private TextMeshProUGUI startText;
    [SerializeField] [Tooltip("「ゲーム終了」のテキスト")] private TextMeshProUGUI endgameText;
    [Space(2)]
    [SerializeField] [Tooltip("ループ開始時の色")] private Color32 startColor= new Color32(255, 255, 255, 255);
    [SerializeField] [Tooltip("ループ終了時の色")] private Color32 endColor= new Color32(255, 255, 255, 40);
    [Space(2)]
    [SerializeField] [Tooltip("透明度")] private float thinColor;

    [Space(5)]
    [Header("点滅の周期")]
    [SerializeField] [Tooltip("点滅をする周期のスピード")] public float speed = 1.0f; 
    [SerializeField] [Tooltip("点滅する周期の時間")] public float length;

    [Space(5)]
    [Header("コントローラー用の変数")]
    [SerializeField] [Tooltip("コントローラーのPlayerInput")] private InputAction.CallbackContext context;

    // Start is called before the first frame update
    void Start()
    {
        //初期の選択状態をスタートボタンに設定 : Set initial selection status to Start button
        EventSystem.current.SetSelectedGameObject(startButton);

        //初期の点滅をスタートのテキストに設定 : Set initial blinking to start text
        startText.color = Change_Color(startColor, endColor);

        //テキストのコンポーネント取得 : Text component acquisition
        if (startText == null|| endgameText == null)
        {
            startText = GetComponent<TextMeshProUGUI>();
            endgameText = GetComponent<TextMeshProUGUI>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //フェードアウトさせるときに文字が移らないようにする処理 : Process to prevent text from shifting when fading out
        if (!fadebool.fadeout)
        {
            Info();
        }
    }

    //処理をまとめた関数 : A function that summarizes the process
    void Info()
    {
        //現在選択中のボタンを保存 : Save the currently selected button
        button = EventSystem.current.currentSelectedGameObject;
        //Debug.Log(button.name);

        //キーボード用　ボタンの選択状態の設定 : For keyboard Set button selection status
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            EventSystem.current.SetSelectedGameObject(endgameButton);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            EventSystem.current.SetSelectedGameObject(startButton);
        }

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

        //コントローラー用（十字キー）　ボタンの選択状態の設定 : For controllers (cross key) Set button selection status
        var inputCross = context.ReadValue<Vector2>();
        if (inputCross == new Vector2(0, -1)) //下 : down
        {
            EventSystem.current.SetSelectedGameObject(endgameButton);
        }
        if (inputCross == new Vector2(0, 1)) //上 : up
        {
            EventSystem.current.SetSelectedGameObject(startButton);
        }

        //選択された状態のテキストを点滅させる : Blinking text in selected state
        if (button == endgameButton)
        {
            endgameText.color = Change_Color(startColor, endColor);
            startText.color = Thin_Color();
        }
        if (button == startButton)
        {
            startText.color = Change_Color(startColor, endColor);
            endgameText.color = Thin_Color();
        }
    }

    //色を変化させる : Change color
    Color Change_Color(Color startcolor, Color endcolor)
    {
        return Color.Lerp(startcolor, endcolor, Mathf.PingPong(Time.time / length, speed)); 
    }

    //色を薄くする : lighten a color
    Color Thin_Color()
    {
        return new Color(0, 0, 0, thinColor);
    }
}
