using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GoalJudge : MonoBehaviour
{
    [SerializeField] private int GoalCount = 15;
    [SerializeField] private TextMeshProUGUI Score;
    public static bool GoalFlag = false;
    private int Goal;

    void Update()
    {
        Score.text =""+ Goal;
        if (GoalCount <= 0)
        {
            Debug.Log("Stage3 Clear");
            GameDirector.GameClear = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "soccerball")
        {
            GoalCount--;
            Goal++;
            Debug.Log(GoalCount);
            GoalFlag = true;
            Destroy(other.gameObject,0.0f);
        }
    }
}
