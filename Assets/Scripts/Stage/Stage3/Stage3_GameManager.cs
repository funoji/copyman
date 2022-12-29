using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3_GameManager : MonoBehaviour
{
    [SerializeField] float onElevatorCount;
    [SerializeField] Stage3_CrearFlag stage3_CrearFlag;
    [SerializeField] MoveGimmick[] elevator;

    private bool onElevetor = false;
    void Update()
    { 
        JudgeCount();
        OnElevator();
    }

    void OnElevator()
    {
        if (!onElevetor) return;
        for(int i = 0;i<elevator.Length;i++)
        {
            elevator[i].ActiveGimmick = true;
        }
    }

    void JudgeCount()
    {
        if (stage3_CrearFlag.pushButtonNum >= onElevatorCount) onElevetor = true;
    }

}
