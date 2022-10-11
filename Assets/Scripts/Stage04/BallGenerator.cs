using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGenerator : MonoBehaviour
{
    [SerializeField] Transform SpawnPoint;
    [SerializeField] GameObject ball;

    Rigidbody rb;

    public float minPower = 1.0f;
    public float maxPower = 10f;
    private int randomPower;
    public float waitTime = 5.0f;

    Vector3 Power;

    void Start()
    {
        Random.InitState(System.DateTime.Now.Millisecond);

        StartCoroutine("Spawn");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            randomPower = (int)Random.Range(minPower, maxPower);

            Debug.Log(randomPower);

            Power = new Vector3(0, randomPower, 0);
            Instantiate(ball, SpawnPoint);

            rb = ball.GetComponent<Rigidbody>();
            rb.AddForce(-Power.normalized,ForceMode.Impulse);

            yield return new WaitForSeconds(waitTime);
        }
    }
}
