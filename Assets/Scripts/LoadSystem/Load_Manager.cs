using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Video;

public class Load_Manager : MonoBehaviour
{
    // LoadIngObject�p�ϐ�
    public GameObject loadImage;
    public VideoPlayer loadVideo;
    public int loadTime;

    // AudioSource
    //public AudioSource audioSource;
    public GameObject audioSource;

    // �ۑ��p�ϐ�
    private float count = 0;

    // ���[�h�̏�����L���ɂ��邩�̔��������ϐ�
    public bool _isLoadPlay;

    private void Awake()
    {
        // BGM���ꎞ��~
        //audioSource.Stop();
        audioSource.SetActive(false);

        // ���C���̓�����~
        Time.timeScale = 0f;

        // ���[�h��ʂ�\��
        loadImage.SetActive(true);

        // ���[�h����Đ�
        loadVideo.Play();
    }

    private void Update()
    {
        Video_Player();
    }

    public void Video_Player()
    {
        count++;

        if (count >= loadTime)
        {
            // �������Ă��Ȃ������ꍇ
            //if (!audioSource.isPlaying)
            //{
            //    // BGM���Đ�
            //    audioSource.Play();
            //}
            audioSource.SetActive(true);

            // ���[�h���
            loadImage.SetActive(false);
            loadVideo.Stop();

            // ���C���̓�����Đ�
            Time.timeScale = 1.0f;
        }
    }
}
