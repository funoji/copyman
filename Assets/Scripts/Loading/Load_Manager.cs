using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using TMPro;

public class Load_Manager: MonoBehaviour
{
    public Fade_Manager fadeScript;
    public AudioSource[] audioSource;

    public GameObject loadImage;
    public VideoPlayer loadVideo;
    ///[Header("※ロード画面の再生時間を入れてください。※\n1000…約６秒　500…約２秒")]
    public float loadTime;
    public Image[] fixationImage;
    public bool _textObj;
    public TextMeshProUGUI fixationText;

    private float count = 0;

    private void Start()
    {
        //メインの動作を停止
        Time.timeScale = 0;

        //BGMを一時停止
        for (int num = 0; num < audioSource.Length; num++)
        {
            audioSource[num].Pause();
            audioSource[num].volume = 0;
        }

        //コンポーネント取得
        loadVideo = GetComponent<VideoPlayer>();
        //ロード画面を表示
        loadImage.SetActive(true);

        //ロード動画再生
        loadVideo.Play();

        if (_textObj) 
        {
            fixationText.color = new Color(fixationText.color.r, fixationText.color.g, fixationText.color.b, 0);
            fadeScript.fadeSystem[1].textObj = fixationText;
            for (int num = 1; num < fixationImage.Length; num++)
            {
                fadeScript.fadeSystem[num].fadeIn = false;
                fadeScript.fadeSystem[num].fadeOut = false;

                fixationImage[num].color = new Color(fixationImage[num].color.r, fixationImage[num].color.g, fixationImage[num].color.b, 0);
                fadeScript.fadeSystem[num + 1].fadeImage = fixationImage[num];
            }
        }
        else
        {
            for (int num = 0; num < fixationImage.Length; num++)
            {
                fadeScript.fadeSystem[num].fadeIn = false;
                fadeScript.fadeSystem[num].fadeOut = false;

                fixationImage[num].color = new Color(fixationImage[num].color.r, fixationImage[num].color.g, fixationImage[num].color.b, 0);
                fadeScript.fadeSystem[num + 1].fadeImage = fixationImage[num];
            }

        }
    }

    private void Update()
    {
        Video_Player();
    }

    public void Video_Player()
    {
        count++;
        //Debug.Log("Count : " + count);
        if (count >= loadTime)
        {
            //ロード画面
            loadVideo.Stop();
            loadImage.SetActive(false);
            fadeScript.fadeSystem[0].fadeIn = true;

            //メインの動作を再生
            Time.timeScale = 1.0f;

            //UI関連の固定されているものを表示
            for (int num = 1; num < fadeScript.fadeSystem.Length; num++)
            {
                fadeScript.fadeSystem[num].fadeOut = true;
            }

            //サウンド
            for (int num = 0; num < audioSource.Length; num++) { audioSource[num].Play(); }
            fadeScript.sound_fadeIn = true;
        }
    }
}
