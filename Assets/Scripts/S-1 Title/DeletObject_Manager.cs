using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Object���폜����
public class DeletObject_Manager : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject)
        {
            Destroy(collision.gameObject);
        }
    }
}