using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameQuitScript : MonoBehaviour
{
    [SerializeField] GameObject DefaltImage;
    [SerializeField] Sprite ReallySprite;
    [SerializeField] Sprite ReallySprite2;
    [SerializeField] Sprite ReallySprite3;
    Transtion transtionSystem;

    private bool IsSecond = false;
    private float vertical;
    void Start()
    {
        transtionSystem = GameObject.Find("TranstionSystem").GetComponent<Transtion>();
    }

    void Update()
    {
        if (!IsSecond) return;
        vertical = Input.GetAxis("LstickVertical");
        if (vertical != 0)
        {
            IsSecond = false;
            DefaltImage.GetComponent<Image>().sprite = ReallySprite3;
        }
    }

    public void OnClick()
    {
        if (IsSecond)
        {
            DefaltImage.GetComponent<Image>().sprite = ReallySprite2;
            transtionSystem.Trans_ToGameEnd();
//#if UNITY_STANDALONE
//            Application.Quit();
//#endif
//#if UNITY_EDITOR
//            UnityEditor.EditorApplication.isPlaying = false;
//#endif
        }
        else
        {
            DefaltImage.GetComponent<Image>().sprite = ReallySprite;
            IsSecond=true;
        }
    }
}
