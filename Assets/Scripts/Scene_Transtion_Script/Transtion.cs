using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transtion : MonoBehaviour
{
    public void Trans_Menu()
    {
        SceneManager.LoadScene("S-02_Menu_Scene");
    }

    public void Trans_StageSelect()
    {
        SceneManager.LoadScene("Stage_01");
    }

    public void Trans_Option()
    {
        SceneManager.LoadScene("S-03_Option_Scene");
    }

    public void Trans_Catalog()
    {
        SceneManager.LoadScene("Stage_01");
    }

    public void Trasn_RetuenTitle()
    {
        SceneManager.LoadScene("S-01_Title_Scene");
    }

    public void Trans_GameClear()
    {
        SceneManager.LoadScene("S-01_Title_Scene");
    }

    public void Trans_GameOver()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    public void Trans_GameEnd()
    {
        Application.Quit();
    }
}
