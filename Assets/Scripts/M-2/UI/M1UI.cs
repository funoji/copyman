using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using Cinemachine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class M1UI : MonoBehaviour
{
    [SerializeField] float CountDown = default!;
    [SerializeField] TextMeshProUGUI countdown;
    [SerializeField] PlayableDirector timeLimitTimeLine;
    [SerializeField] PlayableDirector ClearTimeLine;
    [SerializeField] [Tooltip("Debug_Camera_Animator Reference")] Animator animator;
    //[SerializeField] TextMeshProUGUI GameOverText;
    //[SerializeField] [Tooltip("ボタンの表示")] GameObject transtion;

    private bool _countBool;

    public GameObject GameCleaPanel;
    public GameObject GameOverPanel;

    public float first_limit;
    public float second_limit;
    private bool _sound;
    private bool _first_limit_sound;
    private bool _first_gameover;

    // Start is called before the first frame update
    public void Awake()
    {
        //transtion.SetActive(false);
        _countBool = false;

        //AudioiSource
        _sound = false;
        _first_limit_sound = true;
        _first_gameover = true;

        first_limit = 50f;
        second_limit = 10f;
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
        if (CountDown <= first_limit && CountDown >= first_limit - 1)
        {
            if (_first_limit_sound)
            {
                timeLimitTimeLine.Play();
                countdown.fontSize = 100f;
                countdown.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
                _first_limit_sound = false;
            }
        }
        //１０秒以下になったら音楽を鳴らす
        if (CountDown <= second_limit && CountDown >= 0)
        {
            if (!_sound)
            {
                timeLimitTimeLine.Play();
                _sound = true;
            }
        }

        if(CountDown <=0)
        {
            //ゲーム時間(CoundDwon)を止める
            _countBool = true;

            //ゲームオーバー画面表示
            GameDirector.GameOver = true;
        }

        if (GameDirector.GameOver == true /*&& _first_gameover*/)
        {
            _first_gameover = false;
            //ゲーム時間(CoundDwon)を止める
            _countBool = true;

            StartCoroutine("GameOver");
            //GameDirector.GameOver = false;
        }
        if (GameDirector.GameClear == true)
        {
            //GameOverText.text = "GameClear";
            //transtion.SetActive(true);
            //EventSystem.current.SetSelectedGameObject(transtion);

            //ゲーム時間(CoundDwon)を止める
            _countBool = true;

            StartCoroutine("GameClear");
            //GameDirector.GameClear = false;
        }
    }

    IEnumerator GameOver()
    {
        animator.SetBool("isGameOver", true);
        animator.Play("dead");
        yield return new WaitForSeconds(1.0f);
        AudioManager.Instance.PlaySE(SESoundData.SE.gameOver);
        yield return new WaitForSeconds(0.5f);
        //ゲームオーバー画面表示
        GameOverPanel.SetActive(true);
    }
    IEnumerator GameClear()
    {
        //ゲームクリア画面表示
        ClearTimeLine.Play();
        yield return 0;
    }
}
