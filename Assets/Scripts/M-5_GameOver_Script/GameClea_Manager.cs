using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClea_Manager : MonoBehaviour
{
    public AudioSource audioSource;

    private void Start()
    {
        audioSource.volume = 0;
    }
}
