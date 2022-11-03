using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoarManeger : MonoBehaviour
{
    //ゲームクリアフラグ（初期：false）
    public bool gameclearFlag = false; 

    //Goar判定
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Playerと当たりました。（ゴール）");
            gameclearFlag = true;
        }
    }
}
