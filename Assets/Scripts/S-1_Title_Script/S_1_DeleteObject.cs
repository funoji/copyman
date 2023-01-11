using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Object‚ğíœ‚·‚é
public class S_1_DeleteObject : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject) { Destroy(collision.gameObject); }
    }
}