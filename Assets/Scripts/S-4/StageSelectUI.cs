using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class StageSelectUI : MonoBehaviour
{
    [System.Serializable]
    public struct ButtonEvent
    {
        [Header("Tutorial button")]
        public UnityEvent tutorial;
        public GameObject tutorialObj;

        [Header("Stage1 button")]
        public UnityEvent stage1;
        public GameObject stage1Obj;

        [Header("Stage2 button")]
        public UnityEvent stage2;
        public GameObject stage2Obj;

        [Header("Stage3 button")]
        public UnityEvent stage3;
        public GameObject stage3Obj;

        [Header("Stage4 button")]
        public UnityEvent stage4;
        public GameObject stage4Obj;

        [Header("Exit button")]
        public UnityEvent exit;
        public Transtion trastion;
        public GameObject exitObj;
    }
    [SerializeField]
    public ButtonEvent button;
    public int buttonNum;

    [Space(5)]
    [SerializeField] GameObject UIWindow;
    [SerializeField] float GameWindow;
    [SerializeField] float StageNum;
    //[SerializeField] GameObject[] button;
    int whereinNum = 0;
    RectTransform rect;
    float WindowSize;
    int WindowNum;

    GameObject _button;
    // Start is called before the first frame update
    void Start()
    {
        rect = UIWindow.GetComponent<RectTransform>();
        WindowSize = UIWindow.GetComponent<RectTransform>().rect.width;
        //WindowNum = UIWindow.GetComponent<RectTransform>().rect.width / StageNum;
        //Debug.Log(WindowSize);

        button.tutorial = new UnityEvent();
        button.stage1 = new UnityEvent();
        button.stage2 = new UnityEvent();
        button.stage3 = new UnityEvent();
        button.stage4 = new UnityEvent();
        //button.exit = new UnityEvent();
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
            button.exit.Invoke();
            button.trastion.Trans_ToMenu();
            //unityEvent.Invoke();
            //EventSystem.current.SetSelectedGameObject(button[5]);
        }

        //Tutorial
        if(whereinNum == 0)
        {
            button.tutorialObj.SetActive(true);
            EventSystem.current.SetSelectedGameObject(button.tutorialObj);
            //button[0].SetActive(true);
            if (Input.GetKey(KeyCode.Joystick1Button0))
            {
                button.tutorial.Invoke();
                //EventSystem.current.SetSelectedGameObject(button[0]);
            }
        }
        else
        {
            //button[0].SetActive(false);
            button.tutorialObj.SetActive(false);
        }

        //Stage1
        if (whereinNum == 1)
        {
            button.stage1Obj.SetActive(true);
            EventSystem.current.SetSelectedGameObject(button.stage1Obj);
            //button[1].SetActive(true);
            if (Input.GetKey(KeyCode.Joystick1Button0))
            {
                button.stage1.Invoke();
                //EventSystem.current.SetSelectedGameObject(button[1]);
            }
        }
        else 
        {
            button.stage1Obj.SetActive(false);
            //button[1].SetActive(false);
        }

        //Stage2
        if (whereinNum == 2)
        {
            button.stage2Obj.SetActive(true);
            EventSystem.current.SetSelectedGameObject(button.stage2Obj);
            //button[2].SetActive(true);
            if (Input.GetKey(KeyCode.Joystick1Button0))
            {
                button.stage2.Invoke();
                //EventSystem.current.SetSelectedGameObject(button[2]);
            }
        }
        else 
        {
            button.stage2Obj.SetActive(false);
            //button[2].SetActive(false);
        }

        //Stage3
        if (whereinNum == 3)
        {
            button.stage3Obj.SetActive(true);
            EventSystem.current.SetSelectedGameObject(button.stage3Obj);
            //button[3].SetActive(true);
            if (Input.GetKey(KeyCode.Joystick1Button0))
            {
                button.stage3.Invoke();
                //EventSystem.current.SetSelectedGameObject(button[3]);
            }
        }
        else
        {
            button.stage3Obj.SetActive(false);
            //button[3].SetActive(false);
        }

        //Stage4
        if (whereinNum == 4)
        {
            button.stage4Obj.SetActive(true);
            EventSystem.current.SetSelectedGameObject(button.stage4Obj);
            //button[4].SetActive(true);
            if (Input.GetKey(KeyCode.Joystick1Button0))
            {
                button.stage4.Invoke();
                //EventSystem.current.SetSelectedGameObject(button[4]);
            }
        }
        else
        {
            button.stage4Obj.SetActive(false);
            //button[4].SetActive(false);
        }
        _button = EventSystem.current.currentSelectedGameObject;
        Debug.Log(_button.name);
    }
}
