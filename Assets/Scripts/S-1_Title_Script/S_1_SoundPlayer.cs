using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_1_SoundPlayer : MonoBehaviour
{
    [SerializeField] Fade_Manager fade_Script;
    public AudioSource audio_Player;
    public double FadeInSeconds = 0.07;
    double FadeDeltaTime = 0;

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        audio_Player.volume = 0f;
    }

    // Update is called once per frame
    void Update()
    {

    }

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
