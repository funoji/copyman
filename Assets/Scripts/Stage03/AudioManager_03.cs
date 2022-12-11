using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager_03 : MonoBehaviour
{
    [SerializeField] private AudioClip IsGoal;
    [SerializeField] private AudioClip IsDefenced;

    new AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GoalJudge.GoalFlag)
        {
            audio.PlayOneShot(IsGoal);
            GoalJudge.GoalFlag=false;
        }
        if (DefenceJudge.DefenceFlag)
        {
            audio.PlayOneShot(IsDefenced);
            DefenceJudge.DefenceFlag=false;
        }
    }
}
