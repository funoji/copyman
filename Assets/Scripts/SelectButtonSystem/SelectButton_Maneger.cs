using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;

public class SelectButton_Maneger : MonoBehaviour
{
    // 選択状態の種類
    public enum ModeType
    {
        none,
        size,
        image,
        normal
    }

    public ModeType mode;

    //ボタンの設定
    [System.Serializable]
    public struct SelectData
    {
        // Inspectorで表示する名前
        public string buttonName;
        // Buttonオブジェクトの変数
        public GameObject buttonObj;
        // Imageの変数
        public GameObject buttonImage;
        // 大きさの保存用変数
        [HideInInspector] public Vector3 _buttonScale;
    }
    public SelectData[] selectData;

    //戻るボタンの設定
    public bool ExitButton = true;

    [System.Serializable]
    public struct ExitData
    {
        // オブジェクトの変数
        public GameObject exitButton;
        // オブジェクトのImageの変数
        public GameObject exitImage;
        // 大きさの保存用変数
        [HideInInspector] public Vector3 _exitImage;
    }
    public ExitData exitData;

    // 選択状態がサイズの変更時用の変数
    // サイズが変わるスピード
    public float scallSpeed = 0.1f;
    // 大きさが最大になる時間
    public float maxTime = 1f;
    // 時間の保存用変数
    private float time;
    // 変化する大きさの値を保存する変数
    private float scallSize;
    // 拡大縮小の判定をする変数
    private bool enlarge = true;

    // 選択したボタンの保存する変数
    private GameObject _button;

    // Eventの取得
    public UnityEvent events = new UnityEvent();

    private void Start()
    {
        // 初期の選択状態をスタートボタンに設定 
        if (ExitButton && selectData.Length == 0)
        {
            EventSystem.current.SetSelectedGameObject(exitData.exitButton);
        }
        else
        {
            EventSystem.current.SetSelectedGameObject(selectData[0].buttonObj);
        }


        // モードごとの初期化
        if (mode == ModeType.size)
        {
            // 初期の大きさを保存
            for (int num = 0; num < selectData.Length; num++)
            {
                selectData[num]._buttonScale = selectData[num].buttonImage.transform.localScale;
            }
        }
        if (mode == ModeType.image)
        {
            // 初期の表示を設定
            for (int num = 0; num < selectData.Length; num++)
            {
                selectData[num].buttonImage.SetActive(false);
            }
        }
        if (ExitButton)
        {
            exitData._exitImage = exitData.exitImage.transform.localScale;
        }
    }

    //各モードの時の処理
    private void Update()
    {
        if (mode == ModeType.size)
        {
            Select_Size();
        }
        if (mode == ModeType.image)
        {
            Select_Image();
        }
        if (mode == ModeType.normal)
        {
            Select_Normal();
        }
    }

    //選択状態：画像
    public void Select_Image()
    {
        //現在選択中のボタンを保存 
        _button = EventSystem.current.currentSelectedGameObject;

        //コントローラー用　ボタン選択状態の設定
        if (Input.GetKeyDown(KeyCode.Joystick1Button1) && ExitButton == true)
        {
            EventSystem.current.SetSelectedGameObject(exitData.exitButton); events.Invoke();
        }

        //選択されているボタンを拡大縮小させる。終わったら初期の大きさに戻す 
        for (int num = 0; num < selectData.Length; num++)
        {
            if (_button == selectData[num].buttonObj)
            {
                selectData[num].buttonImage.SetActive(true);
            }
            else if (_button != selectData[num].buttonObj)
            {
                selectData[num].buttonImage.SetActive(false);
            }
        }

        if (ExitButton)
        {
            if (_button == exitData.exitButton)
            {
                Scaling(exitData.exitImage);
            }
            else if (_button != exitData.exitButton)
            {
                exitData.exitImage.transform.localScale = Reset_ImageScale(exitData._exitImage);
            }
        }
    }

    //選択状態：ノーマル
    public void Select_Normal()
    {
        //現在選択中のボタンを保存 
        _button = EventSystem.current.currentSelectedGameObject;

        //コントローラー用　ボタン選択状態の設定
        if (Input.GetKeyDown(KeyCode.Joystick1Button1) && ExitButton == false)
        {
            EventSystem.current.SetSelectedGameObject(selectData[1].buttonObj); events.Invoke();
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button1) && ExitButton == true)
        {
            EventSystem.current.SetSelectedGameObject(exitData.exitButton); events.Invoke();
        }
    }

    //選択状態：大きさ
    public void Select_Size()
    {
        //現在選択中のボタンを保存
        _button = EventSystem.current.currentSelectedGameObject;

        //コントローラー用　ボタン選択状態の設定
        if (Input.GetKeyDown(KeyCode.Joystick1Button1) && ExitButton == true)
        {
            EventSystem.current.SetSelectedGameObject(exitData.exitButton); events.Invoke();
        }

        //選択されているボタンを拡大縮小させる。終わったら初期の大きさに戻す 
        for (int num = 0; num < selectData.Length; num++)
        {
            if (_button == selectData[num].buttonObj)
            {
                Scaling(selectData[num].buttonImage);
            }
            else
            {
                selectData[num].buttonImage.transform.localScale = Reset_ImageScale(selectData[num]._buttonScale);
            }
        }

        if (ExitButton)
        {
            if (_button == exitData.exitButton)
            {
                Scaling(exitData.exitImage);
            }
            else if (_button != exitData.exitButton)
            {
                exitData.exitImage.transform.localScale = Reset_ImageScale(exitData._exitImage);
            }
        }
    }
    //拡大縮小の演出の処理
    void Scaling(GameObject image)
    {
        scallSize = Time.deltaTime * scallSpeed;

        if (time < 0) { enlarge = true; }
        if (time > maxTime) { enlarge = false; }

        if (enlarge)
        {
            time += Time.deltaTime;
            image.transform.localScale += new Vector3(scallSize, scallSize, scallSize);
        }
        else
        {
            time -= Time.deltaTime;
            image.transform.localScale -= new Vector3(scallSize, scallSize, scallSize);
        }
    }

    //大きさの初期化
    Vector3 Reset_ImageScale(Vector3 afterObj)
    {
        return afterObj;
    }
}
