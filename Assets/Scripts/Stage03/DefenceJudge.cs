using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DefenceJudge : MonoBehaviour
{
    [SerializeField] static private int GameOverCount = 5;
    [SerializeField] private float Power = 0.5f;
    //[SerializeField] private Transform PlayerPos;
    [SerializeField] private TextMeshProUGUI Score;

    private static int Count = 0;

    public static bool DefenceFlag = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Score.text =""+ Count;
        if(GameOverCount == 0)
        {
            GameDirector.GameOver = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "soccerball")
        {
            Count++;
            GameOverCount--;
            RefrectBall(other.gameObject);
            other.gameObject.name = "RefSoccerBall";
            DefenceFlag = true;
        }
    }

    void RefrectBall(GameObject obj)
    {
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(-2,2,25) * Power,
            ForceMode.Impulse);
    }
}
