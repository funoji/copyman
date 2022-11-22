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
            GameDirector.GameClear = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "SockerBall")
        {
            GoalCount--;
            GoalFlag = true;
            Destroy(other.gameObject,0.0f);
        }
    }
}
