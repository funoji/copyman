using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

//パネルがフェイドアウトする仕様
public class Fade_Manager : MonoBehaviour
{
    //fade
    [System.Serializable]
    public struct FadeSystem
    {
        public float fadeTime;
        public Image fadeImage;
        public bool fadeIn;
        public bool fadeOut;
        [HideInInspector]
        public float _alpha;
    }
    public FadeSystem[] fadeSystem;

    //sound
    public bool sound_fadeIn;
    public bool sound_fadeOut;

    public AudioSource[] audioSource;
    public float soundfadeTime;
    public float soundVolume;
    public bool _soundBool;

    private float _fadetime;
    private int _fadeNum;

    private void Start()
    {
        for(_fadeNum=0;_fadeNum< fadeSystem.Length;_fadeNum++)
        {
            fadeSystem[_fadeNum]._alpha = fadeSystem[_fadeNum].fadeImage.color.a;
        }
    }

    private void Update()
    {
        for (_fadeNum = 0; _fadeNum < fadeSystem.Length; _fadeNum++)
        {
            if (fadeSystem[_fadeNum].fadeIn)
            {
                FadeIn(_fadeNum);
            }
            if (fadeSystem[_fadeNum].fadeOut)
            {
                FadeOut(_fadeNum);
            }
        }

        if (sound_fadeIn) { Sound_FadeIn(); }
        if (sound_fadeOut) { Sound_FadeOut(); }
    }

    void FadeOut(int Num)
    {
        fadeSystem[Num].fadeImage.enabled = true;
        fadeSystem[Num]._alpha += fadeSystem[Num].fadeTime;
        Set_Alpha(Num);
        if (fadeSystem[Num]._alpha >= 1) { fadeSystem[Num].fadeOut = false;  }
    }

    void FadeIn(int Num)
    {
        fadeSystem[Num]._alpha -= fadeSystem[Num].fadeTime;
        Set_Alpha(Num);
        if (fadeSystem[Num]._alpha <= 0.0f) { fadeSystem[Num].fadeImage.enabled = false; fadeSystem[Num].fadeIn = false; }
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
            if (audioSource[num].volume > soundVolume) { audioSource[num].volume = soundVolume; }
            else if (audioSource[num].volume < soundVolume) { audioSource[num].volume = (float)(_fadetime / soundfadeTime); }
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
        for (int num = 0; num < audioSource.Length; num++) { audioSource[num].volume = (float)(soundVolume - _fadetime / soundfadeTime); }
    }

    void Set_Alpha(int Num)
    {
        fadeSystem[Num].fadeImage.color = new Color(fadeSystem[Num].fadeImage.color.r, fadeSystem[Num].fadeImage.color.g, fadeSystem[Num].fadeImage.color.b, fadeSystem[Num]._alpha);
    }

}
