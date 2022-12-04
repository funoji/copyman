using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class S_3_Select : MonoBehaviour
{
    [SerializeField] [Tooltip("「Master」スレンダー")] private GameObject select_Master;
    [SerializeField] [Tooltip("「Master」のイメージ")] private GameObject masterImage;
    [SerializeField] TextMeshProUGUI masterText;
    //[SerializeField] [Tooltip("「Master」の保存用変数")] private Vector3 _masterImage;

    [SerializeField] [Tooltip("「BGM」スレンダー")] private GameObject select_BGM;
    [SerializeField] [Tooltip("「BGM」のイメージ")] private GameObject bgmImage;
    [SerializeField] TextMeshProUGUI bgmText;
    //[SerializeField] [Tooltip("「BGM」の保存用変数")] private Vector3 _bgmImage;

    [SerializeField] [Tooltip("「SE」スレンダー")] private GameObject select_SE;
    [SerializeField] [Tooltip("「SE」のイメージ")] private GameObject seImage;
    [SerializeField] TextMeshProUGUI seText;
    //[SerializeField] [Tooltip("「SE」の保存用変数")] private Vector3 _seImage;

    [SerializeField] [Tooltip("「ゲーム終了」ボタン")] private GameObject endgame_Button;
    [SerializeField] [Tooltip("「ゲーム終了」のイメージ")] private GameObject endgameImage;
    [SerializeField] [Tooltip("「ゲーム終了」の保存用変数")] private Vector3 _endgameImage;

    [SerializeField] [Tooltip("「戻る」ボタン")] private GameObject toMenuButton;
    [SerializeField] [Tooltip("「戻る」のイメージ")] private GameObject menuImage;
    [SerializeField] [Tooltip("「戻る」の保存用変数")] private Vector3 _menuImage;

    private GameObject button;

    [Space(10)]
    [Header("拡大縮小の演出用")]
    [SerializeField] [Tooltip("変化する速さ")] private float scallSpeed;
    [SerializeField] [Tooltip("拡大縮小の時間")] private float maxTime;
    private float time;
    private bool enlarge = true;

    private void Start()
    {
        //初期の選択状態をスタートボタンに設定 : Set initial selection status to Start button
        EventSystem.current.SetSelectedGameObject(endgame_Button);

        _endgameImage= endgameImage.transform.localScale;
        _menuImage = menuImage.transform.localScale;
    }

    private void Update()
    {
        button = EventSystem.current.currentSelectedGameObject;
        Debug.Log(button);
        //if (button != null) Debug.Log("NUll");

        if (button == select_Master)
        {
            Select_Active(masterImage);
            masterText.color = Cheng_Select();
        }
        else if (button != select_Master)
        {
            Select_AnActive(masterImage);
            masterText.color = Cheng_Alway();
        }
        if (button == select_BGM)
        {
            Select_Active(bgmImage);
            bgmText.color = Cheng_Select();
        }
        else if (button != select_BGM)
        {
            Select_AnActive(bgmImage);
            bgmText.color = Cheng_Alway();
        }
        if (button == select_SE)
        {
            Select_Active(seImage);
            seText.color = Cheng_Select();
            
        }
        else if (button != select_SE)
        {
            Select_AnActive(seImage);
            seText.color = Cheng_Alway();
        }

        if (button == endgame_Button)
        {
            Scaling(endgameImage);
            if (Input.GetKeyDown(KeyCode.Joystick1Button1)) EventSystem.current.SetSelectedGameObject(endgame_Button);
        }
        else if (button != endgame_Button) endgameImage.transform.localScale = Reset_ImageScale(_endgameImage);
        if (button == toMenuButton)
        {
            Scaling(menuImage);
            if (Input.GetKeyDown(KeyCode.Joystick1Button1)) EventSystem.current.SetSelectedGameObject(toMenuButton);
        }
        else if (button != toMenuButton) menuImage.transform.localScale = Reset_ImageScale(_menuImage);
    }

    Color Cheng_Select()
    {
        return Color.white;
    }
    Color Cheng_Alway()
    {
        return Color.black;
    }

    void Select_Active(GameObject image)
    {
        image.SetActive(true);
    }

    void Select_AnActive(GameObject image)
    {
        image.SetActive(false);
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
