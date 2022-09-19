using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class M1UI : MonoBehaviour
{
    [SerializeField] float CountDown = default!;
    [SerializeField] TextMeshProUGUI countdown;
    [SerializeField] TextMeshProUGUI GameOverText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CountDown -= Time.deltaTime;
        if(CountDown >= 0f)
        {
            countdown.text = CountDown.ToString("f1");
        }

        if(CountDown <=0)
        {
            GameDirector.GameOver = true;
        }

        if(GameDirector.GameOver == true)
        {
            GameOverText.text = "GAMEOVER";
        }
    }
}
