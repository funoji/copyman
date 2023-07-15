using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3_GameManager : MonoBehaviour
{
    [SerializeField] float onElevatorCount;
    [SerializeField] float spawnBomNum;
    [SerializeField] GameObject boms;
    [SerializeField] Transform spawnPos;
    [SerializeField] Stage3_CrearFlag stage3_CrearFlag;
    [SerializeField] MoveGimmick[] elevator;

    private bool onElevetor = false;
    private bool isactive = true;

    void Update()
    { 
        OnElevator();
    }

    void OnElevator()
    {
        if (!isactive) return;
        JudgeCount();
        if (!onElevetor) return;

        for(int i = 0;i<elevator.Length;i++)
        {
            elevator[i].ActiveGimmick = true;
        }

        StartCoroutine(SpawnBoms());
        isactive = false;
    }

    void JudgeCount()
    {
        if (stage3_CrearFlag.PushButtonNum >= onElevatorCount) onElevetor =true;
    }

    IEnumerator SpawnBoms()
    {
        for (int i = 0; i < spawnBomNum; i++)
        {
            GameObject bom = Instantiate(boms, spawnPos);
            Rigidbody rb = bom.GetComponent<Rigidbody>();

            bom.transform.position = spawnPos.position;
            bom.name = boms.name;
            rb.AddForce(new Vector3(100f, 0, 0), ForceMode.Acceleration);

            yield return new WaitForSeconds(0.2f);
        }
        StopCoroutine(SpawnBoms());
    }

}
