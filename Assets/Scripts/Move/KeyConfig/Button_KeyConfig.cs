using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_KeyConfig : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<JumpManager>().Jump();�@//�W�����v
        }
        if (Input.GetButtonDown("Jump"))  //�`�{�^��
        {
            GetComponent<JumpManager>().Jump();�@//�W�����v
        }
        //if (Input.GetButtonDown("joystick button 1"))  //�a�{�^��
        //{

        //}
        //if (Input.GetButtonDown("joystick button 2"))  //�w�{�^��
        //{

        //}
        //if (Input.GetButtonDown("joystick button 3"))  //�x�{�^��
        //{

        //}
        //if (Input.GetButtonDown("joystick button 4"))  //�k�a�{�^��
        //{

        //}
        //if (Input.GetButtonDown("joystick button 5"))  //�q�a�{�^��
        //{

        //}
        //if (Input.GetButtonDown("joystick button 6"))  //back�{�^��
        //{

        //}
        //if (Input.GetButtonDown("joystick button 7"))  //start�{�^��
        //{

        //}
        //if (Input.GetButtonDown("joystick button 8"))  //L�X�e�B�b�N��������
        //{

        //}
        //if (Input.GetButtonDown("joystick button 9"))  //R�X�e�B�b�N��������
        //{

        //}
    }
}
