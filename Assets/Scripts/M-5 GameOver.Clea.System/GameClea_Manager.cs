using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClea_Manager : MonoBehaviour
{
    //AudioSourceの参照
    public AudioSource audioSource;

    private void Start()
    {
        //Soundの音量を０にする
        audioSource.Stop();
    }
}
