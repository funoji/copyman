using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Objectを消す
public class Stage_2_Deletion_Script : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Trigger")
        {
            //オブジェクトを消す
            Destroy(this.gameObject);
        }
    }
}
