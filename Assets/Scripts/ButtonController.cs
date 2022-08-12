using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour
{
    [SerializeField] GameObject selectIcon_C;
    [SerializeField] GameObject selectIcon_E;

    [SerializeField] Button nextButton;
    [SerializeField] Button endButton;

    public GameObject button;

    // Start is called before the first frame update
    void Start()
    {
        selectIcon_C.SetActive(true);
        selectIcon_E.SetActive(false);
        nextButton.Select();
        button = EventSystem.current.currentSelectedGameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Switch_Button();
    }

    void Switch_Continue()
    {
        selectIcon_C.SetActive(false);
        selectIcon_E.SetActive(true);
        endButton.Select();
        button = EventSystem.current.currentSelectedGameObject;
        //Debug.Log("button : "+button.name);
    }

    void Switch_EndGame()
    {
        selectIcon_C.SetActive(true);
        selectIcon_E.SetActive(false);
        nextButton.Select();
        button = EventSystem.current.currentSelectedGameObject;
        //Debug.Log("button : " + button.name);
    }

    void Switch_Button()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Switch_Continue();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Switch_EndGame();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (button.name == "ContinueButton")
            {
                Debug.Log("コンティニューを押しました。");
            }
            if (button.name == "EndGameButton")
            {
                Debug.Log("ゲーム終了を押しました。");
            }
        }
    }
}
