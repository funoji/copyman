using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_KeyConfig : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<JumpManager>().Jump();　//ジャンプ
        }
        //if (Input.GetButtonDown("Jump"))  //Ａボタン
        //{
        //    GetComponent<JumpManager>().Jump();　//ジャンプ
        //}
    }
}
