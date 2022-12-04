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
    [SerializeField]
    S_1_SoundPlayer sound;
    [SerializeField] Loading_ReadIn load;
    [SerializeField] float fadeTime;
    [SerializeField] Image fadeImage;

    private float alpha, red, green, blue;
    public bool fadeIn;
    public bool fadeOut;
    public bool Player_Bool;

    private void Start()
    {
        Player_Bool = false;
        fadeImage = GetComponent<Image>();
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alpha = fadeImage.color.a;
    }

    private void Update()
    {
        if (load.Video_Player())
        {
            fadeImage.enabled = true;
            Player_FadeIn();
        }
        if (fadeIn) FadeIn();
        if (fadeOut) FadeOut();
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
            fadeOut = true;
            
        }
    }

    void Player_FadeIn()
    {
        alpha -= fadeTime;
        Set_Alpha();
        sound.FadeIn_Sound();
        if (alpha <= 0)
        {
            fadeImage.enabled = false;
            Player_Bool = true;
        }

    }

    void Set_Alpha()
    {
        fadeImage.color = new Color(0f, 0f, 0f, alpha);
    }
}
