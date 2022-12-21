using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FriendlyGoalJudge : MonoBehaviour
{
    [SerializeField] private int GameOverCount = 15;
    [SerializeField] private TextMeshProUGUI DFScore;

    public static bool EnemyGoalFlag = false;
    private int EnemyGoalCount;

    private void Start()
    {
        EnemyGoalCount = 0;
    }

    void Update()
    {
        DFScore.text = "" + EnemyGoalCount;

        if (GameOverCount <= 0)
        {
            Debug.Log("Stage3 GameOver");
            GameDirector.GameOver = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "soccerball"
            || other.gameObject.name == "RefSoccerBall")
        {
            GameOverCount--;
            EnemyGoalCount++;
            EnemyGoalFlag = true;
            Destroy(other.gameObject, 0.0f);
        }
    }
}
