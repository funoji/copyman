//�A�^�b�`����I�u�W�F�N�g�GDebug�pCube�uTarget�v�E�I
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_2_Deletion_Script : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Trigger")
        {
            //�I�u�W�F�N�g������
            Destroy(this.gameObject);
        }
    }
}
