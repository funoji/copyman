using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Load_Manager: MonoBehaviour
{
    //LoadIngObject�p�ϐ�
    public GameObject loadImage;
    public VideoPlayer loadVideo;
    public int loadTime;

    //AudioSource
    public AudioSource audioSource;

    //�ۑ��p�ϐ�
    private float count = 0;

    private void Start()
    {
        //BGM���ꎞ��~
        audioSource.Stop();
        //audioSource.SetActive(false);

        //���C���̓�����~
        Time.timeScale = 0f;

        //���[�h��ʂ�\��
        loadImage.SetActive(true);

        //���[�h����Đ�
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
            // �������Ă��Ȃ�������
            if (!audioSource.isPlaying)
            {
                // BGM���Đ�
                audioSource.Play();
            }

            //���[�h���
            loadImage.SetActive(false);
            loadVideo.Stop();

            //���C���̓�����Đ�
            Time.timeScale = 1.0f;
        }
    }
}
