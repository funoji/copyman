using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//FedeIn���I�������Sound�𗬂�
public class SoundFade_Manager : MonoBehaviour
{
    //Fade_Manager�̎Q��
    [SerializeField]
    public Fade_Manager fade;

    //AudioSource�̎Q��
    public AudioSource audioSource;

    private void Start()
    {
        //���ʂ��O�ɏ�����
        audioSource.volume = 0f;
    }

    private void Update()
    {
        //FadeIn�𔻒肷��
        if (!fade.fadeSystem[0].fadeIn)
        {
            for(int num = 0; num < fade.audioSource.Length; num++) { fade.sound_fadeIn = true; }
        }
    }
}
