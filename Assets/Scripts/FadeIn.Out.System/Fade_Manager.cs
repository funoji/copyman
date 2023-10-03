using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

//�p�l�����t�F�C�h�A�E�g����d�l
public class Fade_Manager : MonoBehaviour
{
    // fade
    [System.Serializable]
    public struct FadeSystem
    {
        // �t�F�[�h���鎞��
        public float fadeTime;
        // �t�F�[�h�pImage
        public Image imageObj;
        public bool fadeIn;
        public bool fadeOut;
        // Image�̓����x�ۑ��p�ϐ�
        [HideInInspector] public float _alpha;

        // TextObject���g�p����ꍇ�̔���ݒ�
        public bool _textObj;
        // �t�F�[�h�pText
        public TextMeshProUGUI textObj;
    }
    public FadeSystem[] fadeSystem;

    // sound
    public bool sound_fadeIn;
    public bool sound_fadeOut;

    // Sound�pAuvioSource
    public AudioSource[] audioSource;
    // �t�F�[�h�C�����鎞��
    public float soundfadeIn_Time;
    // �t�F�[�h�A�E�g���鎞��
    public float soudfadeOut_Time;
    // �t�F�[�h������̉���
    public float soundVolume;
    public bool _soundBool;

    // �t�F�[�h�C���p�̕ϐ�
    private float _fadetime;
    // For���p�̕ϐ�
    private int _fadeNum;

    private void Start()
    {
        // ����Object�̓����x��ۑ�
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

        // �t�F�[�h�C���E�t�F�[�h�A�E�g�𔻒�
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

        // Sound�̃t�F�[�h�C���E�t�F�C�h�A�E�g�𔻒�
        if (sound_fadeIn)
        {
            Sound_FadeIn();
        }
        if (sound_fadeOut)
        {
            Sound_FadeOut();
        }
    }

    // Object�p�t�F�[�h�A�E�g
    public void FadeOut(int Num)
    {
        // Object��\��������A�����x���グ��
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

    // object�p�t�F�[�h�C��
    public void FadeIn(int Num)
    {
        // �����x����������AObject���\���ɂ���
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

    // Sound�p�t�F�[�h�C��
    public void Sound_FadeIn()
    {
        // ���Ԃ����Z
        _fadetime += Time.deltaTime;
        for (int num = 0; num < audioSource.Length; num++)
        {
            // ���ʂ��グ�Ă����A�w��̂Ƃ���Ŏ~�߂�
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

    // Sound�p�t�F�[�h�A�E�g
    public void Sound_FadeOut()
    {
        for (int num = 0; num < audioSource.Length; num++)
        {
            // ���ʂ��O�܂ŉ�����
            audioSource[num].volume -= soudfadeOut_Time;
            if (audioSource[num].volume <= 0)
            {
                sound_fadeOut = false;
            }
        }
    }

    // Image�p�̓����x���Z�b�g����֐�
    void Set_AlphaImage(int Num)
    {
        fadeSystem[Num].imageObj.color = new Color(fadeSystem[Num].imageObj.color.r, fadeSystem[Num].imageObj.color.g, fadeSystem[Num].imageObj.color.b, fadeSystem[Num]._alpha);
    }

    // Text�p�̓����x���Z�b�g����֐�
    void Set_AlphaText(int Num)
    {
        fadeSystem[Num].textObj.color = new Color(fadeSystem[Num].textObj.color.r, fadeSystem[Num].textObj.color.g, fadeSystem[Num].textObj.color.b, fadeSystem[Num]._alpha);
    }
}
