using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OneAwakeSEScript : MonoBehaviour
{
    [SerializeField] private AudioSource SEAudioClip;
    [SerializeField] private Slider SESlider;
    [SerializeField] private Slider MasterSlider;

    void Start()
    {
        SEAudioClip = GetComponent<AudioSource>();
    }

    public void ValueChenge()
    {
        SEAudioClip.volume = SESlider.value * MasterSlider.value;
        SEAudioClip.Play();
    }
}
