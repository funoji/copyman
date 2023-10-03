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
    //[SerializeField] [Tooltip("�{�^���̕\��")] GameObject transtion;

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

        //�T�O�b�ȉ��ɂȂ�����e�L�X�g�̐F��Ԃɕς���
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
        //�P�O�b�ȉ��ɂȂ����特�y��炷
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
            //�Q�[������(CoundDwon)���~�߂�
            _countBool = true;

            //�Q�[���I�[�o�[��ʕ\��
            GameDirector.GameOver = true;
        }

        if (GameDirector.GameOver == true /*&& _first_gameover*/)
        {
            _first_gameover = false;
            //�Q�[������(CoundDwon)���~�߂�
            _countBool = true;

            StartCoroutine("GameOver");
            //GameDirector.GameOver = false;
        }
        if (GameDirector.GameClear == true)
        {
            //GameOverText.text = "GameClear";
            //transtion.SetActive(true);
            //EventSystem.current.SetSelectedGameObject(transtion);

            //�Q�[������(CoundDwon)���~�߂�
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
        //�Q�[���I�[�o�[��ʕ\��
        GameOverPanel.SetActive(true);
    }
    IEnumerator GameClear()
    {
        //�Q�[���N���A��ʕ\��
        ClearTimeLine.Play();
        yield return 0;
    }
}
