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
    ///[Header("�����[�h��ʂ̍Đ����Ԃ����Ă��������B��\n1000�c��U�b�@500�c��Q�b")]
    public float loadTime;
    public Image[] fixationImage;
    public bool _textObj;
    public TextMeshProUGUI fixationText;

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
