using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Loading_ReadIn : MonoBehaviour
{
    [SerializeField, Header("フェード用のスクリプト")]
    S_1_Fadeout_Script fadeScript;
    [SerializeField, Header("サウンドのAudioSource\n※AudioSourceを入れてください。※")]
    AudioSource[] audioSource;

    [Space(5), Header("ロード画面")]
    public GameObject loadImage;
    public VideoPlayer loadVideo;
    [Header("※ロード画面の再生時間を入れてください。※\n1000…約６秒　500…約２秒")]
    public float loadTime;

    [Space(5), Header("その他\n※カメラに固定されているUIを入れてください。※")]
    public GameObject Image;

    private float count = 0;

    private void Start()
    {
        //コンポーネント取得
        loadVideo = GetComponent<VideoPlayer>();
        //ロード画面を表示
        loadImage.SetActive(true);

        //ロード動画再生
        loadVideo.Play();
        //BGMを一時停止
        for (int num = 0; num < audioSource.Length; num++)
        {
            audioSource[num].Pause();
            audioSource[num].volume = 0;
        }

        //メインの動作を停止
        Time.timeScale = 0;

        //UI関連の固定されているものを非表示にする
        Image.SetActive(false);
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
            //ロード画面
            loadVideo.Stop();
            loadImage.SetActive(false);
            fadeScript.fadeIn = true;

            //サウンド
            for(int num=0;num<audioSource.Length;num++)
                audioSource[num].Play();
            fadeScript.sound_fadeIn = true;

            //メインの動作を再生
            Time.timeScale = 1.0f;

            //UI関連の固定されているものを表示
            Image.SetActive(true);
        }
    }
}
