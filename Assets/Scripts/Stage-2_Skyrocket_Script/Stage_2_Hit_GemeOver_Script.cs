//�A�^�b�`����I�u�W�F�N�g�FDebug�pCube�uDebugCD_Cube�v�E�v���C���[
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_2_Hit_GemeOver_Script : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "GameOver")
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
            Transtion.instatns.Trans_GameOver();
            return;
        }
        else if (other.gameObject.tag == "GameOver" && other.gameObject.GetComponent<Renderer>().material.color == Color.red)
        {
            return;
        }
    }
}
