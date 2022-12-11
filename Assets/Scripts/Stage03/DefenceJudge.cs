using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenceJudge : MonoBehaviour
{
    [SerializeField] static private int GameOverCount = 5;
    [SerializeField] private Transform PlayerPos;

    public static bool DefenceFlag = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameOverCount == 0)
        {
            Debug.Log("Stage3 GameOver");
            GameDirector.GameOver = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "SoccerBall")
        {
            GameOverCount--;
            RefrectBall(other.gameObject, PlayerPos);
            Debug.Log(GameOverCount);
            DefenceFlag = true;
        }
    }

    void RefrectBall(GameObject obj,Transform position)
    {
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(
            transform.position.x, transform.position.y, transform.position.z), 
            ForceMode.Impulse);
    }
}
