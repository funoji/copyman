using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectUI : MonoBehaviour
{
    [SerializeField] GameObject UIWindow;
    [SerializeField] float GameWindow;
    [SerializeField] float StageNum;
    float whereinNum = 0;
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
        if(Input.GetKeyDown(KeyCode.RightArrow) && whereinNum < StageNum)
        {
            rect.localPosition += new Vector3(-GameWindow, 0, 0);
            whereinNum++;
            Debug.Log(whereinNum);
            Debug.Log(StageNum);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && whereinNum > 0)
        {
            rect.localPosition += new Vector3(GameWindow, 0, 0);
            whereinNum--;
            Debug.Log(whereinNum);
            Debug.Log(StageNum);
        }
    }
}
