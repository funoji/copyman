using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class S_2_Select_Sctipt : MonoBehaviour
{
    [Header("スクリプトを参照")]
    public Transtion transtion;

    [Space(8)]
    [Header("ゲームスタート / ステージ選択")]
    [SerializeField] [Tooltip("「ゲームスタート / ステージ選択」のボタン")] private GameObject mainButton;
    [SerializeField] [Tooltip("「ゲームスタート / ステージ選択」のイメージ")] private GameObject mainImage;
     private Vector3 _mainScale;
    [Space(5)]
    [Header("アイテム図鑑")]
    [SerializeField] [Tooltip("「アイテム図鑑」のボタン")] private GameObject itemButton;
    [SerializeField] [Tooltip("「アイテム図鑑」のイメージ")] private GameObject itemImage;
    private Vector3 _itemScale;
    [Space(5)]
    [Header("オプション")]
    [SerializeField] [Tooltip("「オプション」のボタン")] private GameObject optionButton;
    [SerializeField] [Tooltip("「オプション」のイメージ")] private GameObject optionImage;
    private Vector3 _optionScale;
    [Space(5)]
    [Header("戻る")]
    [SerializeField] [Tooltip("「戻る」のボタン")] private GameObject ExitButton;
    [SerializeField] [Tooltip("「戻る」のイメージ")] private GameObject ExitImage;
    private Vector3 _ExitScale;
    private GameObject button;

    [Space(10)]
    [Header("拡大縮小の演出用")]
    [SerializeField] [Tooltip("変化する速さ")] private float scallSpeed;
    [SerializeField] [Tooltip("拡大縮小の時間")] private float maxTime;
    private float time;
    private bool enlarge = true;

    // Start is called before the first frame update
    void Start()
    {
        //初期の選択状態をスタートボタンに設定 : Set initial selection status to Start button
        EventSystem.current.SetSelectedGameObject(mainButton);

        //初期の大きさを保存 : Save initial size
        _mainScale = mainImage.transform.localScale;
        _itemScale = itemImage.transform.localScale;
        _optionScale = optionImage.transform.localScale;
        _ExitScale = ExitImage.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        //現在選択中のボタンを保存 : Save the currently selected button
        button = EventSystem.current.currentSelectedGameObject;
        //Debug.Log(button.name);

        //コントローラー用　ボタン選択状態の設定 : For Controller Set button selection status
        if (Input.GetKeyDown(KeyCode.Joystick1Button1)) { EventSystem.current.SetSelectedGameObject(ExitButton); }

        //選択されているボタンを拡大縮小させる。終わったら初期の大きさに戻す : Scale the selected button. When done, return to initial size.
        //Option
        if (button == optionButton) { Scaling(optionImage); }
        else if (button != optionButton) { optionImage.transform.localScale = Reset_ImageScale(_optionScale); }
        //Item
        if (button == itemButton) { Scaling(itemImage); }
        else if (button != itemButton) { itemImage.transform.localScale = Reset_ImageScale(_itemScale); }
        //Main
        if (button == mainButton) { Scaling(mainImage); }
        else if (button != mainButton) { mainImage.transform.localScale = Reset_ImageScale(_mainScale); }
        //Exit
        if (button == ExitButton) { Scaling(ExitImage); }
        else if (button != ExitButton) { ExitImage.transform.localScale = Reset_ImageScale(_ExitScale); }
    }

    //拡大縮小の演出の処理 : Processing of scaling direction
    void Scaling(GameObject image)
    {
        scallSpeed = Time.deltaTime * 0.1f;

        if (time < 0) { enlarge = true; }
        if (time > maxTime) { enlarge = false; }

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
