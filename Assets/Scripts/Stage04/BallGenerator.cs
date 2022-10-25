using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGenerator : MonoBehaviour
{
    [SerializeField] Transform SpawnPoint;
    [SerializeField] GameObject ball;

    [SerializeField] private int LoseRate = 5;
    [SerializeField] private int WinRate = 1;

    Rigidbody rb;

    public float minPower = 1.0f;
    public float maxPower = 10f;
    private int randomPower;
    public float waitTime = 5.0f;

    private int GenerateCount = 0;

    private bool IsGenerating;

    void Start()
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        IsGenerating = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator Spawn()
    {
        int count = 0;
        do
        {
            //randomPower = (int)Random.Range(minPower, maxPower);
            Vector3 Power = (new Vector3(Random.Range(minPower, maxPower),
                                        0,
                                        -Random.Range(minPower, maxPower)));

            GameObject obj = Instantiate(ball, SpawnPoint);

            rb = obj.GetComponent<Rigidbody>();
            rb.AddForce(Power,ForceMode.Impulse);

            yield return new WaitForSeconds(waitTime);
            count++;
        } while (count < WinRate);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name=="SmartBall" ||
            other.gameObject.name == "SmartBall(Clone)")
        {
            GenerateCount++;

            Destroy(other.gameObject);

            if (GenerateCount >= LoseRate)
            {
                 IsGenerating=true;
                 StartCoroutine("Spawn");
            }
        }
    }
}
