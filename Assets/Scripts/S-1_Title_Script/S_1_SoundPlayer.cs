using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_1_SoundPlayer : MonoBehaviour
{
    //Fade_Mamegerの参照
    [SerializeField] Fade_Manager fade_Script;
    public double FadeInSeconds = 0.07f;   //変化する時間
    private double FadeDeltaTime = 0f;  //時間の保存用変数

    //AudioSourceの参照
    public AudioSource audio_Player;

    // Start is called before the first frame update
    void Start()
    {
        //音量を０に初期化
        audio_Player.volume = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        FadeIn_Sound();
    }

    //SoundのFadeIn
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
