using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class A_BallGenerator : MonoBehaviour
{
    [SerializeField] Transform SpawnPoint;
    [SerializeField] GameObject ball;
    [SerializeField] GameObject Canvas;
    [SerializeField] TextMeshProUGUI Score;

    [SerializeField] private int LoseRate = 5;
    public int Clearcount = 50;

    [SerializeField] private Vector3 minPower;
    [SerializeField] private Vector3 maxPower;
    [SerializeField] private float waitTime = 5.0f;
    [SerializeField] private float WinwaitTime = 1.0f;

    private int GenerateCount = 0;
    private bool IsGenerating = false;

    Rigidbody rb;

    void Start()
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        Canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GenerateCount == 0)
        {
            GenerateCount = 1;
            StartCoroutine("Spawn");
        }
        if (Clearcount <= 0)
        {
            Canvas.SetActive(true);
            GameDirector.GameClear = true;
            Score.alpha = 0.0f;
        }

        Score.text = "ƒNƒŠƒA‚Ü‚ÅF" + Clearcount + "ŒÂ";

    }

    private IEnumerator Spawn()
    {
        int count = 0;
        do
        {
            IsGenerating = true;
            Vector3 Power = (new Vector3(Random.Range(minPower.x, maxPower.x),
                                         Random.Range(minPower.y, maxPower.y),
                                        -Random.Range(minPower.z, maxPower.z)));

            GameObject obj = Instantiate(ball, SpawnPoint);

            rb = obj.GetComponent<Rigidbody>();
            rb.AddForce(Power, ForceMode.Impulse);
            if (GenerateCount <= 4)
                yield return new WaitForSeconds(waitTime);
            if (GenerateCount > 5)
                yield return new WaitForSeconds(WinwaitTime);
            count++;
            Debug.Log("GenerateCount=" + GenerateCount);
        } while (count <= GenerateCount);
        GenerateCount = 0;
        IsGenerating = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "SmartBall" ||
            other.gameObject.name == "SmartBall(Clone)")
        {
            GenerateCount++;
            Clearcount--;

            Destroy(other.gameObject);

            if (IsGenerating == false)
            {
                if (GenerateCount >= LoseRate)
                {
                    StartCoroutine("Spawn");
                    GenerateCount -= LoseRate;
                }
            }
        }
    }
}
