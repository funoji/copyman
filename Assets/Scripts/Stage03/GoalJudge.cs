using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GoalJudge : MonoBehaviour
{
    [SerializeField] private int GoalCount = 15;
    [SerializeField] private TextMeshProUGUI CPMScore;

    public static bool CPMGoalFlag = false;
    private int FriendGoalCount;

    private void Start()
    {
        FriendGoalCount = 0;
    }

    void Update()
    {
        CPMScore.text = "" + FriendGoalCount;

        if (GoalCount <= 0)
        {
            Debug.Log("Stage3 Clear");
            GameDirector.GameClear = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "soccerball"
            || other.gameObject.name == "RefSoccerBall")
        {
            GoalCount--;
            FriendGoalCount++;
            CPMGoalFlag = true;
            Destroy(other.gameObject, 0.0f);
        }
    }
}
