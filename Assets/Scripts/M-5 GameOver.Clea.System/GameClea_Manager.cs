using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClea_Manager : MonoBehaviour
{
    //AudioSource�̎Q��
    public AudioSource audioSource;

    private void Start()
    {
        //Sound�̉��ʂ��O�ɂ���
        audioSource.Stop();
    }
}
