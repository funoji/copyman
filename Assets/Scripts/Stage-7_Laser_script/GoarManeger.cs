using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoarManeger : MonoBehaviour
{
    //�Q�[���N���A�t���O�i�����Ffalse�j
    public bool gameclearFlag = false; 

    //Goar����
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player�Ɠ�����܂����B�i�S�[���j");
            gameclearFlag = true;
        }
    }
}
