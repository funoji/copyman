using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClea_Manager : MonoBehaviour
{
    // AudioSource�̎Q��
    [SerializeField] private AudioSource audioSource;

    private void Start()
    {
        // Sound���~�߂�
        audioSource.Stop();
    }
}
