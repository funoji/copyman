using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PocketJudgeScript : MonoBehaviour
{
    [SerializeField] GameObject SmartBall;
    [SerializeField] Transform SpawnPoint;

    private int IsIn = 0;

    public static int FinishCount = 30;
    public int WinBall;

    public float waitTime = 1.0f;

    private bool ClearFlag = false;

    void Update()
    {
        if(IsIn == FinishCount)
        {
            ClearFlag = true;
            Debug.Log(ClearFlag);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "SmartBall" ||
            other.gameObject.name == "SmartBall(Clone)")
        {
            Destroy(other.gameObject,0.1f);
            StartCoroutine("Spawn");
        }
    }

    public IEnumerator Spawn()
    {
        IsIn++;
        for (int i = 0; i < WinBall; i++)
        {
            Instantiate(SmartBall, SpawnPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(waitTime);
            if (i == WinBall - 1)
                yield break;
        }
    }
}
