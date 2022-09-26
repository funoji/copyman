using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameQuitScript : MonoBehaviour
{
    [SerializeField] GameObject DefaltImage;
    [SerializeField] Sprite ReallySprite;
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
            SceneManager.LoadScene("TestScene");
        }
        else
        {
            DefaltImage.GetComponent<Image>().sprite = ReallySprite;
            IsSecond = true;
        }
    }
}
