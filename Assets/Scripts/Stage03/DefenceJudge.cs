using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenceJudge : MonoBehaviour
{
    [SerializeField] static private int GameOverCount = 5;

    public static bool DefenceFlag = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameOverCount == 0)
        {
            GameDirector.GameOver = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "SockerBall")
        {
            GameOverCount--;
            DefenceFlag = true;
        }
    }
}
