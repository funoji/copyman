using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyAreaShow : MonoBehaviour
{
    [SerializeField] GameObject eff;
    GameObject CopyInput;
    Copyinput copyInput;

    private void Start()
    {
        CopyInput = GameObject.Find("CPM");
        copyInput = CopyInput.GetComponent<Copyinput>();
        eff.gameObject.SetActive(false);
    }

    void Update()
    {
        if (!copyInput.IsActive) return;
        IsActive();
    }

    void IsActive()
    {
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            eff.gameObject.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.Joystick1Button2))
        {
            eff.gameObject.SetActive(false);
        }
    }
}
