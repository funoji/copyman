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
        //if (Input.GetAxis("4th axis") == 1)�@//�q�X�e�B�b�N�i�w�����j
        //{

        //}
        //if (Input.GetAxis("5th axis") == 1)�@//�q�X�e�B�b�N�i�x�����j
        //{

        //}
        //if (Input.GetAxis("6th axis") == 1)�@//�\���L�[�i�㉺�j
        //{

        //}
        //if (Input.GetAxis("7th axis") == 1)�@//�\���L�[�i���E�j
        //{

        //}
        //if (Input.GetAxis("X axis") != 0)�@//�k�X�e�B�b�N�i�w�����j
        //{
        //    GetComponent<L_StickMove>().L_Stick_Move_X(speed);
        //}
        //if (Input.GetAxis("Y axis") != 0)�@//�k�X�e�B�b�N�i�x�����j
        //{
        //    GetComponent<L_StickMove>().L_Stick_Move_Y(speed);
        //}
    }
}
