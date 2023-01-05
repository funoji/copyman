using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectSecondbuttons : MonoBehaviour
{
    [SerializeField] GameObject button;
    public void OnClick()
    {
        EventSystem.current.SetSelectedGameObject(button);
    }
}
