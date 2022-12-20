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

    public float masterVolume = 1;
    public float bgmMasterVolume = 1;
    public float seMasterVolume = 1;

    public static AudioManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayBGM(BGMSoundData.BGM bgm)
    {
        BGMSoundData data = bgmSoundDatas.Find(data => data.bgm == bgm);
        bgmAudioSource.clip = data.audioClip;
        bgmAudioSource.volume = data.volume * bgmMasterVolume * masterVolume;
        bgmAudioSource.Play();
    }


    public void PlaySE(SESoundData.SE se)
    {
        SESoundData data = seSoundDatas.Find(data => data.se == se);
        seAudioSource.volume = data.volume * seMasterVolume * masterVolume;
        seAudioSource.PlayOneShot(data.audioClip);
    }

    //public void BGMValueChange()
    //{
    //    bgmMasterVolume = BGMslider.value;
    //}
    //public void SEValueChenge()
    //{
    //    seMasterVolume = SEslider.value;
    //}

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
        Menu
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
        A_ClickButton
    }

    public SE se;
    public AudioClip audioClip;
    [Range(0, 1)]
    public float volume = 1;
}