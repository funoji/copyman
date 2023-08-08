using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource bgmAudioSource;
    [SerializeField] AudioSource seAudioSource;

    [SerializeField] List<BGMSoundData> bgmSoundDatas;
    [SerializeField] List<SESoundData> seSoundDatas;

    [SerializeField] private Slider BGMslider;
    [SerializeField] private Slider SEslider;
    [SerializeField] private Slider MasterSlider;

    public static float masterVolume = 1;
    public static float bgmMasterVolume = 1;
    public static float seMasterVolume = 1;

    public static AudioManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void BGMValueChange()
    {
        bgmAudioSource.volume = BGMslider.value;
    }
    public void SEValueChenge()
    {
        seAudioSource.volume = SEslider.value;
    }

    public void MasterValueChange()
    {
        bgmAudioSource.volume = MasterSlider.value;
        seAudioSource.volume = MasterSlider.value;
    }

    public void PlayBGM(BGMSoundData.BGM bgm)
    {
        BGMSoundData data = bgmSoundDatas.Find(data => data.bgm == bgm);
        bgmAudioSource.clip = data.audioClip;
        bgmAudioSource.volume = data.volume * bgmMasterVolume * masterVolume;
        bgmAudioSource.volume = BGMslider.value;
        bgmAudioSource.volume = MasterSlider.value;
        bgmAudioSource.Play();
    }


    public void PlaySE(SESoundData.SE se)
    {
        SESoundData data = seSoundDatas.Find(data => data.se == se);
        seAudioSource.volume = data.volume * seMasterVolume * masterVolume;
        seAudioSource.volume = SEslider.value;
        seAudioSource.volume = MasterSlider.value;
        seAudioSource.PlayOneShot(data.audioClip);
    }

}

[System.Serializable]
public class BGMSoundData
{
    public enum BGM
    {
        Title,
        Stage1,
        Stage2,
        Stage3,
        Stage4,
        Tutlial,
        Menu,
        StageClear,
        Gameover
    }

    public BGM bgm;
    public AudioClip audioClip;
    [Range(0, 1)]
    public float volume = 0.5f;
}

[System.Serializable]
public class SESoundData
{
    public enum SE
    {
        jump,
        landing,
        copy,
        paste,
        shotpaste,
        walk,
        Buck_ClickButton,
        A_ClickButton,
        explosion,
        button,
        treasuryMove,
        timeLimit,
        gameOver,
        gameClear,
    }

    public SE se;
    public AudioClip audioClip;
    [Range(0, 1)]
    public float volume = 1;
}