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
    // fade
    [System.Serializable]
    public struct FadeSystem
    {
        // フェードする時間
        public float fadeTime;
        // フェード用Image
        public Image imageObj;
        public bool fadeIn;
        public bool fadeOut;
        // Imageの透明度保存用変数
        [HideInInspector] public float _alpha;

        // TextObjectを使用する場合の判定設定
        public bool _textObj;
        // フェード用Text
        public TextMeshProUGUI textObj;
    }
    public FadeSystem[] fadeSystem;

    // sound
    public bool sound_fadeIn;
    public bool sound_fadeOut;

    // Sound用AuvioSource
    public AudioSource[] audioSource;
    // フェードインする時間
    public float soundfadeIn_Time;
    // フェードアウトする時間
    public float soudfadeOut_Time;
    // フェードした後の音量
    public float soundVolume;
    public bool _soundBool;

    // フェードイン用の変数
    private float _fadetime;
    // For文用の変数
    private int _fadeNum;

    private void Start()
    {
        // 元のObjectの透明度を保存
        if (fadeSystem[_fadeNum]._textObj)
        {
            fadeSystem[_fadeNum]._alpha = fadeSystem[_fadeNum].textObj.color.a;
        }
        else
        {
            fadeSystem[_fadeNum]._alpha = fadeSystem[_fadeNum].imageObj.color.a;
        }
    }

    private void Update()
    {

        // フェードイン・フェードアウトを判定
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

        // Soundのフェードイン・フェイドアウトを判定
        if (sound_fadeIn)
        {
            Sound_FadeIn();
        }
        if (sound_fadeOut)
        {
            Sound_FadeOut();
        }
    }

    // Object用フェードアウト
    public void FadeOut(int Num)
    {
        // Objectを表示したら、透明度を上げる
        if (fadeSystem[Num]._textObj)
        {
            fadeSystem[Num].textObj.enabled = true;
            fadeSystem[Num]._alpha += fadeSystem[Num].fadeTime;
            Set_AlphaText(Num);
            if (fadeSystem[Num]._alpha >= 1)
            {
                fadeSystem[Num].fadeOut = false;
            }
        }
        else
        {
            fadeSystem[Num].imageObj.enabled = true;
            fadeSystem[Num]._alpha += fadeSystem[Num].fadeTime;
            Set_AlphaImage(Num);
            if (fadeSystem[Num]._alpha >= 1)
            {
                fadeSystem[Num].fadeOut = false;
            }
        }
    }

    // object用フェードイン
    public void FadeIn(int Num)
    {
        // 透明度を下げたら、Objectを非表示にする
        if (fadeSystem[Num]._textObj)
        {
            fadeSystem[Num]._alpha -= fadeSystem[Num].fadeTime;
            Set_AlphaText(Num);
            if (fadeSystem[Num]._alpha <= 0.0f)
            {
                fadeSystem[Num].textObj.enabled = false;
                fadeSystem[Num].fadeIn = false;
            }
        }
        else
        {
            fadeSystem[Num]._alpha -= fadeSystem[Num].fadeTime;
            Set_AlphaImage(Num);
            if (fadeSystem[Num]._alpha <= 0.0f)
            {
                fadeSystem[Num].imageObj.enabled = false;
                fadeSystem[Num].fadeIn = false;
            }
        }
    }

    // Sound用フェードイン
    public void Sound_FadeIn()
    {
        // 時間を加算
        _fadetime += Time.deltaTime;
        for (int num = 0; num < audioSource.Length; num++)
        {
            // 音量を上げていき、指定のところで止める
            if (audioSource[num].volume > soundVolume)
            {
                audioSource[num].volume = soundVolume; sound_fadeIn = false;
            }
            else if (audioSource[num].volume < soundVolume)
            {
                audioSource[num].volume = (soundfadeIn_Time * _fadetime);
            }
        }
    }

    // Sound用フェードアウト
    public void Sound_FadeOut()
    {
        for (int num = 0; num < audioSource.Length; num++)
        {
            // 音量を０まで下げる
            audioSource[num].volume -= soudfadeOut_Time;
            if (audioSource[num].volume <= 0)
            {
                sound_fadeOut = false;
            }
        }
    }

    // Image用の透明度をセットする関数
    void Set_AlphaImage(int Num)
    {
        fadeSystem[Num].imageObj.color = new Color(fadeSystem[Num].imageObj.color.r, fadeSystem[Num].imageObj.color.g, fadeSystem[Num].imageObj.color.b, fadeSystem[Num]._alpha);
    }

    // Text用の透明度をセットする関数
    void Set_AlphaText(int Num)
    {
        fadeSystem[Num].textObj.color = new Color(fadeSystem[Num].textObj.color.r, fadeSystem[Num].textObj.color.g, fadeSystem[Num].textObj.color.b, fadeSystem[Num]._alpha);
    }
}
