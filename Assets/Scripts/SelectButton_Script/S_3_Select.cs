using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class S_3_Select : MonoBehaviour
{
    [Header("Button1")]
    [SerializeField] [Tooltip("「Button1」のボタン")] private GameObject mainButton;
    [SerializeField] [Tooltip("「Button1」のイメージ")] private GameObject mainImage;
    [SerializeField] [Tooltip("「Button1」の選択中イメージ")] private GameObject mainImage_back;
    private Vector3 _mainScale;
    [Space(5)]
    [Header("Button2")]
    [SerializeField] [Tooltip("「Button2」のボタン")] private GameObject sub1Button;
    [SerializeField] [Tooltip("「Button2」のイメージ")] private GameObject sub1Image;
    [SerializeField] [Tooltip("「Button2」の選択中イメージ")] private GameObject sub1Image_back;
    private Vector3 _sub1Scale;
    [Space(5)]
    [Header("Button3")]
    [SerializeField] [Tooltip("「Button3」のボタン")] private GameObject sub2Button;
    [SerializeField] [Tooltip("「Button3」のイメージ")] private GameObject sub2Image;
    [SerializeField] [Tooltip("「Button3」の選択中イメージ")] private GameObject sub2Image_back;
    private Vector3 _sub2Scale;
    [Space(5)]
    [Header("Button4")]
    [SerializeField] [Tooltip("「Button4」のボタン")] private GameObject sub3Button;
    [SerializeField] [Tooltip("「Button4」のイメージ")] private GameObject sub3Image;
    [SerializeField] [Tooltip("「Button4」の選択中イメージ")] private GameObject sub3Image_back;
    private Vector3 _sub3Scale;
    [Space(5)]
    [Header("戻る")]
    [SerializeField] [Tooltip("「戻る」のボタン")] private GameObject ExitButton;
    [SerializeField] [Tooltip("「戻る」のイメージ")] private GameObject ExitImage;
    [SerializeField] [Tooltip("「戻る」の選択中イメージ")] private GameObject ExitImage_back;
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
        _sub1Scale = sub1Image.transform.localScale;
        _sub2Scale = sub2Image.transform.localScale;
        _sub3Scale = sub3Image.transform.localScale;
        _ExitScale = ExitImage.transform.localScale;

        //初期の表示を設定
        mainImage_back.SetActive(false);
        sub1Image_back.SetActive(false);
        sub2Image_back.SetActive(false);
        sub3Image_back.SetActive(false);
        ExitImage_back.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //現在選択中のボタンを保存 : Save the currently selected button
        button = EventSystem.current.currentSelectedGameObject;
        Debug.Log(button.name);

        //コントローラー用　ボタン選択状態の設定 : For Controller Set button selection status
        if (Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            EventSystem.current.SetSelectedGameObject(ExitButton);
        }

        //選択されているボタンを拡大縮小させる。終わったら初期の大きさに戻す : Scale the selected button. When done, return to initial size.
        if (button == sub1Button)
        {
            Scaling(sub1Image);
            sub1Image_back.SetActive(true);
        }
        else if (button != sub1Button)
        {
            sub1Image.transform.localScale = Reset_ImageScale(_sub1Scale);
            sub1Image_back.SetActive(false);
        }
        if (button == sub2Button)
        {
            Scaling(sub2Image);
            sub2Image_back.SetActive(true);
        }
        else if (button != sub2Button)
        {
            sub2Image.transform.localScale = Reset_ImageScale(_sub2Scale);
            sub2Image_back.SetActive(false);
        }
        if (button == sub3Button)
        {
            Scaling(sub3Image);
            sub3Image_back.SetActive(true);
        }
        else if (button != sub3Button)
        {
            sub3Image.transform.localScale = Reset_ImageScale(_sub3Scale);
            sub3Image_back.SetActive(false);
        }
        if (button == mainButton)
        {
            Scaling(mainImage);
            mainImage_back.SetActive(true);
        }
        else if (button != mainButton)
        {
            mainImage.transform.localScale = Reset_ImageScale(_mainScale);
            mainImage_back.SetActive(false);
        }
        if (button == ExitButton)
        {
            Scaling(ExitImage);
            ExitImage_back.SetActive(true);
        }
        else if (button != ExitButton)
        {
            ExitImage.transform.localScale = Reset_ImageScale(_ExitScale);
            ExitImage_back.SetActive(false);
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
