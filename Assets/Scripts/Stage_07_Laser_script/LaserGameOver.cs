using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGameOver : MonoBehaviour
{
    //ゲームオーバーフラグ（初期：false）
    public bool gameoverFlag = false;

    //ゲームオーバー判定
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameoverFlag = true;
        }
    }
}
