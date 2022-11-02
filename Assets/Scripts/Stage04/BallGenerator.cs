using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGenerator : MonoBehaviour
{
    [SerializeField] Transform SpawnPoint;
    [SerializeField] GameObject ball;
    [SerializeField] GameObject Canvas;

    [SerializeField] private int LoseRate = 5;
    [SerializeField] private int WinRate = 1;
    [SerializeField] private int Clearcount = 0;

    Rigidbody rb;

    public float minPower = 1.0f;
    public float maxPower = 10f;
    public float waitTime = 5.0f;

    private int GenerateCount = 0;

    private bool IsGenerating = false;

    void Start()
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        Canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(GenerateCount == 0)
        {
            GenerateCount = 1;
            StartCoroutine("Spawn");
        }
        if(Clearcount == 50)
        {
            //クリア条件の場所（ここにシーンの遷移を入れる）
            Canvas.SetActive(true);
        }

    }

    private IEnumerator Spawn()
    {
        int count = 0;
        do
        {
            IsGenerating = true;
            Vector3 Power = (new Vector3(Random.Range(minPower, maxPower),
                                        0,
                                        -Random.Range(minPower, maxPower)));

            GameObject obj = Instantiate(ball, SpawnPoint);

            rb = obj.GetComponent<Rigidbody>();
            rb.AddForce(Power,ForceMode.Impulse);

            yield return new WaitForSeconds(waitTime);
            count++;
            Debug.Log("GenerateCount=" + GenerateCount);
        } while (count <= GenerateCount);

        IsGenerating=false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name=="SmartBall" ||
            other.gameObject.name == "SmartBall(Clone)")
        {
            GenerateCount++;
            Clearcount++;

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
