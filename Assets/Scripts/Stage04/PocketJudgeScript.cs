using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PocketJudgeScript : MonoBehaviour
{
    [SerializeField] GameObject SmartBall;
    [SerializeField] Transform SpawnPoint;

    public int WinBall;

    public float waitTime = 1.0f;

    void Update()
    {

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
        for (int i = 0; i < WinBall; i++)
        {
            Instantiate(SmartBall, SpawnPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(waitTime);
            if (i == WinBall - 1)
                yield break;
        }
    }
}
