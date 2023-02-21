using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectSEManager : MonoBehaviour
{
    [SerializeField] AudioSource seAudioSource;

    [SerializeField] List<ObjectSESoundData> seSoundDatas;

    public float masterVolume = 1;
    public float seMasterVolume = 1;

    public static ObjectSEManager Instance { get; private set; }

    private void Start()
    {
        masterVolume = AudioManager.masterVolume;
        seMasterVolume = AudioManager.seMasterVolume;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void PlaySE(ObjectSESoundData.Object se)
    {
        ObjectSESoundData data = seSoundDatas.Find(data => data.se == se);
        seAudioSource.volume = data.volume * seMasterVolume * masterVolume;
        seAudioSource.PlayOneShot(data.audioClip);
    }

}

[System.Serializable]
public class ObjectSESoundData
{
    public enum Object
    {
        Cornbar,
        Pylon,
        Firehydrant,
        Can,
        Vendingmachine,
        Trashbox,
        Barricade,
        Ladybug,
        Switch,
        Flyer,
        Lamp,
        Foliageplant,
        Table,
        Money,
        Rocketfireworks,
        mirror,
        Rock,
        Target,
        Drum,
        Drumdanger,
        Chain,
        Fan,
        Soccerball,
        Bom,
        Nail,
        Poket,
        Sheep,
        PotatoChips,
        Smartball,
        Trophy
    }

    public Object se;
    public AudioClip audioClip;
    [Range(0, 1)]
    public float volume = 1;
}
