using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using Cinemachine;

public class M1UI : MonoBehaviour
{
    [SerializeField] float CountDown = default!;
    [SerializeField] TextMeshProUGUI countdown;
    //[SerializeField] TextMeshProUGUI GameOverText;
    //[SerializeField] [Tooltip("ボタンの表示")] GameObject transtion;

    private bool _countBool;

    public GameObject GameCleaPanel;
    public GameObject GameOverPanel;

    [Header("動作を止めるための変数")]
    public GameObject[] stopObj;
    /*
     * ▼アタッチしてほしいオブジェクト
     * stopObj[0]  Player
     * stopObj[1]  Player->CPM
     * stopObj[2]  CameraSystem
     * stopObj[3]  GameManager
     */

    public bool _bomDie;

    public float first_limit;
    public float second_limit;
    private bool _sound;

    // Start is called before the first frame update
    public void Awake()
    {
        //transtion.SetActive(false);
        _countBool = false;

        //プレイヤーの移動、ジャンプ、アニメーションを止める。
        stopObj[0].GetComponent<PlayerController>().enabled = true;
        stopObj[0].GetComponent<JumpManager>().enabled = true;
        stopObj[0].GetComponent<Animator_Controller>().enabled = true;
        //プレイヤーのコピーペーストを止める。
        stopObj[1].GetComponent<Copyinput>().enabled = true;
        //カメラの移動を止める。
        stopObj[2].GetComponent<CinemachineVirtualCamera>().enabled = true;
        //ポーズ画面を起動できなくする。
        stopObj[3].GetComponent<CanvasActiveScript>().enabled = true;

        //AudioiSource
        _sound = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (!_countBool) { /*Time.timeScale = 1f;*/ CountDown -= Time.deltaTime; }
        if(CountDown >= 0f)
        {
            countdown.text = CountDown.ToString("f1");
        }

        //５０秒以下になったらテキストの色を赤に変える
        if (CountDown <= first_limit&& CountDown >= 0f)
        {
            AudioManager.Instance.PlaySE(SESoundData.SE.timeLimit);
            countdown.fontSize = 100f;
            countdown.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        }
        //１０秒以下になったら音楽を鳴らす
        if (CountDown <= second_limit && CountDown >= 0f)
        {
            if (!_sound)
            {
                AudioManager.Instance.PlaySE(SESoundData.SE.timeLimit);
                _sound = true;
            }
        }

        if(CountDown <=0)
        {
            //ゲーム時間(CoundDwon)を止める
            _countBool = true;

            //ゲームオーバー画面表示
            GameDirector.GameOver = true;

            //プレイヤーの移動、ジャンプ、アニメーションを止める。
            stopObj[0].GetComponent<PlayerController>().enabled = false;
            stopObj[0].GetComponent<JumpManager>().enabled = false;
            stopObj[0].GetComponent<Animator_Controller>().enabled = false;
            //プレイヤーのコピーペーストを止める。
            stopObj[1].GetComponent<Copyinput>().enabled = false;
            //カメラの移動を止める。
            stopObj[2].GetComponent<CinemachineVirtualCamera>().enabled = false;
            //ポーズ画面を起動できなくする。
            stopObj[3].GetComponent<CanvasActiveScript>().enabled = false;
        }

        if (GameDirector.GameOver == true)
        {
            //GameOverText.text = "GAMEOVER";

            //ゲーム時間(CoundDwon)を止める
            _countBool = true;

            //ゲームオーバー画面表示
            GameOverPanel.SetActive(true);

            //プレイヤーの移動、ジャンプ、アニメーションを止める。
            stopObj[0].GetComponent<PlayerController>().enabled = false;
            stopObj[0].GetComponent<JumpManager>().enabled = false;
            stopObj[0].GetComponent<Animator_Controller>().enabled = false;
            //プレイヤーのコピーペーストを止める。
            stopObj[1].GetComponent<Copyinput>().enabled = false;
            //カメラの移動を止める。
            stopObj[2].GetComponent<CinemachineVirtualCamera>().enabled = false;
            //ポーズ画面を起動できなくする。
            stopObj[3].GetComponent<CanvasActiveScript>().enabled = false;
        }
        if (GameDirector.GameClear == true)
        {
            //GameOverText.text = "GameClear";
            //transtion.SetActive(true);
            //EventSystem.current.SetSelectedGameObject(transtion);

            //ゲーム時間(CoundDwon)を止める
            _countBool = true;

            //ゲームクリア画面表示
            GameCleaPanel.SetActive(true);

            //プレイヤーの移動、ジャンプ、アニメーションを止める。
            stopObj[0].GetComponent<PlayerController>().enabled = false;
            stopObj[0].GetComponent<JumpManager>().enabled = false;
            stopObj[0].GetComponent<Animator_Controller>().enabled = false;
            //プレイヤーのコピーペーストを止める。
            stopObj[1].GetComponent<Copyinput>().enabled = false;
            //カメラの移動を止める。
            stopObj[2].GetComponent<CinemachineVirtualCamera>().enabled = false;
            //ポーズ画面を起動できなくする。
            stopObj[3].GetComponent<CanvasActiveScript>().enabled = false;
            if (_bomDie) { stopObj[4].GetComponent<EnemyMove>().enabled = false; }
            GameDirector.GameOver = false;
        }
    }
}
