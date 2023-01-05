using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class StageSelectUI : MonoBehaviour
{
    [Space(5)]
    [SerializeField] GameObject UIWindow;
    [SerializeField] float GameWindow;
    [SerializeField] float StageNum;
    [SerializeField] GameObject[] button;
    int whereinNum = 0;
    RectTransform rect;
    float WindowSize;
    int WindowNum;
    public UnityEvent unityEvent = new UnityEvent();

    // Start is called before the first frame update
    void Start()
    {
        rect = UIWindow.GetComponent<RectTransform>();
        WindowSize = UIWindow.GetComponent<RectTransform>().rect.width;
        //WindowNum = UIWindow.GetComponent<RectTransform>().rect.width / StageNum;
        //Debug.Log(WindowSize);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button5) && whereinNum < StageNum)
        {
           AudioManager.Instance.PlaySE(SESoundData.SE.A_ClickButton);

            rect.localPosition += new Vector3(-GameWindow, 0, 0);
            whereinNum++;
            //Debug.Log(whereinNum);
            //Debug.Log(StageNum);
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button4) && whereinNum > 0)
        {
            AudioManager.Instance.PlaySE(SESoundData.SE.A_ClickButton);

            rect.localPosition += new Vector3(GameWindow, 0, 0);
            whereinNum--;
            //Debug.Log(whereinNum);
            //Debug.Log(StageNum);
        }

        if(Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            SceneManager.LoadScene("S-02_Menu_Scene");   
        }

        //Tutorial
        if(whereinNum == 0)
        {
            button[0].SetActive(true);
            if (Input.GetKey(KeyCode.Joystick1Button0))
            {
                SceneManager.LoadScene("Tutorial");
            }
        }
        else
        {
            button[0].SetActive(false);
        }

        //Stage1
        if (whereinNum == 1)
        {
            button[1].SetActive(true);
            if (Input.GetKey(KeyCode.Joystick1Button0))
            {
                SceneManager.LoadScene("Stage1");
            }
        }
        else 
        {
            button[1].SetActive(false);
        }

        //Stage2
        if (whereinNum == 2)
        {
            button[2].SetActive(true);
            if (Input.GetKey(KeyCode.Joystick1Button0))
            {
                SceneManager.LoadScene("Stage2");
            }
        }
        else 
        {
            button[2].SetActive(false);
        }

        //Stage3
        if (whereinNum == 3)
        {
            button[3].SetActive(true);
            if (Input.GetKey(KeyCode.Joystick1Button0))
            {
                SceneManager.LoadScene("Stage3");
            }
        }
        else
        {
            button[3].SetActive(false);
        }

        //Stage4
        if (whereinNum == 4)
        {
            button[4].SetActive(true);
            if (Input.GetKey(KeyCode.Joystick1Button0))
            {
                SceneManager.LoadScene("Stage4");
            }
        }
        else
        {
            button[4].SetActive(false);
        }
    }
}
