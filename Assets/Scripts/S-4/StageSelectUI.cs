using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class StageSelectUI : MonoBehaviour
{
    [SerializeField]
    public UnityEvent unityEvent = new UnityEvent();

    [SerializeField] GameObject UIWindow;
    [SerializeField] float GameWindow;
    [SerializeField] float StageNum;
    [SerializeField] GameObject [] button;
    int whereinNum = 0;
    RectTransform rect;
    float WindowSize;
    int WindowNum;
    // Start is called before the first frame update
    void Start()
    {
        rect = UIWindow.GetComponent<RectTransform>();
        WindowSize = UIWindow.GetComponent<RectTransform>().rect.width;
        //WindowNum = UIWindow.GetComponent<RectTransform>().rect.width / StageNum;
        Debug.Log(WindowSize);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Joystick1Button5) && whereinNum < StageNum)
        {
            rect.localPosition += new Vector3(-GameWindow, 0, 0);
            whereinNum++;
            Debug.Log(whereinNum);
            Debug.Log(StageNum);
        }

        if (Input.GetKeyDown(KeyCode.Joystick1Button4) && whereinNum > 0)
        {
            rect.localPosition += new Vector3(GameWindow, 0, 0);
            whereinNum--;
            Debug.Log(whereinNum);
            Debug.Log(StageNum);
        }

        if(Input.GetKey(KeyCode.Joystick1Button1))
        {
            unityEvent.Invoke();
            EventSystem.current.SetSelectedGameObject(button[5]);
        }

        if(whereinNum == 0)
        {
            button[0].SetActive(true);
            if (Input.GetKey(KeyCode.Joystick1Button0))
            {
                EventSystem.current.SetSelectedGameObject(button[0]);
            }
        }
        else button[0].SetActive(false);

        if (whereinNum == 1)
        {
            button[1].SetActive(true);
            if (Input.GetKey(KeyCode.Joystick1Button0))
            {
                EventSystem.current.SetSelectedGameObject(button[1]);
            }
        }
        else button[1].SetActive(false);

        if (whereinNum == 2)
        {
            button[2].SetActive(true);
            if (Input.GetKey(KeyCode.Joystick1Button0))
            {
                EventSystem.current.SetSelectedGameObject(button[2]);
            }
        }
        else button[2].SetActive(false);

        if (whereinNum == 3)
        {
            button[3].SetActive(true);
            if (Input.GetKey(KeyCode.Joystick1Button0))
            {
                EventSystem.current.SetSelectedGameObject(button[3]);
            }
        }
        else button[3].SetActive(false);
        if (whereinNum == 4)
        {
            button[4].SetActive(true);
            if (Input.GetKey(KeyCode.Joystick1Button0))
            {
                EventSystem.current.SetSelectedGameObject(button[4]);
            }
        }
        else button[4].SetActive(false);
    }
}
