using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Load_Manager: MonoBehaviour
{
    //LoadIngObject用変数
    public GameObject loadImage;
    public VideoPlayer loadVideo;
    public int loadTime;

    //AudioSource
    public AudioSource audioSource;

    //保存用変数
    private float count = 0;

    private void Start()
    {
        //BGMを一時停止
        audioSource.Stop();
        //audioSource.SetActive(false);

        //メインの動作を停止
        Time.timeScale = 0f;

        //ロード画面を表示
        loadImage.SetActive(true);

        //ロード動画再生
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
            // 音が鳴っていなかったら
            if (!audioSource.isPlaying)
            {
                // BGMを再生
                audioSource.Play();
            }

            //ロード画面
            loadImage.SetActive(false);
            loadVideo.Stop();

            //メインの動作を再生
            Time.timeScale = 1.0f;
        }
    }
}
