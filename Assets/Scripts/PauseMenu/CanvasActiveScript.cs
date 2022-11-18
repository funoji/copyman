using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasActiveScript : MonoBehaviour
{
    [SerializeField] GameObject ActivePanel;
    [SerializeField] GameObject InActivePanel;
    bool IsPose = false;
    // Start is called before the first frame update
    void Start()
    {
        ActivePanel.SetActive(false);
        InActivePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.P))
        //{
        //    Debug.Log("P is pushed");
        //    Pose();
        //}
        if (Input.GetButtonDown("Pose"))
        {
            Pose();
        }
    }
    private void Pose()
    {
        if (IsPose==false)
        {
            Debug.Log("Panel is Instance");
            Time.timeScale = 0f;
            ActivePanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            ActivePanel.SetActive(false);
            InActivePanel.SetActive(false);
        }
        IsPose = !IsPose;
    }
}
