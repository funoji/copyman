using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GoTitleScript : MonoBehaviour
{
    [SerializeField] [Tooltip("�߂�{�^��")] private GameObject toMenuButton;
    private GameObject button;

    private void Start()
    {
        EventSystem.current.SetSelectedGameObject(toMenuButton);
    }

    private void Update()
    {
        EventSystem.current.SetSelectedGameObject(toMenuButton);
        button = EventSystem.current.currentSelectedGameObject;
        if(button!=null)
            Debug.Log(button.name);
    }
}
