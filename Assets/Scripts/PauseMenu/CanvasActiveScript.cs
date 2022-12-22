using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasActiveScript : MonoBehaviour
{
    [SerializeField] GameObject ActivePanel;
    [SerializeField] GameObject InActivePanel;
    [SerializeField] GameObject CopyInput;
    bool IsPose = false;

    Copyinput copyInput;

    // Start is called before the first frame update
    void Start()
    {
        CopyInput = GameObject.Find("CPM");
        copyInput = CopyInput.GetComponent<Copyinput>();
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
        //Debug.Log(copyInput.IsActive);
    }
    private void Pose()
    {
        if (IsPose==false)
        {
            copyInput.IsActive = false;
            Debug.Log("Panel is active");
            Time.timeScale = 0f;
            ActivePanel.SetActive(true);
        }
        else
        {
            copyInput.IsActive = true;
            Time.timeScale = 1f;
            ActivePanel.SetActive(false);
            InActivePanel.SetActive(false);
        }
        IsPose = !IsPose;
    }
}
