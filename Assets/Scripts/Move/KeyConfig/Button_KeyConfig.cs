using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_KeyConfig : MonoBehaviour
{
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.space))
        //{
        //    GetComponent<JumpManager>().Jump();�@//�W�����v
        //}
        if (Input.GetButtonDown("Jump"))  //�`�{�^��
        {
            Debug.Log("Jamp");
            GetComponent<JumpManager>().Jump();�@//�W�����v
        }
    }
}
