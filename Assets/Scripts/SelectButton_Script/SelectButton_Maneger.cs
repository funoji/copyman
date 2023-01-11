using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;

public class SelectButton_Maneger : MonoBehaviour
{
    //選択状態の種類
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
        public string buttonName;  //Inspectorで表示する名前
        public GameObject buttonObj;  //Buttonオブジェクトの変数
        public GameObject buttonImage;  //Imageの変数
        [HideInInspector]
        public Vector3 _buttonScale;  //大きさの保存用変数
    }
    [SerializeField]
    public SelectData[] selectData;

    //戻るボタンの設定
    public bool ExitButton = true;
    [System.Serializable]
    public struct ExitData
    {
        public GameObject exitButton;  //オブジェクトの変数
        public GameObject exitImage;  //オブジェクトのImageの変数
        [HideInInspector]
        public Vector3 _exitImage;  //大きさの保存用変数
    }
    public ExitData exitData;

    //選択状態がサイズの変更時用の変数
    public float scallSpeed;  //サイズが変わるスピード
    public  float maxTime;  //大きさが最大になる時間
    private float time;  //時間の保存用変数
    private bool enlarge = true;

    //選択したボタンの保存する変数
    private GameObject _button;

    //Eventの取得
    [SerializeField]
    public UnityEvent events = new UnityEvent();

    //ボタンが一つだけの時にEventを使用しない場合に使用する判定
    public bool _pushBool;

    private void Start()
    {
        //初期の選択状態をスタートボタンに設定 : Set initial selection status to Start button
        if (ExitButton && selectData.Length == 0) { EventSystem.current.SetSelectedGameObject(exitData.exitButton); }
        else { EventSystem.current.SetSelectedGameObject(selectData[0].buttonObj); }
        //Debug.Log(selectData[0].buttonObj);

        //モードごとの初期化
        if (mode == ModeType.size)
        {
            //初期の大きさを保存
            for (int num = 0; num < selectData.Length; num++) { selectData[num]._buttonScale = selectData[num].buttonImage.transform.localScale; }
        }
        if (mode == ModeType.image)
        {
            //初期の表示を設定
            for (int num = 0; num < selectData.Length; num++) { selectData[num].buttonImage.SetActive(false); }
        }
        if (ExitButton) { exitData._exitImage = exitData.exitImage.transform.localScale; }
    }

    //各モードの時の処理
    private void Update()
    {
        if (mode == ModeType.size) { Select_Size(); }
        if (mode == ModeType.image) { Select_Image(); }
        if (mode == ModeType.normal) { Select_Normal(); }
    }

    //選択状態：画像
    public void Select_Image()
    {
        //現在選択中のボタンを保存 : Save the currently selected button
        _button = EventSystem.current.currentSelectedGameObject;
        //Debug.Log(_button.name);

        //コントローラー用　ボタン選択状態の設定 : For Controller Set button selection status
        if (Input.GetKeyDown(KeyCode.Joystick1Button1) && ExitButton == false) { EventSystem.current.SetSelectedGameObject(selectData[1].buttonObj); events.Invoke(); }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button1) && ExitButton == false&&_pushBool) { EventSystem.current.SetSelectedGameObject(selectData[0].buttonObj); }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button1) && ExitButton == true) { EventSystem.current.SetSelectedGameObject(exitData.exitButton); events.Invoke(); }

        //選択されているボタンを拡大縮小させる。終わったら初期の大きさに戻す : Scale the selected button. When done, return to initial size.
        for (int num = 0; num < selectData.Length; num++)
        {
            if (_button == selectData[num].buttonObj) { selectData[num].buttonImage.SetActive(true); }
            else if (_button != selectData[num].buttonObj) { selectData[num].buttonImage.SetActive(false); }
        }

        if (ExitButton)
        {
            if (_button == exitData.exitButton) { Scaling(exitData.exitImage); }
            else if (_button != exitData.exitButton) { exitData.exitImage.transform.localScale = Reset_ImageScale(exitData._exitImage); }
        }
    }

    //選択状態：ノーマル
    public void Select_Normal()
    {
        //現在選択中のボタンを保存 : Save the currently selected button
        _button = EventSystem.current.currentSelectedGameObject;
        //Debug.Log(_button.name);

        //コントローラー用　ボタン選択状態の設定 : For Controller Set button selection status
        if (Input.GetKeyDown(KeyCode.Joystick1Button1) && ExitButton == false) { EventSystem.current.SetSelectedGameObject(selectData[1].buttonObj); events.Invoke(); }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button1) && ExitButton == true) { EventSystem.current.SetSelectedGameObject(exitData.exitButton); events.Invoke(); }
    }

    //選択状態：大きさ
    public void Select_Size()
    {
        //現在選択中のボタンを保存 : Save the currently selected button
        _button = EventSystem.current.currentSelectedGameObject;
        Debug.Log(_button.name);

        //コントローラー用　ボタン選択状態の設定 : For Controller Set button selection status
        if (Input.GetKeyDown(KeyCode.Joystick1Button1) && ExitButton == false&&!_pushBool) { EventSystem.current.SetSelectedGameObject(selectData[1].buttonObj); events.Invoke(); }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button1) && ExitButton == false && _pushBool) { EventSystem.current.SetSelectedGameObject(selectData[0].buttonObj); }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button1) && ExitButton == true) { EventSystem.current.SetSelectedGameObject(exitData.exitButton); events.Invoke(); }

        //選択されているボタンを拡大縮小させる。終わったら初期の大きさに戻す : Scale the selected button. When done, return to initial size.
        for (int num = 0; num < selectData.Length; num++)
        {
            if (_button == selectData[num].buttonObj) { Scaling(selectData[num].buttonImage); }
            else { selectData[num].buttonImage.transform.localScale = Reset_ImageScale(selectData[num]._buttonScale); }
        }

        if (ExitButton)
        {
            if (_button == exitData.exitButton) { Scaling(exitData.exitImage); }
            else if (_button != exitData.exitButton) { exitData.exitImage.transform.localScale = Reset_ImageScale(exitData._exitImage); }
        }
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
            image.transform.localScale -= new Vector3(scallSpeed,scallSpeed, scallSpeed);
        }
    }

    //大きさの初期化 : Size initialization
    Vector3 Reset_ImageScale(Vector3 afterObj)
    {
        return afterObj;
    }
}
