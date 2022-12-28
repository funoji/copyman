using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Loading_ReadIn : MonoBehaviour
{
    [SerializeField, Header("�t�F�[�h�p�̃X�N���v�g")]
    S_1_Fadeout_Script fadeScript;
    [SerializeField, Header("�T�E���h��AudioSource\n��AudioSource�����Ă��������B��")]
    AudioSource[] audioSource;

    [Space(5), Header("���[�h���")]
    public GameObject loadImage;
    public VideoPlayer loadVideo;
    [Header("�����[�h��ʂ̍Đ����Ԃ����Ă��������B��\n1000�c��U�b�@500�c��Q�b")]
    public float loadTime;

    private float count = 0;

    private void Start()
    {
        //�R���|�[�l���g�擾
        loadVideo = GetComponent<VideoPlayer>();
        //���[�h��ʂ�\��
        loadImage.SetActive(true);

        //���[�h����Đ�
        loadVideo.Play();
        //BGM���ꎞ��~
        for (int num = 0; num < audioSource.Length; num++)
        {
            audioSource[num].Pause();
            audioSource[num].volume = 0;
        }

        //���C���̓�����~
        Time.timeScale = 0;
    }

    private void Update()
    {
        Video_Player();
    }

    public void Video_Player()
    {
        count++;
        Debug.Log("Count : " + count);
        if (count >= loadTime)
        {
            //���[�h���
            loadVideo.Stop();
            loadImage.SetActive(false);
            fadeScript.fadeIn = true;

            //�T�E���h
            for(int num=0;num<audioSource.Length;num++)
                audioSource[num].Play();
            fadeScript.sound_fadeIn = true;

            //���C���̓�����Đ�
            Time.timeScale = 1.0f;
        }
    }
}
