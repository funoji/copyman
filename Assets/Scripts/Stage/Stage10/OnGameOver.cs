using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGameOver : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "CPM")
        {
            GameDirector.GameOver = true;
        }
    }
}
