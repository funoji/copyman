using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Object������
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
