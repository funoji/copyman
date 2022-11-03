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
        CheatClear();
        CheatReset();
    }

    void CheatClear()
    {
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.C))
        {
            //ClearFlag of Stage1
            GameDirector.GameClear = true;
            //Clearflag ob Stage4
            a_ballGenerator.Clearcount = 0;
        }
        
    }

    void CheatReset()
    {
        if (Input.GetKey(KeyCode.LeftControl)&&Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Cheat");
            GameDirector.GameClear = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
