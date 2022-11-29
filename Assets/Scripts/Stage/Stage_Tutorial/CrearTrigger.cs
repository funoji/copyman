using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameDirector.GameClear = true;
            Debug.Log("Crear");
        }
    }
}
