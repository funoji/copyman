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
        //if (Input.GetButtonDown("Jump"))  //�`�{�^��
        //{
        //    GetComponent<JumpManager>().Jump();�@//�W�����v
        //}
    }
}
