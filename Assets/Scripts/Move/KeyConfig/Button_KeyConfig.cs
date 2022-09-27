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
        if (Input.GetButtonDown("Jump"))  //Ａボタン
        {
            GetComponent<JumpManager>().Jump();　//ジャンプ
        }
        //if (Input.GetButtonDown("joystick button 1"))  //Ｂボタン
        //{

        //}
        //if (Input.GetButtonDown("joystick button 2"))  //Ｘボタン
        //{

        //}
        //if (Input.GetButtonDown("joystick button 3"))  //Ｙボタン
        //{

        //}
        //if (Input.GetButtonDown("joystick button 4"))  //ＬＢボタン
        //{

        //}
        //if (Input.GetButtonDown("joystick button 5"))  //ＲＢボタン
        //{

        //}
        //if (Input.GetButtonDown("joystick button 6"))  //backボタン
        //{

        //}
        //if (Input.GetButtonDown("joystick button 7"))  //startボタン
        //{

        //}
        //if (Input.GetButtonDown("joystick button 8"))  //Lスティック押し込み
        //{

        //}
        //if (Input.GetButtonDown("joystick button 9"))  //Rスティック押し込み
        //{

        //}
    }
}
