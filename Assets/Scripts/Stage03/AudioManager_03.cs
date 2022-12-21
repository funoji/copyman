using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager_03 : MonoBehaviour
{
    [SerializeField] private AudioClip IsGoal;
    [SerializeField] private AudioClip IsDefenced;
    [SerializeField] private AudioClip IsLosed;

    new AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GoalJudge.CPMGoalFlag)
        {
            audio.PlayOneShot(IsGoal);
            GoalJudge.CPMGoalFlag=false;
        }
        if (DefenceJudge.DefenceFlag)
        {
            audio.PlayOneShot(IsDefenced);
            DefenceJudge.DefenceFlag=false;
        }
        if (FriendlyGoalJudge.EnemyGoalFlag)
        {
            audio.PlayOneShot(IsLosed);
            FriendlyGoalJudge.EnemyGoalFlag=false;
        }
    }
}
