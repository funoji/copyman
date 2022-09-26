using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick_KeyConfig : MonoBehaviour
{
    public float speed = 2.0f;

    void Update()
    {
        if (Input.GetAxis("Horizontal")!=0)
        {
            GetComponent<L_StickMove>().L_Stick_Move_X(speed);
        }
        if (Input.GetAxis("Vertical")!=0)
        {
            GetComponent<L_StickMove>().L_Stick_Move_Y(speed);
        }
        //if (Input.GetAxis("4th axis") == 1)　//Ｒスティック（Ｘ方向）
        //{

        //}
        //if (Input.GetAxis("5th axis") == 1)　//Ｒスティック（Ｙ方向）
        //{

        //}
        //if (Input.GetAxis("6th axis") == 1)　//十字キー（上下）
        //{

        //}
        //if (Input.GetAxis("7th axis") == 1)　//十字キー（左右）
        //{

        //}
        //if (Input.GetAxis("X axis") != 0)　//Ｌスティック（Ｘ方向）
        //{
        //    GetComponent<L_StickMove>().L_Stick_Move_X(speed);
        //}
        //if (Input.GetAxis("Y axis") != 0)　//Ｌスティック（Ｙ方向）
        //{
        //    GetComponent<L_StickMove>().L_Stick_Move_Y(speed);
        //}
    }
}
