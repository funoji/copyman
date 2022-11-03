//アタッチするオブジェクト：Debug用Cube「DebugCD_Cube」・プレイヤー
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_2_Hit_GemeOver_Script : MonoBehaviour
{
    private Transtion transScene;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "GameOver")
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
            transScene.Trans_GameOver();
        }
    }
}
