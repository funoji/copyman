//�A�^�b�`����I�u�W�F�N�g�FDebug�pCube�uDebugCD_Cube�v�E�v���C���[
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����̃I�u�W�F�N�g�ɓ���������̏���
public class Stage_2_Hit_GemeOver_Script : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "GameOver")
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
    }
}