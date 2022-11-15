using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PocketJudgeScript : MonoBehaviour
{
    [SerializeField] GameObject SmartBall;
    [SerializeField] Transform SpawnPoint;
    [SerializeField] TextMeshProUGUI PocketCount;
    [SerializeField] private int PocketIndex;
    [SerializeField] private int MaxCount = 15;

    public static int FinishCount = 30;
    public int WinBall;

    public float waitTime = 1.0f;

    private void Start()
    {
        SpawnPoint = GameObject.Find("SpawnPoint OutSide").transform;
        transform.localScale = new Vector3(-1, 1, 1);
    }

    void Update()
    {
        PocketCount.text = ""+PocketIndex;
        PocketCount.transform.LookAt(Camera.main.transform);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "SmartBall" ||
            other.gameObject.name == "SmartBall(Clone)")
        {
            Destroy(other.gameObject,0.1f);
            StartCoroutine("Spawn");
            if (PocketIndex < MaxCount)
            {
                PocketIndex++;
                WinBall++;
            }
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
