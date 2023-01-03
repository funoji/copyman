using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class M1UI : MonoBehaviour
{
    [SerializeField] float CountDown = default!;
    [SerializeField] TextMeshProUGUI countdown;
    //[SerializeField] TextMeshProUGUI GameOverText;
    //[SerializeField] [Tooltip("ƒ{ƒ^ƒ“‚Ì•\Ž¦")] GameObject transtion;

    public GameObject GameCleaPanel;
    public GameObject GameOverPanel;

    // Start is called before the first frame update
    public void Awake()
    {
        //transtion.SetActive(false);
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
            //GameOverText.text = "GAMEOVER";
            GameOverPanel.SetActive(true);
        }
        if(GameDirector.GameClear == true)
        {
            //GameOverText.text = "GameClear";
            //transtion.SetActive(true);
            //EventSystem.current.SetSelectedGameObject(transtion);

            GameCleaPanel.SetActive(true);
        }
    }
}
