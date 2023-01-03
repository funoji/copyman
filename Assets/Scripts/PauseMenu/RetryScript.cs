using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryScript : MonoBehaviour
{
    public void RetryOnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void TitleOnClick()
    {
        SceneManager.LoadScene("S-01_Title_Scene");
    }
}
