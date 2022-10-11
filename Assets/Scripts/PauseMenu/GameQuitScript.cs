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
    private bool IsSecond = false;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnClick()
    {
        if (IsSecond)
        {
            DefaltImage.GetComponent<Image>().sprite = ReallySprite2;
#if UNITY_STANDALONE
            Application.Quit();
#endif
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
        else
        {
            DefaltImage.GetComponent<Image>().sprite = ReallySprite;
            IsSecond=true;
        }
    }
}
