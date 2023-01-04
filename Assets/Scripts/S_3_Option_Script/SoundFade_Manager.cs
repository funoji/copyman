using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFade_Manager : MonoBehaviour
{
    [SerializeField]
    public Fade_Manager fade;

    public AudioSource audioSource;

    private void Start()
    {
        audioSource.volume = 0f;
    }

    private void Update()
    {
        if (!fade.fadeSystem[0].fadeIn)
        {
            for(int num = 0; num < fade.audioSource.Length; num++) { fade.sound_fadeIn = true; }
        }
    }
}
