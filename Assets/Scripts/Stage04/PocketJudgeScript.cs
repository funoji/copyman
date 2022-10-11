using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PocketJudgeScript : MonoBehaviour
{
    [SerializeField] GameObject SmartBall;
    [SerializeField] Transform SpawnPoint;

    private int IsFinish = 0;

    public int FinishCount = 5;
    public int WinBall;

    public float waitTime = 1.0f;

    private bool ClearFlag = false;

    void Update()
    {
        if(IsFinish == FinishCount)
        {
            ClearFlag = true;
            Debug.Log(ClearFlag);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SmartBall")
        {
            Destroy(other.gameObject,0.1f);
            StartCoroutine("Spawn");
        }
        if (other.gameObject.tag == "Player")
        {
            /*GameOver*/
        }
    }

    public IEnumerator Spawn()
    {
        IsFinish++;
        for (int i = 0; i < WinBall; i++)
        {
            Instantiate(SmartBall, SpawnPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(waitTime);
            if (i == WinBall - 1)
                yield break;
        }
    }
}
