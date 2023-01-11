using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_1_SoundPlayer : MonoBehaviour
{
    //Fade_Mameger�̎Q��
    [SerializeField] Fade_Manager fade_Script;
    public double FadeInSeconds = 0.07f;   //�ω����鎞��
    private double FadeDeltaTime = 0f;  //���Ԃ̕ۑ��p�ϐ�

    //AudioSource�̎Q��
    public AudioSource audio_Player;

    // Start is called before the first frame update
    void Start()
    {
        //���ʂ��O�ɏ�����
        audio_Player.volume = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        FadeIn_Sound();
    }

    //Sound��FadeIn
    public void FadeIn_Sound()
    {
        FadeDeltaTime += Time.deltaTime;
        if (FadeDeltaTime <= FadeInSeconds)
        {
            FadeDeltaTime = FadeInSeconds;
        }
        audio_Player.volume = (float)(FadeDeltaTime / FadeInSeconds);
    }
}
