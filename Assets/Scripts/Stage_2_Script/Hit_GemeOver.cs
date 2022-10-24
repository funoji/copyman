using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_GemeOver : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "GameOver")
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
    }
}
