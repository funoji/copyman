using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Object‚ğíœ‚·‚é
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