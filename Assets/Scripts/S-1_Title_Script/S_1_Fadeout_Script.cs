using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

//https://bluebirdofoz.hatenablog.com/entry/2017/09/11/231524

//パネルがフェイドアウトする仕様
public class S_1_Fadeout_Script : MonoBehaviour
{
    //public enum FadeMode
    //{
    //    fade,
    //    load
    //}

    //public FadeMode fadeMode;


    //Load
    [SerializeField, Header("Load")]
    public Loading_ReadIn load;

    //fade
    [Header("Fade")]
    public float fadeTime;
    public Image fadeImage;
    public bool fadeIn = false;
    public bool fadeOut = false;
    public bool sound_fadeIn = false;
    public bool sound_fadeOut = false;
    private float alpha, red, green, blue;

    //sound
    [Header("Sound\n※AudioSourceを入れてください。※")]
    public AudioSource[] audioSource;
    public float soundfadeTime;
    [Header("※ロード画面終了後の音量を入れてください。※")]
    public float soundVolume;
    private float _fadetime;

    private void Start()
    {
        //コンポーネント取得
        fadeImage = GetComponent<Image>();

        //フェードの色を取得
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alpha = fadeImage.color.a;
    }

    private void Update()
    {
        if (fadeIn) FadeIn();
        if (fadeOut) FadeOut();
        if (sound_fadeIn) Sound_FadeIn();
        if (sound_fadeOut) Sound_FadeOut();
    }

    void FadeOut()
    {
        fadeImage.enabled = true;
        alpha += fadeTime;
        Set_Alpha();
        if (alpha >= 1)
        {
            fadeOut = false;
        }
    }

    void FadeIn()
    {
        alpha -= fadeTime;
        Set_Alpha();
        if (alpha <= 0)
        {
            fadeImage.enabled = false ;
            fadeIn = false;
            
        }
    }

    void Set_Alpha()
    {
        fadeImage.color = new Color(0f, 0f, 0f, alpha);
    }

    public void Sound_FadeIn()
    {
        _fadetime += Time.deltaTime;
        if (_fadetime >= soundfadeTime)
        {
            _fadetime = soundfadeTime;
            sound_fadeIn = false;
        }

        for (int num = 0; num < audioSource.Length; num++)
        {
            if (audioSource[num].volume > soundVolume) audioSource[num].volume = soundVolume;
            else if (audioSource[num].volume < soundVolume) audioSource[num].volume = (float)(_fadetime / soundfadeTime);

        }
    }

    public void Sound_FadeOut()
    {
        _fadetime += Time.deltaTime;
        if (_fadetime >= soundfadeTime)
        {
            _fadetime = soundfadeTime;
            sound_fadeOut = false;
        }
        for(int num=0;num<audioSource.Length;num++)
            audioSource[num].volume = (float)(soundVolume - _fadetime / soundfadeTime);
    }
}
