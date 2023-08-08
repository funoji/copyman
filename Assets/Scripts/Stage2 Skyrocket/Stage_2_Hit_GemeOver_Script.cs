//アタッチするオブジェクト：Debug用Cube「DebugCD_Cube」・プレイヤー
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//特定のオブジェクトに当たったらの処理
public class Stage_2_Hit_GemeOver_Script : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "GameOver")
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
    }
}
