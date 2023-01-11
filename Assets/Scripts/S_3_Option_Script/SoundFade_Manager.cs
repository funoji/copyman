using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//FedeIn‚ªI‚í‚Á‚½‚çSound‚ğ—¬‚·
public class SoundFade_Manager : MonoBehaviour
{
    //Fade_Manager‚ÌQÆ
    [SerializeField]
    public Fade_Manager fade;

    //AudioSource‚ÌQÆ
    public AudioSource audioSource;

    private void Start()
    {
        //‰¹—Ê‚ğ‚O‚É‰Šú‰»
        audioSource.volume = 0f;
    }

    private void Update()
    {
        //FadeIn‚ğ”»’è‚·‚é
        if (!fade.fadeSystem[0].fadeIn)
        {
            for(int num = 0; num < fade.audioSource.Length; num++) { fade.sound_fadeIn = true; }
        }
    }
}
