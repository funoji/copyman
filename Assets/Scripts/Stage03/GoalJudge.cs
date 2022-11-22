using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalJudge : MonoBehaviour
{
    [SerializeField] private int GoalCount = 15;
    public static bool GoalFlag = false;

    void Update()
    {
        if (GoalCount == 0)
        {
            Debug.Log("Stage3 Clear");
            GameDirector.GameClear = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SoccerBall")
        {
            GoalCount--;
            Debug.Log(GoalCount);
            GoalFlag = true;
            Destroy(other.gameObject,0.0f);
        }
    }
}
