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
    //Fade_Manager�p�ϐ�
    public Fade_Manager fadeScript;  //

    //LoadIngObject�p�ϐ�
    public GameObject loadImage;  //
    public float loadTime;
    public VideoPlayer loadVideo;  //

    //�Œ艻����Ă���Object�p�ϐ�
    public Image[] fixationImage;
    public TextMeshProUGUI fixationText;
    public bool _textObj;

    //AudioSoucrce
    public AudioSource[] audioSource;  //

    //�ۑ��p�ϐ�
    private float count = 0;

    private void Start()
    {
        //���C���̓�����~
        Time.timeScale = 0;

        //BGM���ꎞ��~
        for (int num = 0; num < audioSource.Length; num++)
        {
            audioSource[num].Pause();
            audioSource[num].volume = 0;
        }

        //�R���|�[�l���g�擾
        loadVideo = GetComponent<VideoPlayer>();
        //���[�h��ʂ�\��
        loadImage.SetActive(true);

        //���[�h����Đ�
        loadVideo.Play();

        //
        if (_textObj) 
        {
            fixationText.color = new Color(fixationText.color.r, fixationText.color.g, fixationText.color.b, 0);
            fadeScript.fadeSystem[1].textObj = fixationText;
            for (int num = 1; num < fixationImage.Length; num++)
            {
                fadeScript.fadeSystem[num].fadeIn = false;
                fadeScript.fadeSystem[num].fadeOut = false;

                fixationImage[num].color = new Color(fixationImage[num].color.r, fixationImage[num].color.g, fixationImage[num].color.b, 0);
                fadeScript.fadeSystem[num + 1].imageObj = fixationImage[num];
            }
        }
        else
        {
            for (int num = 0; num < fixationImage.Length; num++)
            {
                fadeScript.fadeSystem[num].fadeIn = false;
                fadeScript.fadeSystem[num].fadeOut = false;

                fixationImage[num].color = new Color(fixationImage[num].color.r, fixationImage[num].color.g, fixationImage[num].color.b, 0);
                fadeScript.fadeSystem[num + 1].imageObj = fixationImage[num];
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
            //���[�h���
            loadVideo.Stop();
            loadImage.SetActive(false);
            fadeScript.fadeSystem[0].fadeIn = true;

            //���C���̓�����Đ�
            Time.timeScale = 1.0f;

            //UI�֘A�̌Œ肳��Ă�����̂�\��

            for (int num = 1; num < fadeScript.fadeSystem.Length; num++)
            {
                fadeScript.fadeSystem[num].fadeOut = true;
            }

            //�T�E���h
            for (int num = 0; num < audioSource.Length; num++) { audioSource[num].Play(); }
            fadeScript.sound_fadeIn = true;
        }
    }
}
