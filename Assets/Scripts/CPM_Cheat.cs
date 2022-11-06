using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CPM_Cheat : MonoBehaviour
{
    A_BallGenerator a_ballGenerator;
    private GameObject a_ballGeneratorObj;
    void Update()
    {
        a_ballGeneratorObj = GameObject.Find("BallGenerateTrigger");
        a_ballGenerator = a_ballGeneratorObj.GetComponent<A_BallGenerator>();
        CheatEnd();
        CheatClear();
        CheatReset();

    }

    void CheatClear()
    {
        if ((Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.C)) ||(Input.GetKeyDown(KeyCode.Joystick1Button7) && Input.GetKey(KeyCode.Joystick1Button9)))
        {
            Debug.Log("CheatClear");
            //ClearFlag of Stage1
            GameDirector.GameClear = true;
            //Clearflag ob Stage4
            a_ballGenerator.Clearcount = 0;
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
        if ((Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Backspace)) || (Input.GetKey(KeyCode.Joystick1Button5) && Input.GetKey(KeyCode.Joystick1Button8) && Input.GetKey(KeyCode.Joystick1Button9)))
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
