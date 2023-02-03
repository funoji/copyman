using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Object‚ğíœ‚·‚é
public class S_1_DeleteObject : MonoBehaviour
{
    private Rigidbody rb;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject) 
        {
            Debug.Log(collision.gameObject.name);

            Destroy(collision.gameObject); 
        }
    }
}