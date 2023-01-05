using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CPM_Cheat : MonoBehaviour
{
    void Update()
    {
        CheatEnd();
        CheatClear();
        CheatOver();
        CheatReset();
    }

    void CheatOver()
    {
        if ((Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.X)) || (Input.GetKeyDown(KeyCode.Joystick1Button7) && Input.GetKey(KeyCode.Joystick1Button0)))
        {
            Debug.Log("CheatOver");
            //ClearFlag of Stage1
            GameDirector.GameOver = true;
        }
    }

    void CheatClear()
    {
        if ((Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.C)) ||(Input.GetKeyDown(KeyCode.Joystick1Button7) && Input.GetKey(KeyCode.Joystick1Button9)))
        {
            Debug.Log("CheatClear");
            //ClearFlag of Stage1
            GameDirector.GameClear = true;
        }  
    }

    void CheatReset()
    {
        if (Input.GetKey(KeyCode.LeftControl)&&Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Joystick1Button6) && Input.GetKey(KeyCode.Joystick1Button9))
        {
            GameDirector.GameClear = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Debug.Log("CheatReset");
        }
    }

    void CheatEnd()
    {
        if ((Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Backspace)) || (Input.GetKey(KeyCode.Joystick1Button6) && Input.GetKeyDown(KeyCode.Joystick1Button7)))
        {
            Debug.Log("CheatEnd");
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
        }
    }
}
