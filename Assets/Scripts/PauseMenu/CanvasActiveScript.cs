using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CanvasActiveScript : MonoBehaviour
{
    [SerializeField] GameObject ActivePanel;
    [SerializeField] GameObject InActivePanel;
    [SerializeField] GameObject CopyInput;
    [SerializeField] GameObject button;

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
        if (Input.GetButtonDown("Pose"))
        {
            Pose();
        }
    }
    private void Pose()
    {
        if (IsPose==false)
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(button);

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
