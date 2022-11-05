using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_KeyConfig : MonoBehaviour
{
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.space))
        //{
        //    GetComponent<JumpManager>().Jump();　//ジャンプ
        //}
        if (Input.GetButtonDown("Jump"))  //Ａボタン
        {
            Debug.Log("Jamp");
            GetComponent<JumpManager>().Jump();　//ジャンプ
        }
    }
}
