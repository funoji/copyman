using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_1_SoundPlayer : MonoBehaviour
{
    //Fade_Mameger‚ÌQÆ
    [SerializeField] Fade_Manager fade_Script;
    public double FadeInSeconds = 0.07f;   //•Ï‰»‚·‚éŠÔ
    private double FadeDeltaTime = 0f;  //ŠÔ‚Ì•Û‘¶—p•Ï”

    //AudioSource‚ÌQÆ
    public AudioSource audio_Player;

    // Start is called before the first frame update
    void Start()
    {
        //‰¹—Ê‚ğ‚O‚É‰Šú‰»
        audio_Player.volume = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        FadeIn_Sound();
    }

    //Sound‚ÌFadeIn
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
