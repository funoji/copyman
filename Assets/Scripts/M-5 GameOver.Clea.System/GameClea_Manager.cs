using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClea_Manager : MonoBehaviour
{
    //AudioSource‚ÌQÆ
    public AudioSource audioSource;

    private void Start()
    {
        //Sound‚Ì‰¹—Ê‚ğ‚O‚É‚·‚é
        audioSource.Stop();
    }
}
