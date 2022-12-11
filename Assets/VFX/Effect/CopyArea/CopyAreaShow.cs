using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyAreaShow : MonoBehaviour
{
    [SerializeField] GameObject eff;
    private void Start()
    {
        eff.gameObject.SetActive(false);
    }

    void Update()
    {
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
