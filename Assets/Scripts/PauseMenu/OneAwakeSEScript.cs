using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OneAwakeSEScript : MonoBehaviour
{
    [SerializeField] private AudioSource SEAudioClip;

    void Start()
    {
        SEAudioClip = GetComponent<AudioSource>();
    }

    public void ValueChenge()
    {
        SEAudioClip.Play();
    }
}
