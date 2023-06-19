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
    //[SerializeField] [Tooltip("�{�^���̕\��")] GameObject transtion;

    private bool _countBool;

    public GameObject GameCleaPanel;
    public GameObject GameOverPanel;

    [Header("������~�߂邽�߂̕ϐ�")]
    public GameObject[] stopObj;
    /*
     * ���A�^�b�`���Ăق����I�u�W�F�N�g
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

        //�v���C���[�̈ړ��A�W�����v�A�A�j���[�V�������~�߂�B
        stopObj[0].GetComponent<PlayerController>().enabled = true;
        stopObj[0].GetComponent<JumpManager>().enabled = true;
        stopObj[0].GetComponent<Animator_Controller>().enabled = true;
        //�v���C���[�̃R�s�[�y�[�X�g���~�߂�B
        stopObj[1].GetComponent<Copyinput>().enabled = true;
        //�J�����̈ړ����~�߂�B
        stopObj[2].GetComponent<CinemachineVirtualCamera>().enabled = true;
        //�|�[�Y��ʂ��N���ł��Ȃ�����B
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

        //�T�O�b�ȉ��ɂȂ�����e�L�X�g�̐F��Ԃɕς���
        if (CountDown <= first_limit&& CountDown >= 0f)
        {
            AudioManager.Instance.PlaySE(SESoundData.SE.timeLimit);
            countdown.fontSize = 100f;
            countdown.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        }
        //�P�O�b�ȉ��ɂȂ����特�y��炷
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
            //�Q�[������(CoundDwon)���~�߂�
            _countBool = true;

            //�Q�[���I�[�o�[��ʕ\��
            GameDirector.GameOver = true;

            //�v���C���[�̈ړ��A�W�����v�A�A�j���[�V�������~�߂�B
            stopObj[0].GetComponent<PlayerController>().enabled = false;
            stopObj[0].GetComponent<JumpManager>().enabled = false;
            stopObj[0].GetComponent<Animator_Controller>().enabled = false;
            //�v���C���[�̃R�s�[�y�[�X�g���~�߂�B
            stopObj[1].GetComponent<Copyinput>().enabled = false;
            //�J�����̈ړ����~�߂�B
            stopObj[2].GetComponent<CinemachineVirtualCamera>().enabled = false;
            //�|�[�Y��ʂ��N���ł��Ȃ�����B
            stopObj[3].GetComponent<CanvasActiveScript>().enabled = false;
        }

        if (GameDirector.GameOver == true)
        {
            //GameOverText.text = "GAMEOVER";

            //�Q�[������(CoundDwon)���~�߂�
            _countBool = true;

            //�Q�[���I�[�o�[��ʕ\��
            GameOverPanel.SetActive(true);

            //�v���C���[�̈ړ��A�W�����v�A�A�j���[�V�������~�߂�B
            stopObj[0].GetComponent<PlayerController>().enabled = false;
            stopObj[0].GetComponent<JumpManager>().enabled = false;
            stopObj[0].GetComponent<Animator_Controller>().enabled = false;
            //�v���C���[�̃R�s�[�y�[�X�g���~�߂�B
            stopObj[1].GetComponent<Copyinput>().enabled = false;
            //�J�����̈ړ����~�߂�B
            stopObj[2].GetComponent<CinemachineVirtualCamera>().enabled = false;
            //�|�[�Y��ʂ��N���ł��Ȃ�����B
            stopObj[3].GetComponent<CanvasActiveScript>().enabled = false;
        }
        if (GameDirector.GameClear == true)
        {
            //GameOverText.text = "GameClear";
            //transtion.SetActive(true);
            //EventSystem.current.SetSelectedGameObject(transtion);

            //�Q�[������(CoundDwon)���~�߂�
            _countBool = true;

            //�Q�[���N���A��ʕ\��
            GameCleaPanel.SetActive(true);

            //�v���C���[�̈ړ��A�W�����v�A�A�j���[�V�������~�߂�B
            stopObj[0].GetComponent<PlayerController>().enabled = false;
            stopObj[0].GetComponent<JumpManager>().enabled = false;
            stopObj[0].GetComponent<Animator_Controller>().enabled = false;
            //�v���C���[�̃R�s�[�y�[�X�g���~�߂�B
            stopObj[1].GetComponent<Copyinput>().enabled = false;
            //�J�����̈ړ����~�߂�B
            stopObj[2].GetComponent<CinemachineVirtualCamera>().enabled = false;
            //�|�[�Y��ʂ��N���ł��Ȃ�����B
            stopObj[3].GetComponent<CanvasActiveScript>().enabled = false;
            if (_bomDie) { stopObj[4].GetComponent<EnemyMove>().enabled = false; }
            GameDirector.GameOver = false;
        }
    }
}
