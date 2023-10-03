using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClea_Manager : MonoBehaviour
{
    // AudioSource‚ÌQÆ
    [SerializeField] private AudioSource audioSource;

    private void Start()
    {
        // Sound‚ğ~‚ß‚é
        audioSource.Stop();
    }
}
